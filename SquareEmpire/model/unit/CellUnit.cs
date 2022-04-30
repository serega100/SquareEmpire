using System.Drawing;
using SquareEmpire.model.image;

namespace SquareEmpire.model.unit
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