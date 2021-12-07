using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Common.Fluent.Collections;

namespace AdventOfCode.Days.Day7
{
    public static class TreacheryWhales
    {
        public static long Solution(IEnumerable<int> input)
        {
            var list = input.ToList();
            list.Sort();

            int median = list[(list.Count % 2 == 0 ? ((list.Count - 1) / 2) : list.Count / 2)];
            return input.Select(x => Math.Abs(x - median)).Sum();
        }

        public static long SolutionPartTwo(IEnumerable<int> input) 
            => input.Select(x => Math.Abs(x - (int) input.Average())).Select(x => (x * (x + 1)) / 2).Sum();
    }
}