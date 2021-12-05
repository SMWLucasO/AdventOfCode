using System;
using System.Collections.Generic;

namespace AdventOfCode.Common.Utilities.Geometries
{
    public class Line
    {
        public Point Start { get; set; }

        public Point End { get; set; }

        public Line(Point start, Point end)
        {
            this.Start = start;
            this.End = end;
        }

        public Line(int x1, int y1, int x2, int y2) : this(new Point(x1, y1), new Point(x2, y2))
        {
        }

        public Line((int, int) start, (int, int) end) : this(start.Item1, start.Item2, end.Item1, end.Item2)
        {
        }

        public bool Intersects(Line line)
        {
            // ax + b = qx + c
            // ax + b - qx - c = 0

            var (slope, point) = GetPointSlope();
            var (targetSlope, targetPoint) = line.GetPointSlope();

            return (slope + point) - (targetSlope - targetPoint) == 0;
        }

        public bool Intersects(Point point)
        {
            throw new NotImplementedException();
        }

        public (double, double) GetPointSlope()
        {
            // Ax + b
            // slope = a
            // X = start.X
            // y = ax + b
            // y - ax = b

            var slope = GetSlope();
            return (slope, Start.Y - (slope * Start.X));
        }

        public double GetSlope()
            => ((double) End.Y - Start.Y) / ((double) End.X - Start.X);

        public List<Point> GetPointsInLine()
        {
            List<Point> points = new();
            
            points.AddRange(GetStraightPointsInLine());
            points.AddRange(GetDiagonalPointsInLine());
            
            return points;
        }
        
        public IEnumerable<Point> GetDiagonalPointsInLine()
        {
            List<Point> results = new();

            // We are dealing with a diagonal line
            if (Start.X == End.X || Start.Y == End.Y) return results;
            
            Point dir = new Point(1, 1);
            if (End.X < Start.X) dir.X = -1;
            if (End.Y < Start.Y) dir.Y = -1;

            Point p = Start;
            results.Add(p);
            while(p.X != End.X && p.Y != End.Y)
            {
                Point nP = new Point(p.X + dir.X, p.Y + dir.Y);
                results.Add(nP);
                p = nP;
            }

            return results;

        }
        
        public IEnumerable<Point> GetStraightPointsInLine()
        {
            List<Point> results = new();

            int minX = Math.Min(Start.X, End.X);
            int minY = Math.Min(Start.Y, End.Y);

            int maxX = Math.Max(Start.X, End.X);
            int maxY = Math.Max(Start.Y, End.Y);

            if (minX != maxX && minY != maxY) return results;
            
            if (minX != maxX)
                for (int i = minX; i <= maxX; i++)
                    results.Add(new Point(i, minY));

            if (minY != maxY)
                for (int i = minY; i <= maxY; i++)
                    results.Add(new Point(minX, i));
            
            return results;
        }
    }
}