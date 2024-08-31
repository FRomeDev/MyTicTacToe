using TicTacToe.Scenes.Game;

namespace TicTacToe.Managers
{
    public class GameMgr
    {
        public TicTacToe TheGame { get; private set; }
        public Game GM { get; private set; }
        private GameMgr()
        {
            GM = null;
        }
        public GameMgr(TicTacToe ticTacToe) : this()
        {
            TheGame = ticTacToe;

            GM = new Game(this);
        }
        public void LoadContent()
        {
            GM.LoadContent();
        }
        public void Update()
        {
            GM.Update();
        }
        public void Draw()
        {
            GM.Draw();
        }
    }
}
