using System;
using System.Diagnostics;
using System.Drawing;
using SquareEmpire.controller;

namespace SquareEmpire.view
{
    public class CellLayout : ICoordinatedCellLayout
    {
        private readonly int _cellSize;
        private readonly int _startX;
        private readonly int _startY;

        public CellLayout(int cellSize, int startX, int startY)
        {
            _cellSize = cellSize;
            _startX = startX;
            _startY = startY;
        }

        public Point? GetCellCoordinates(int viewX, int viewY)
        {
            if (viewX < _startX || viewY < _startY) return null;
            var cellX = Math.Floor((viewX - _startX) / Convert.ToDouble(_cellSize));
            var cellY = Math.Floor((viewY - _startY) / Convert.ToDouble(_cellSize));
            Debug.WriteLine($"Cell coords {cellX} {cellY}");
            return new Point(Convert.ToInt32(cellX), Convert.ToInt32(cellY));
        }

        public Rectangle GetCellRectangle(int cellX, int cellY)
        {
            var rectX = _startX + _cellSize * cellX;
            var rectY = _startY + _cellSize * cellY;
            return new Rectangle(rectX, rectY, _cellSize, _cellSize);
        }
    }
}