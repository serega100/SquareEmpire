using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Drawing;
using SquareEmpire.model.team;

namespace SquareEmpire.model
{
    public class SquareEmpireGame
    {
        public ImmutableList<Team> Teams { get; }
        public Team PlayerTeam { get; }
        public MapCell?[,] Cells { get; }
        public Point? SelectedCellLocation { get; private set; }
        public ImmutableList<Point>? AvailableMoveLocations { get; private set; }

        public SquareEmpireGame(MapCell?[,] cells, ImmutableList<Team> teams, Team playerTeam)
        {
            if (!teams.Contains(playerTeam))
            {
                throw new ArgumentException("Teams must contain playerTeam!");
            }
            
            Cells = cells;
            Teams = teams;
            PlayerTeam = playerTeam;
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

        public void SelectCell(Point cellLocation)
        {
            var selectedCell = GetCell(cellLocation);
            if (selectedCell == null) throw new ArgumentException("Cell location does not exist on layout.");
            if (selectedCell.Owner == null || !selectedCell.Owner.Equals(PlayerTeam)) 
                throw new ArgumentException("Selected cell must belong to user");

            SelectedCellLocation = cellLocation;

            var moveLocations = new List<Point>();
            for (var dx = -1; dx <= 1; dx++)
            for (var dy = -1; dy <= 1; dy++)
            {
                if (dx == 0 && dy == 0) continue;
                var nearPoint = new Point(cellLocation.X + dx, cellLocation.Y + dy);
                var nearCell = GetCell(nearPoint);
                if (nearCell == null) continue;
                if (nearCell.Unit != null && nearCell.Owner != null && nearCell.Owner.Equals(PlayerTeam)) continue;
                moveLocations.Add(nearPoint);
            }

            AvailableMoveLocations = moveLocations.ToImmutableList();
            OnSelectCell();
        }

        public void UnselectCell()
        {
            SelectedCellLocation = null;
            AvailableMoveLocations = null;
            OnUnselectCell();
        }

        public event Action OnSelectCell;
        public event Action OnUnselectCell;
    }
}