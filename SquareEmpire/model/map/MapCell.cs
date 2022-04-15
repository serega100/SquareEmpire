using SquareEmpire.models.team;
using SquareEmpire.models.unit;

namespace SquareEmpire.models.map
{
    public class MapCell
    {
        public CellUnit? Unit { get; set; }
        public Team Owner { get; set; }

        public MapCell(CellUnit? unit, Team? owner)
        {
            Unit = unit;
            Owner = owner;
        }
    }
}