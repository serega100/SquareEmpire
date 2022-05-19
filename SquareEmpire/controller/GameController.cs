using System.Diagnostics;
using System.Drawing;
using SquareEmpire.model;

namespace SquareEmpire.controller
{
    public class GameController
    {
        private readonly SquareEmpireGame _game;
        private readonly ICoordinatedCellLayout _layout;
        public GameController(SquareEmpireGame game, ICoordinatedCellLayout layout)
        {
            _game = game;
            _layout = layout;
        }
        
        public void HandleClick(int viewX, int viewY)
        {
            var cellCoordinates = _layout.GetCellCoordinates(viewX, viewY);
            if (cellCoordinates == null)
            {
                Debug.WriteLine("Cell coordinates is null");
                return;
            }
            var cell = _game.GetCell((Point) cellCoordinates);
            if (cell == null)
            {
                Debug.WriteLine("Cell object is null");
                return;
            }
            Debug.WriteLine($"Selecting cell {cellCoordinates.Value.X} {cellCoordinates.Value.Y}");
            _game.SelectCell((Point) cellCoordinates);
        }
    }
}