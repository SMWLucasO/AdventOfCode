using AdventOfCode.Common.Utilities;
using AdventOfCode.Common.Utilities.Bingo;

namespace AdventOfCode.Days.Day4
{
    public static class GiantSquid
    {
        public static int Solution(string[] input)
        {
            var game = new BingoGame();

            RegisterBingoData(input, game);

            game.Play();

            return game.WinningCards[0].GetUnmarkedNumbersSum() * game.WinningCards[0].WinningNumber;
        }

        public static int SolutionPartTwo(string[] input)
        {
            var game = new BingoGame();

            RegisterBingoData(input, game);

            game.Play();

            return game.WinningCards[99].GetUnmarkedNumbersSum() * game.WinningCards[99].WinningNumber;
        }

        private static void RegisterBingoData(string[] input, BingoGame game)
        {
            // register the bingo numbers
            game.RegisterBingoNumbers(InputUtility.SplitLine(input[0], ',', int.Parse));

            InputUtility.FileInputToMultidimensionalArrays(input[1..],
                s => s.Length < 10,
                s => s.Split(' '),
                s => new BingoCell(int.Parse(s.Trim()))
            ).ForEach(game.RegisterBingoCard);
        }
    }
}