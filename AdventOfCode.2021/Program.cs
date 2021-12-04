using System;
using System.IO;
using AdventOfCode.Common.Utilities;
using AdventOfCode.Days.Day1;
using AdventOfCode.Days.Day2;
using AdventOfCode.Days.Day3;
using AdventOfCode.Days.Day4;

namespace AdventOfCode
{
    class Program
    {
        static void Main(string[] args)
        {
            // day 1
            var input = InputUtility.FileInputToNumberList("Resources/Day1/input.txt");

            Console.WriteLine(DepthIncrease.Solution(input));
            Console.WriteLine(DepthIncrease.SolutionSlidingWindow(input));

            Console.WriteLine();

            // day 2
            var movements = File.ReadAllLines("Resources/Day2/input.txt");
            Console.WriteLine(SubmarinePiloting.SolutionPartOne(movements));
            Console.WriteLine(SubmarinePiloting.SolutionPartTwo(movements));

            Console.WriteLine();
            
            // Day 3

            var diagnostics = File.ReadAllLines("Resources/Day3/input.txt");
            Console.WriteLine(BinaryDiagnostic.Solution(diagnostics));
            Console.WriteLine(BinaryDiagnostic.SolutionPartTwo(diagnostics));
            
            Console.WriteLine();
            
            // Day 4
            var game = File.ReadAllLines("Resources/Day4/input.txt");
            Console.WriteLine(GiantSquid.Solution(game));
            Console.WriteLine(GiantSquid.SolutionPartTwo(game));

        }
    }
}