using System.Diagnostics;
using System.Windows.Forms;
using SquareEmpire.controller;
using SquareEmpire.model;
using SquareEmpire.model.generator;
using SquareEmpire.view;

namespace SquareEmpire
{
    public partial class GameForm : Form
    {
        private readonly IGameGenerator _gameGenerator;
        private readonly SquareEmpireGame _game;
        private readonly IGameDrawer _gameDrawer;
        private readonly GameController _gameController;
        

        public GameForm()
        {
            _gameGenerator = new TestGameGenerator();
            _game = _gameGenerator.GenerateGame();
            _gameDrawer = new DefaultGameDrawer(this, _game);
            _gameController = new GameController(_game, _gameDrawer.GetCellLayout());
            
            BindControlMouseClicks(this);
        }
        
        private void BindControlMouseClicks(Control con)
        {
            con.MouseClick += TriggerMouseClicked;
            // bind to controls already added
            foreach (Control i in con.Controls)
            {
                BindControlMouseClicks(i);
            }
            // bind to controls added in the future
            con.ControlAdded += delegate(object sender, ControlEventArgs e)
            {
                BindControlMouseClicks(e.Control);
            };            
        }
        
        private void TriggerMouseClicked(object sender, MouseEventArgs args)
        {
            Debug.WriteLine($"Clicked on {args.X} {args.Y}");
            _gameController.HandleClick(args.X, args.Y);
        }
        
        protected override void OnPaint(PaintEventArgs args)
        {
            _gameDrawer.Paint(args);
        }
    }
}