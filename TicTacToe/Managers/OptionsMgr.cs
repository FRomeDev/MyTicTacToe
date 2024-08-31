using TicTacToe.Scenes.Options;

namespace TicTacToe.Managers
{
    public class OptionsMgr
    {
        public TicTacToe TheOptions { get; private set; }
        public Options OP { get; private set; }
        private OptionsMgr()
        {
            OP = null;
        }
        public OptionsMgr(TicTacToe ticTacToe) : this()
        {
            TheOptions = ticTacToe;

            OP = new Options(this);
        }
        public void LoadContent()
        {
            OP.LoadContent();
        }
        public void Update()
        {
            OP.Update();
        }
        public void Draw()
        {
            OP.Draw();
        }
    }
}
