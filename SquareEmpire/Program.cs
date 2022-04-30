using System;
using System.Windows.Forms;
using SquareEmpire.model.generator;
using SquareEmpire.view;

namespace SquareEmpire
{
    static class Program
    {
        private static IGameGenerator _gameGenerator = new TestGameGenerator();
        
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // Application.Run(new MainForm());
            Application.Run(new GameForm(_gameGenerator.GenerateGameMap()));
        }

        private static void RunMainView()
        {
            
        }
    }
}