using AdventOfCode.Common.Utilities.Geometries;
using NUnit.Framework;

namespace AdventOfCode.Common.Tests.Utilities.Geometries
{
    [TestFixture]
    public class LineTests
    {


        [TestCase(0,0,5,5,1,0)]
        [TestCase(0,0,5,10,2,0)]
        public void Line_LinePointSlope_ReturnsProperValue(int x1, int y1, int x2, int y2, double slope, double point)
        {
            var line = new Line((x1, y1), (x2, y2));

            Assert.AreEqual(slope, line.GetSlope());

            var (lSlope, lPoint) = line.GetPointSlope();
            
            Assert.AreEqual(slope, lSlope);
            Assert.AreEqual(point, lPoint);
        }
        
        [Test]
        public void Lines_LinesIntersect_ReturnsTrue()
        {
            var line1 = new Line(new Point(0, 0), new Point(10, 10));
            var line2 = new Line(new Point(0, 0), new Point(20, 20));
            
            Assert.IsTrue(line1.Intersects(line2));
        }
        
    }
}