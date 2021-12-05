using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Common.Fluent.Collections;
using AdventOfCode.Common.Utilities.Geometries;

namespace AdventOfCode.Days
{
    public static class HydrothermalVenture
    {
        public static IEnumerable<Line> GetLines(string[] input) =>
            input.Select(x =>
            {
                var split = x.Split(" -> ");
                var leftHand = split[0].Split(',');
                var rightHand = split[1].Split(',');

                return new Line((int.Parse(leftHand[0]), int.Parse(leftHand[1])),
                    (int.Parse(rightHand[0]), int.Parse(rightHand[1])));
            });

        public static int Solution(string[] input)
        {
            Dictionary<(int, int), int> points = new();

            GetLines(input).Where(x => x.Start.X == x.End.X || x.Start.Y == x.End.Y)
                .SelectMany(line => line.GetStraightPointsInLine()).Then(x => points.SetOrAdd((x.X, x.Y), 1));
            
            return points.Values.Count(x => x > 1);
        }

        public static int SolutionPartTwo(string[] input)
        {
            var lines = GetLines(input).ToList();

            Dictionary<(int, int), int> points = new();

            lines.SelectMany(line => line.GetPointsInLine())
                .Then(x => points.SetOrAdd((x.X, x.Y), 1));

            return points.Values.Count(x => x > 1);
        }
    }
}