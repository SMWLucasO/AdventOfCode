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
            Dictionary<int, long> fuelDiffs = new Dictionary<int, long>();

            int maxPos = input.Max();
            for (int i = 0; i <= maxPos; i++)
            {

                foreach (var crabMove in input) 
                    fuelDiffs.SetOrAdd(i, Math.Abs(crabMove - i));
            }


            return fuelDiffs.Values.Min();
        }

        public static long SolutionPartTwo(IEnumerable<int> input)
        {
            Dictionary<int, long> fuelDiffs = new Dictionary<int, long>();

            int maxPos = input.Max();
            for (int i = 0; i <= maxPos; i++)
            {

                foreach (var crabMove in input)
                {

                    int stepsToMove = Math.Abs(i - crabMove);

                    int steps = 0;
                    for (int j = 1; j <= stepsToMove; j++)
                        steps += j;

                    fuelDiffs.SetOrAdd(i, steps);
                }
                    
            }


            return fuelDiffs.Values.Min();
        }
        
    }
}