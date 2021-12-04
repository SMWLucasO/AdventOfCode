using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Common.Utilities.Bingo
{
    public class BingoGame
    {
        public IList<int> BingoNumbers { get; set; }
            = new List<int>();

        public IList<BingoCard> BingoCards { get; set; }
            = new List<BingoCard>();

        public List<BingoCard> WinningCards { get; set; }
            = new List<BingoCard>();

        public int CardIdIncrement { get; set; } = 0;

        public void MarkNumber(int num)
        {
            List<BingoCard> cardsToRemove = new();
            foreach (var bingoCard in BingoCards)
            {
                var (row, col) = bingoCard.MarkPosition(num);
                if (row == -1 && col == -1) continue;

                cardsToRemove.Add(bingoCard);
            }

            foreach (var toRemove in cardsToRemove)
            {
                BingoCards.Remove(toRemove);
                WinningCards.Add(toRemove);
            }
            
        }

        public void RegisterBingoCard(string[][] nums)
        {
            var card = new BingoCard() {CardId = CardIdIncrement++};
            for (int i = 0; i < nums.Length; i++)
            {
                if (!card.Positions.ContainsKey(i))
                    card.Positions[i] = new List<BingoCell>();

                for (int j = 0; j < nums[i].Length; j++)
                {
                    if (nums[i][j].Length <= 0) continue;

                    card.Positions[i].Add(new BingoCell(nums[i][j]));
                }
            }

            BingoCards.Add(card);
        }

        public void RegisterBingoNumbers(IEnumerable<string> nums)
        {
            foreach (var tmpNum in nums)
                BingoNumbers.Add(int.Parse(tmpNum));
        }

        public void Play()
        {
            foreach (var num in BingoNumbers) 
                MarkNumber(num);
        }
    }
}