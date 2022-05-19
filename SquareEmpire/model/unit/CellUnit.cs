using System;

namespace SquareEmpire.model.unit
{
    public abstract class CellUnit
    {
        public string ImageId { get; }

        protected CellUnit(string imageFileName)
        {
            ImageId = imageFileName;
        }
    }
}