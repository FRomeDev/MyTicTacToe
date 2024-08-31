using TicTacToe.Scenes.OptionsExit;

namespace TicTacToe.Managers
{
    public class OptionExitMgr
    {
        public TicTacToe TheExit { get; private set; }
        public OptionExit EX { get; private set; }
        private OptionExitMgr()
        {
            EX = null;
        }
        public OptionExitMgr(TicTacToe ticTacToe) : this()
        {
            TheExit = ticTacToe;

            EX = new OptionExit(this);
        }
        public void LoadContent()
        {
            EX.LoadContent();
        }
        public void Update()
        {
            EX.Update();
        }
        public void Draw()
        {
            EX.Draw();
        }
    }
}
