using System.Collections.Generic;

namespace AdventOfCode.Common.Utilities.Bingo
{
    public class BingoCard
    {
        /// <summary>
        /// Storage for the bingocard cells.
        /// 
        /// Example:
        /// 0 | 1 2 3 4 5
        /// 1 | 6 7 8 9 0
        /// 2 | 1 2 3 4 5
        /// 3 | 6 7 8 9 0
        /// 4 | 1 2 3 4 5
        /// k   ...values
        /// </summary>
        public Dictionary<int, List<BingoCell>> Positions { get; set; } = new();
        
        /// <summary>
        /// The number which caused the bingocard to have a bingo.
        /// -1 implies 'not yet existing'
        /// </summary>
        public int WinningNumber { get; set; } = -1;

        /// <summary>
        /// Sum the numbers on the cells that have not been marked yet.
        /// </summary>
        /// <returns>The summed unmarked bingo cells.</returns>
        public int GetUnmarkedNumbersSum()
        {
            int count = 0;
            for (int i = 0; i < Positions.Count; i++)
            {
                for (int j = 0; j < Positions[i].Count; j++)
                {
                    if (!Positions[i][j].Marked)
                        count += Positions[i][j].Number;
                }
            }
            
            return count;
        }
        
        /// <summary>
        /// Check if the given position (row, column) has a 'bingo' either horizontally or vertically.
        /// </summary>
        /// <param name="row">The cell's row</param>
        /// <param name="column">The cell's column</param>
        /// <returns>Bool determining whether this cell is a winning position.</returns>
        public bool IsWinningPosition(int row, int column)
        {
            bool verticalWin = true;
            bool horizontalWin = true;

            for (int i = 0; i < Positions.Count; i++)
            {
                if (!Positions[i][column].Marked)
                    verticalWin = false;

                if (!Positions[row][i].Marked)
                    horizontalWin = false;
            }

            return horizontalWin || verticalWin;
        }

        /// <summary>
        /// Mark the given number if it exists on the board.
        /// </summary>
        /// <param name="num">The number to be marked on the board.</param>
        /// <returns>the position of the cell if it causes a bingo, otherwise (-1, -1)</returns>
        public (int, int) MarkPosition(int num)
        {
            for (int i = 0; i < Positions.Count; i++)
            {
                for (int j = 0; j < Positions[i].Count; j++)
                {
                    if (!Positions[i][j].Number.Equals(num)) continue;
                    
                    Positions[i][j].Marked = true;

                    if (!IsWinningPosition(i, j)) continue;
                    
                    WinningNumber = Positions[i][j].Number;
                    return (i, j);

                }
            }

            return (-1, -1);
        }
    }
}