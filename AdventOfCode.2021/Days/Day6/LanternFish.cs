using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Common.Fluent.Collections;
using AdventOfCode.Common.Utilities;

namespace AdventOfCode.Days.Day6
{
    public static class LanternFish
    {

        public static int Solution(string[] input)
        {
            List<int> nums = input.Select(int.Parse).ToList();

            for (int i = 0; i < 80; i++)
            {
                List<int> newList = new List<int>();

                foreach (var num in nums)
                {
                    int nNum = num - 1;
                    if (nNum == -1)
                    {
                        nNum = 6;
                        newList.Add(8);
                    }
                    newList.Add(nNum);
                }

                nums = newList;

            }

            return nums.Count;
        }

        public static long SolutionPartTwo(string[] input)
        {
            List<int> nums = input.Select(int.Parse).ToList();

            // <age>, <count>
            Dictionary<int, long> fishCount = new Dictionary<int, long>();

            foreach (var num in nums)
                fishCount.SetOrAdd(num, 1);

            for (int i = 0; i < 256; i++)
            {
                Dictionary<int, long> newFishCount = new Dictionary<int, long>();
                foreach (var (key, val) in fishCount)
                {
                    if (key == 0)
                    {
                        newFishCount.SetOrAdd(6, val);
                        newFishCount.SetOrAdd(8, val);
                    }
                    else
                    {
                        newFishCount.SetOrAdd(key - 1, val);
                    }
                }

                fishCount = newFishCount;
            }

            return fishCount.Values.Sum();
        }
        
    }
}