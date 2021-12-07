using System;
using System.Collections.Generic;
using System.IO;
using AdventOfCode.Common.Functional.Inputs;
using AdventOfCode.Common.Functional.Inputs.Modules;
using AdventOfCode.Common.Utilities;
using AdventOfCode.Days.Day1;
using AdventOfCode.Days.Day2;
using AdventOfCode.Days.Day3;
using AdventOfCode.Days.Day4;
using AdventOfCode.Days.Day5;
using AdventOfCode.Days.Day6;
using AdventOfCode.Days.Day7;

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

            Console.WriteLine();

            // Day 5
            var hydro = File.ReadAllLines("Resources/Day5/input.txt");
            Console.WriteLine(HydrothermalVenture.Solution(hydro));
            Console.WriteLine(HydrothermalVenture.SolutionPartTwo(hydro));

            Console.WriteLine();

            // Day 6

            var fish = File.ReadAllLines("Resources/Day6/input.txt");
            Console.WriteLine(LanternFish.Solution(fish[0].Split(',')));
            Console.WriteLine(LanternFish.SolutionPartTwo(fish[0].Split(',')));

            Console.WriteLine();

            // Day 7

            var crabs = FluentInput<string>.From(File.ReadAllLines("Resources/Day7/input.txt")[0].Split(','))
                .Map(int.Parse).Elements;

            Console.WriteLine(TreacheryWhales.Solution(crabs));
            Console.WriteLine(TreacheryWhales.SolutionPartTwo(crabs));
            
            Console.WriteLine();
            
            // Day 8
            
        }
    }
}