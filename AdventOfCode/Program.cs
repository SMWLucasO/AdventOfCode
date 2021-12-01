using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AdventOfCode.Day1;

namespace AdventOfCode
{
    class Program
    {
        static void Main(string[] args)
        {

            // day 1
            var input = File.ReadAllLines("Resources/Day1/input.txt")
                .Select(str => Convert.ToInt32(str)).ToList();
            
            Console.WriteLine(DepthIncrease.Solution(input));
            Console.WriteLine(DepthIncrease.SolutionSlidingWindow(input));

        }
    }
}