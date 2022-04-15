using System.Collections.Immutable;
using SquareEmpire.models.team;

namespace SquareEmpire.models.map
{
    public class SquareEmpireGame
    {
        public ImmutableList<Team> Teams { get; }
        public MapCell?[,] Cells { get; }

        public SquareEmpireGame(MapCell?[,] cells, ImmutableList<Team> teams)
        {
            Cells = cells;
            Teams = teams;
        }
    }
}