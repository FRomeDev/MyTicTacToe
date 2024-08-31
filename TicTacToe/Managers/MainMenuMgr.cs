
using TicTacToe.Scenes.MainMenu;

namespace TicTacToe.Managers
{
    public class MainMenuMgr
    {
        public TicTacToe TheMenu { get; private set; }
        public MainMenu MM { get; private set; }
        private MainMenuMgr()
        {
            MM = null;
        }
        public MainMenuMgr(TicTacToe ticTacToe) : this()
        { 
            TheMenu = ticTacToe;

            MM = new MainMenu(this);
        }
        public void LoadContent()
        {
            MM.LoadContent();
        }
        public void Update()
        {
            MM.Update();
        }
        public void Draw()
        {
            MM.Draw();
        }
    }
}
