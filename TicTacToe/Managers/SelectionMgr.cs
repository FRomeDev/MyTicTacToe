using TicTacToe.Scenes.Selection;

namespace TicTacToe.Managers
{
    public class SelectionMgr
    {
        public TicTacToe TheSM { get; private set; }
        public Selection SG { get; private set; }
        private SelectionMgr()
        {
            SG = null;
        }
        public SelectionMgr(TicTacToe ticTacToe) : this()
        {
            TheSM = ticTacToe;

            SG = new Selection(this);
        }
        public void LoadContent()
        {
            SG.LoadContent();
        }
        public void Update()
        {
            SG.Update();
        }
        public void Draw()
        {
            SG.Draw();
        }
    }
}
