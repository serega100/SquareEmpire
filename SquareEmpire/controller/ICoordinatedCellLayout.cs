using System.Drawing;

namespace SquareEmpire.controller
{
    public interface ICoordinatedCellLayout
    {
        /// <summary>
        /// Transfer UI coordinates to game cell coordinates
        /// </summary>
        /// <param name="viewX">X-coordinate on UI</param>
        /// <param name="viewY">Y-coordinate on UI</param>
        /// <returns>Cell coordinates or null if it's not inside layout bounds</returns>
        Point? GetCellCoordinates(int viewX, int viewY);
    }
}