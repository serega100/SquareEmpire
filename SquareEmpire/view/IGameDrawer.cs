using System.Windows.Forms;
using SquareEmpire.controller;

namespace SquareEmpire.view
{
    public interface IGameDrawer
    {
        public void Paint(PaintEventArgs args);
        public ICoordinatedCellLayout GetCellLayout();
    }
}