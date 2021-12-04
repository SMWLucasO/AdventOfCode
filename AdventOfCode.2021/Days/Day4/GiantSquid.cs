using System;
using System.Collections.Generic;
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

            return game.WinningCard.GetUnmarkedNumbersSum() * game.WinningCard.WinningNumber;
        }

        private static void RegisterBingoData(string[] input, BingoGame game)
        {
            // register the bingo numbers
            game.RegisterBingoNumbers(input[0].Split(','));

            var cardContents = new List<string[]>();
            for (int i = 2; i < input.Length; i++)
            {
                // close enough, we weten iig dat een row >10 chars heeft.
                if (input[i].Length < 10)
                {
                    game.RegisterBingoCard(cardContents.ToArray());
                    cardContents.Clear();
                }
                else
                    cardContents.Add(input[i].Trim().Split(' '));
            }
            
            game.RegisterBingoCard(cardContents.ToArray());
        }

        public static int SolutionPartTwo(string[] input)
        {
            // works on test input, but not on true input
            
            var game = new BingoGame();
            
            RegisterBingoData(input, game);

            BingoCard card = game.PlayToLose();

            return card.WinningNumber * card.GetUnmarkedNumbersSum();
        }
        
    }
}