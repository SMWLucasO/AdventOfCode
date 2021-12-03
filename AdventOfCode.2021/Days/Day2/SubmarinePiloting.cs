using System.Collections.Generic;
using AdventOfCode.Common.Fluent.Collections;
using AdventOfCode.Common.Utilities;

namespace AdventOfCode.Days.Day2
{
    public static class SubmarinePiloting
    {
        public static int SolutionPartOne(IEnumerable<string> input)
        {
            var parsedInput = InputUtility.SummableToDictionary(input, s =>
            {
                var split = s.Split(' ');
                return (split[0], int.Parse(split[1]));
            });

            return parsedInput["forward"] * (parsedInput["down"] - parsedInput["up"]);
        }

        public static int SolutionPartTwo(IEnumerable<string> input)
        {
            var parsedInput = InputUtility.PopulateDictionary<string, int>(input, (dict, line) =>
            {
                var split = line.Split(' ');
                var key = split[0];
                var value = int.Parse(split[1]);

                switch (key)
                {
                    case "forward":
                        dict.SetOrAdd("forward", value);
                        dict.SetOrAdd("down", value * dict.GetValueOrDefault("aim", 0));
                        break;
                    case "up":
                        dict.SetOrAdd("aim", -value);
                        break;
                    case "down":
                        dict.SetOrAdd("aim", value);
                        break;
                }
            });

            return parsedInput.GetValueOrDefault("forward", 0)
                   * (parsedInput.GetValueOrDefault("down", 0)
                      - parsedInput.GetValueOrDefault("up", 0)
                   );
        }
    }
}