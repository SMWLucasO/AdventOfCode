using System.Collections.Generic;

namespace AdventOfCode.Common.Utilities.Bingo
{
    public class BingoGame
    {
        /// <summary>
        /// The numbers to be used in the game (in order).
        /// </summary>
        public IList<int> BingoNumbers { get; set; }
            = new List<int>();

        /// <summary>
        /// The bingo cards in the game.
        /// </summary>
        public IList<BingoCard> BingoCards { get; set; }
            = new List<BingoCard>();

        /// <summary>
        /// The cards that have bingo'd (in order from first to last)
        /// </summary>
        public List<BingoCard> WinningCards { get; set; }
            = new List<BingoCard>();
        
        /// <summary>
        /// Mark the given number on all the bingo cards, if they have it.
        /// </summary>
        /// <param name="num">The number to be marked on the bingo cards.</param>
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

        /// <summary>
        /// Register a bingo card.
        /// </summary>
        /// <param name="cells">The cells to be inserted into the card.</param>
        public void RegisterBingoCard(BingoCell[][] cells)
        {
            var card = new BingoCard();
            for (int i = 0; i < cells.Length; i++) 
                card.Positions[i] = new List<BingoCell>(cells[i]);
            
            BingoCards.Add(card);
        }

        /// <summary>
        /// Register the numbers to be played during the game (in order of insertion)
        /// </summary>
        /// <param name="nums">The numbers to be added.</param>
        public void RegisterBingoNumbers(IEnumerable<int> nums)
        {
            foreach (var tmpNum in nums)
                BingoNumbers.Add(tmpNum);
        }

        /// <summary>
        /// Play the bingo game.
        /// </summary>
        public void Play()
        {
            foreach (var num in BingoNumbers) 
                MarkNumber(num);
        }
    }
}