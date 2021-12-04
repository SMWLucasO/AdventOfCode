using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Common.Fluent.Collections;

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
        
        public int WinningNumber { get; set; } = -1;

        public int CardId { get; set; } = 0;
        
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