using System.Windows.Forms;
using SquareEmpire.model;
using SquareEmpire.view;

namespace SquareEmpire
{
    public partial class GameForm : Form
    {
        private readonly GameDrawer _gameDrawer;

        public GameForm(SquareEmpireGame game)
        {
            _gameDrawer = new GameDrawer(this, game);
            // Click += OnClickEvent;
            // TODO: Create controller in specific folder
            // TODO: Subscribe on events here
        }

        protected override void OnPaint(PaintEventArgs args)
        {
            _gameDrawer.Paint(args);
        }
    }
}