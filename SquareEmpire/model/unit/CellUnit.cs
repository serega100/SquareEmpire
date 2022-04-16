using System.Drawing;
using SquareEmpire.models.map.image;

namespace SquareEmpire.models.unit
{
    public abstract class CellUnit
    {
        public Image Image { get; }

        protected CellUnit(string imageFileName)
        {
            Image = UnitImages.Get(imageFileName);
        }
    }
}