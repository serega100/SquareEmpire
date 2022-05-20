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
            var cell = cellCoordinates != null ? _game.GetCell(cellCoordinates.Value) : null;

            if (cellCoordinates == null || cell?.Owner == null || !cell.Owner.Equals(_game.PlayerTeam))
            {
                _game.UnselectCell();
                return;
            }
            
            _game.SelectCell((Point) cellCoordinates);
        }
    }
}