using System.Drawing;
using System.Windows.Forms;
using SquareEmpire.controller;
using SquareEmpire.model;

namespace SquareEmpire.view
{
    public class DefaultGameDrawer : IGameDrawer
    {
        private static readonly Color SelectedColor = Color.Yellow;
        private static readonly Color AvailableMoveColor = Color.Orange;
        private static readonly Pen CellBorderPen = new Pen(Color.Black, 3);

        private readonly Form _form;
        private readonly SquareEmpireGame _game;
        private readonly AssetsHolder _assets;
        private readonly CellLayout _cellLayout;

        public DefaultGameDrawer(Form form, SquareEmpireGame game)
        {
            _form = form;
            _game = game;
            _assets = new AssetsHolder();
            _cellLayout = new CellLayout(50, 10, 10);

            _game.OnSelectCell += _form.Invalidate;
            _game.OnUnselectCell += _form.Invalidate;
        }

        public ICoordinatedCellLayout GetCellLayout()
        {
            return _cellLayout;
        }

        public void Paint(PaintEventArgs args)
        {
            var graphics = args.Graphics;

            for (var cellX = 0; cellX < _game.Cells.GetLength(0); cellX++)
            for (var cellY = 0; cellY < _game.Cells.GetLength(1); cellY++)
            {
                var cell = _game.Cells[cellX, cellY];
                if (cell == null) continue;
                DrawCell(graphics, cell, cellX, cellY);
            }
        }

        private void DrawCell(Graphics graphics, MapCell cell, int cellX, int cellY)
        {
            var cellLocation = new Point(cellX, cellY);
            var cellRectangle = _cellLayout.GetCellRectangle(cellLocation.X, cellLocation.Y);
            if (_game.SelectedCellLocation != null && _game.SelectedCellLocation.Equals(cellLocation))
            {
                graphics.FillRectangle(new SolidBrush(SelectedColor), cellRectangle);
            }
            else if (_game.AvailableMoveLocations != null && _game.AvailableMoveLocations.Contains(cellLocation))
            {
                graphics.FillRectangle(new SolidBrush(AvailableMoveColor), cellRectangle);
            }
            else if (cell.Owner != null)
            {
                graphics.FillRectangle(new SolidBrush(cell.Owner.Color), cellRectangle);
            }
            
            if (cell.Unit != null)
            {
                var unitRectangle = GetRectangleWithPadding(cellRectangle, 5);
                graphics.DrawImage(_assets.GetImage(cell.Unit.ImageId), unitRectangle);
            }

            graphics.DrawRectangle(CellBorderPen, cellRectangle);
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