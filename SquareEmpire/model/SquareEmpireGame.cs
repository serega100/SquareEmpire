using System.Collections.Immutable;
using SquareEmpire.model.map;
using SquareEmpire.model.team;

namespace SquareEmpire.model
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
        
        // TODO: Create methods here
        
        // TODO: Create events here
    }
}