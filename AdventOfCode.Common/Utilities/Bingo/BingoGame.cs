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

        public BingoCard WinningCard { get; set; }

        public int CardIdIncrement { get; set; } = 0;

        public void MarkNumber(int num)
        {
            foreach (var bingoCard in BingoCards)
            {
                var (row, col) = bingoCard.MarkPosition(num);

                if (row == -1 || col == -1) continue;

                if (!bingoCard.IsWinningPosition(row, col)) continue;

                WinningCard = bingoCard;
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
            {
                if (WinningCard != null)
                    break;

                MarkNumber(num);
            }
        }

        public BingoCard PlayToLose()
        {
            BingoCard recentWin = null;
            foreach (var num in BingoNumbers)
            {
                if (WinningCard != null)
                {
                    recentWin = WinningCard;

                    BingoCards.Remove(WinningCard);
                    WinningCard = null;
                }

                MarkNumber(num);
            }

            return recentWin;
        }
    }
}