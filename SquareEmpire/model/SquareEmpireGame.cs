using System;
using System.Collections.Immutable;
using System.Drawing;
using SquareEmpire.model.team;

namespace SquareEmpire.model
{
    public class SquareEmpireGame
    {
        public ImmutableList<Team> Teams { get; }
        public MapCell?[,] Cells { get; }
        public Point? SelectedCellLocation { get; private set; }

        public SquareEmpireGame(MapCell?[,] cells, ImmutableList<Team> teams)
        {
            Cells = cells;
            Teams = teams;
        }

        public MapCell? GetCell(Point coordinates)
        {
            var cellX = coordinates.X;
            var cellY = coordinates.Y;
            var lenX = Cells.GetLength(0);
            var lenY = Cells.GetLength(1);
            if (cellX < 0 || cellY < 0 || cellX >= lenX || cellY >= lenY)
            {
                return null;
            }

            return Cells[cellX, cellY];
        }
        
        // TODO: Create methods here
        public void SelectCell(Point cellLocation)
        {
            SelectedCellLocation = cellLocation;
            OnSelectCell();
        }
        
        // TODO: Create events here
        public event Action OnSelectCell;
    }
}