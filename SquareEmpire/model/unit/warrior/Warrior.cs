using System.Drawing;

namespace SquareEmpire.models.unit.warrior
{
    public abstract class Warrior : CellUnit
    {
        // todo add warrior price
        protected Warrior(string imageFileName) : base(imageFileName)
        {
        }
    }
}