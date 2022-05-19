using System;
using System.Drawing;
using System.Windows.Forms;
using SquareEmpire.controller;
using SquareEmpire.model;

namespace SquareEmpire.view
{
    public class DefaultGameDrawer : IGameDrawer
    {
        private static readonly Color SelectedColor = Color.Yellow;
        
        private readonly Form _form;
        private readonly SquareEmpireGame _game;
        private readonly AssetsHolder _assets;
        private readonly CellLayout _cellLayout;

        public DefaultGameDrawer(Form form,SquareEmpireGame game)
        {
            _form = form;
            _game = game;
            _assets = new AssetsHolder();
            _cellLayout = new CellLayout(50, 10, 10);

            _game.OnSelectCell += _form.Invalidate;
        }
        
        public ICoordinatedCellLayout GetCellLayout()
        {
            return _cellLayout;
        }

        public void Paint(PaintEventArgs args)
        {
            var graphics = args.Graphics;
            var drawPen = new Pen(Color.Black, 3);

            for (var cellX = 0; cellX < _game.Cells.GetLength(0); cellX++)
            for (var cellY = 0; cellY < _game.Cells.GetLength(1); cellY++)
            {
                var cell = _game.Cells[cellX, cellY];
                if (cell == null) continue;
            
                var cellRectangle = _cellLayout.GetCellRectangle(cellX, cellY);
                if (_game.SelectedCellLocation.Equals(new Point(cellX, cellY)))
                {
                    graphics.FillRectangle(new SolidBrush(SelectedColor), cellRectangle);
                } else if (cell.Owner != null)
                {
                    graphics.FillRectangle(new SolidBrush(cell.Owner.Color), cellRectangle);
                }
                if (cell.Unit != null)
                {
                    var unitRectangle = GetRectangleWithPadding(cellRectangle, 5);
                    graphics.DrawImage(_assets.GetImage(cell.Unit.ImageId), unitRectangle);
                }
                graphics.DrawRectangle(drawPen, cellRectangle);
            }
        }

        private static Rectangle GetRectangleWithPadding(Rectangle rectangle, int padding)
        {
            var newWidth = rectangle.Width - padding * 2;
            var newHeight = rectangle.Height - padding * 2;
            var newX = rectangle.X + padding;
            var newY = rectangle.Y + padding;
            return new Rectangle(newX, newY, newWidth, newHeight);
        }
    }
}