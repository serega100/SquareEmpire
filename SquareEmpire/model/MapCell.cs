using SquareEmpire.model.team;
using SquareEmpire.model.unit;

namespace SquareEmpire.model
{
    public class MapCell
    {
        public CellUnit? Unit { get; set; }
        public Team? Owner { get; set; }

        public MapCell(CellUnit? unit, Team? owner)
        {
            Unit = unit;
            Owner = owner;
        }
    }
}