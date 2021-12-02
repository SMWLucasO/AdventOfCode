using System.Collections.Generic;

namespace AdventOfCode.Days.Day1
{
    public static class DepthIncrease
    {
        public static int Solution(IList<int> input)
        {
            if (input.Count <= 1)
                return 0;

            int increments = 0;

            for (int i = 0; i < input.Count - 1; i++)
            {
                // verschil check, is het verschil positief? Dan hebben we een increase.
                if (input[i + 1] - input[i] > 0)
                    increments += 1;
            }

            return increments;
        }

        public static int SolutionSlidingWindow(IList<int> input)
        {
            // Remove from start
            // Add to end

            // Two vars: current and next.

            int solution = 0;
            int currentSum = 0;


            // sliding window gedoe
            int left = 0;
            int right = 0;

            while (right < input.Count)
            {
                if (right < 3)
                {
                    currentSum += input[right++];
                    continue;
                }

                // Haal van de tail af, voeg aan de head toe. Zo kan je 't zien.
                int nextSum = (currentSum - input[left++]) + input[right++];

                // volgende beter dan huidige? Dan increment.
                if (nextSum > currentSum)
                    solution += 1;

                currentSum = nextSum;
            }

            return solution;
        }
    }
}