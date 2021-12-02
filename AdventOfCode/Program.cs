using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AdventOfCode.Common.Utilities;
using AdventOfCode.Day1;
using AdventOfCode.Day2;

namespace AdventOfCode
{
    class Program
    {
        static void Main(string[] args)
        {

            // day 1
            var input = FileUtility.FileInputToNumberList("Resources/Day1/input.txt");
            
            Console.WriteLine(DepthIncrease.Solution(input));
            Console.WriteLine(DepthIncrease.SolutionSlidingWindow(input));

            Console.WriteLine();
            
            // day 2
            var movements = File.ReadAllLines("Resources/Day2/input.txt");
            Console.WriteLine(SubmarinePiloting.SolutionPartOne(movements));
            Console.WriteLine(SubmarinePiloting.SolutionPartTwo(movements));


        }
    }
}