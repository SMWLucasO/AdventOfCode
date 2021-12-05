namespace AdventOfCode.Common.Utilities.Geometries
{
    public class Point
    {
        
        /// <summary>
        /// The x-coordinate of the point.
        /// </summary>
        public int X { get; set; }
        
        /// <summary>
        /// The y-coordinate of the point.
        /// </summary>
        public int Y { get; set; }

        public Point(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
        
        /// <summary>
        /// Get the point as a tuple (x, y)
        /// </summary>
        /// <returns>(x, y)</returns>
        public (int, int) AsTuple()
            => (X, Y);

    }
}