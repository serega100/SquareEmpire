using NUnit.Framework;
using SquareEmpire.view;

namespace SquareEmpireTests
{
    public class CellLayoutTests
    {
        [TestCase(38, 32, 0, 0)]
        [TestCase(44, 33, 0, 0)]
        [TestCase(139, 136, 2, 2)]
        [TestCase(232, 172, 4, 3)]
        [TestCase(173, 427, 3, 8)]
        public void ShouldTransferScreenToCellCoordinates(int screenX, int screenY, int cellX, int cellY)
        {
            var layout = new CellLayout(50, 10, 10);
            var result = layout.GetCellCoordinates(screenX, screenY);
            Assert.IsNotNull(result);
            Assert.AreEqual(cellX, result.Value.X);
            Assert.AreEqual(cellY, result.Value.Y);
        }

        [TestCase(9, 9)]
        [TestCase(0, 0)]
        [TestCase(0, 30)]
        [TestCase(30, 0)]
        [TestCase(-10, -10)]
        public void ShouldReturnNullCell(int screenX, int screenY)
        {
            var layout = new CellLayout(50, 10, 10);
            var result = layout.GetCellCoordinates(screenX, screenY);
            Assert.IsNull(result);
        }
    }
}