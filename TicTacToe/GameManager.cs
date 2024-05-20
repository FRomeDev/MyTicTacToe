namespace TicTacToe
{
    public class GameManager
    {
        public TicTacToe TheGame { get; private set; }
        public GameIO IO { get; private set; }
        private GameManager()
        {
            IO = null;
        }
        public GameManager(TicTacToe ticTacToe) : this()
        {
            this.TheGame = ticTacToe;

            IO = new GameIO(this);
        }
        public void LoadContent()
        {
            IO.LoadContent();
        }
        public void Update()
        {
            IO.Update();
        }
        public void Draw()
        {
            IO.Draw();
        }
    }
}
