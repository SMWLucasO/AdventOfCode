using System;
using System.Linq;

namespace AdventOfCode.Common.Utilities
{
    public static class NumberUtility
    {
        public static int BinaryStringToDecimal(string input)
        {
            int index = 0;
            return input.Select(val => Convert.ToInt32(val - '0'))
                .Select(num => num * (int) Math.Pow(2, (input.Length - 1 - index++))).Sum();
        }

        public static int BinaryIntArrayToDecimal(int[] input) 
            => input.Select((t, i) => t * (int) Math.Pow(2, (input.Length - 1 - i))).Sum();
    }
}