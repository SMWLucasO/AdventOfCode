using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Common.Utilities;

namespace AdventOfCode.Days.Day3
{
    public static class BinaryDiagnostic
    {
        public static int Solution(string[] input)
        {
            int[] gammaBits = new int[12];
            int[] epsilonBits = new int[12];

            for (int i = 0; i < gammaBits.Length; i++)
            {
                int mostCommon = GetVerticalMostCommonBit(input, i);

                gammaBits[i] = mostCommon;
                epsilonBits[i] = mostCommon == 0 ? 1 : 0;
            }

            return NumberUtility.BinaryIntArrayToDecimal(gammaBits)
                   * NumberUtility.BinaryIntArrayToDecimal(epsilonBits);
        }

        public static int SolutionPartTwo(string[] input)
            => NumberUtility.BinaryStringToDecimal(GetOxygenTankRate(input.ToList(), 0))
               * NumberUtility.BinaryStringToDecimal(GetCo2ScrubberRate(input.ToList(), 0));

        private static string GetOxygenTankRate(List<string> input, int position)
        {
            if (input.Count == 1 || position >= input[0].Length)
                return input[0];

            return GetOxygenTankRate(
                input.FindAll(x => x[position].Equals(GetVerticalMostCommonBit(input, position).ToString()[0])),
                position + 1
            );
        }

        private static string GetCo2ScrubberRate(List<string> input, int position)
        {
            if (input.Count == 1 || position >= input[0].Length)
                return input[0];

            return GetCo2ScrubberRate(
                input.FindAll(x => x[position].Equals(GetVerticalLeastCommonBit(input, position).ToString()[0])),
                position + 1
            );
        }


        private static int GetVerticalMostCommonBit(IEnumerable<string> input, int column)
        {
            int zeroes = 0;
            int ones = 0;

            foreach (var t in input)
                if (t[column] == '0')
                    zeroes += 1;
                else
                    ones += 1;

            return (ones >= zeroes) ? 1 : 0;
        }

        private static int GetVerticalLeastCommonBit(IEnumerable<string> input, int column)
        {
            int zeroes = 0;
            int ones = 0;

            foreach (var t in input)
                if (t[column] == '0')
                    zeroes += 1;
                else
                    ones += 1;

            return (zeroes <= ones) ? 0 : 1;
        }
    }
}