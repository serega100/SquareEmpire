using System.Drawing;

namespace SquareEmpire.models.unit
{
    public abstract class CellUnit
    {
        public Image Image { get; }

        protected CellUnit(Image image)
        {
            Image = image;
        }
    }
}