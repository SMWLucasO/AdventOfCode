using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace AdventOfCode.Common.Utilities.Geometries
{
    public class Point
    {
        
        /// <summary>
        /// The x-coordinate of the point.
        /// </summary>
        public int X { get; set; }
        
        /// <summary>
        /// The y-coordinate of the point.
        /// </summary>
        public int Y { get; set; }

        public Point(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
        
        /// <summary>
        /// Get the point as a tuple (x, y)
        /// </summary>
        /// <returns>(x, y)</returns>
        public (int, int) AsTuple()
            => (X, Y);
        
        /// <summary>
        /// Get all the points between the two given points.
        /// Only works for straight and diagonal lines.
        /// </summary>
        /// <param name="p1">The starting point</param>
        /// <param name="p2">The ending point</param>
        /// <returns></returns>
        public static List<Point> Between([NotNull] Point p1, [NotNull] Point p2) 
            => new Line(p1, p2).GetPointsInLine();
    }
}