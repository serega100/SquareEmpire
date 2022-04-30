using System.Drawing;
using System.Windows.Forms;
using SquareEmpire.model;

namespace SquareEmpire.view
{
    public class GameDrawer : IPaintDrawer
    {
        private readonly Form _form;
        private readonly SquareEmpireGame _game;

        public GameDrawer(Form form, SquareEmpireGame game)
        {
            _form = form;
            _game = game;
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
            
                var cellRectangle = new Rectangle(10 + 50 * cellX, 10 + 50 * cellY, 50, 50);
                if (cell.Owner != null) graphics.FillRectangle(new SolidBrush(cell.Owner.Color), cellRectangle);
                if (cell.Unit != null)
                {
                    var unitRectangle = GetRectangleWithPadding(cellRectangle, 5);
                    graphics.DrawImage(cell.Unit.Image, unitRectangle);
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