namespace AdventOfCode.Common.Utilities.Bingo
{
    public class BingoCell
    {
        /// <summary>
        /// Checker for whether the cell was marked as 'set'.
        /// </summary>
        public bool Marked { get; set; } = false;

        /// <summary>
        /// The number contained in the bingo cell.
        /// </summary>
        public int Number { get; }

        public BingoCell(int number)
            => Number = number;
    }
}