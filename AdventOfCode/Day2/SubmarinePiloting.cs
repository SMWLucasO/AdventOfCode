using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Common.Fluent.Collections;

namespace AdventOfCode.Day2
{
    public static class SubmarinePiloting
    {
        
        public static int SolutionPartOne(string[] input)
        {
            var parsedInput = PreparePartData(input, PreparePart1Data);
            return parsedInput["forward"] * (parsedInput["down"] - parsedInput["up"]);
        }

        public static int SolutionPartTwo(string[] input)
        {
            var parsedInput = PreparePartData(input, PreparePart2Data);
            
            return parsedInput.GetValueOrDefault("forward", 0)
                   * (parsedInput.GetValueOrDefault("down", 0) 
                      - parsedInput.GetValueOrDefault("up", 0)
                      );
        }
        
        
        private static Dictionary<string, int> PreparePartData(string[] input, Action<Dictionary<string, int>, string, string> preparator)
        {
            var dict = new Dictionary<string, int>();

            foreach (var kv in input)
            {
                var output = kv.Split(' ');
                preparator(dict, output[0], output[1]);
            }

            return dict;
        }

        private static void PreparePart1Data(Dictionary<string, int> dict, string key, string value)
            => dict.SetOrAdd(key, int.Parse(value));
        
        private static void PreparePart2Data(Dictionary<string, int> dict, string key, string value)
        {
            
            
            switch (key)
            {
                case "forward":
                    dict.SetOrAdd("forward", int.Parse(value));
                    dict.SetOrAdd("down", int.Parse(value) * dict.GetValueOrDefault("aim", 0));
                    break;
                case "up":
                    dict.SetOrAdd("aim", -int.Parse(value));
                    break;
                case "down":
                    dict.SetOrAdd("aim", int.Parse(value));
                    break;
            }
        }

    }
}