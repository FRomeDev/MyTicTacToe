using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using TicTacToe.Managers;

namespace TicTacToe.Scenes.OptionsExit
{
    public class OptionExit
    {
        readonly OptionExitMgr optionsExit;
        TicTacToe TheExit => optionsExit.TheExit;

        private Texture2D exitButtonT1, exitButtonT2;
        private Rectangle exitButtonR1, exitButtonR2;

        private Texture2D exitPanel;
        public MouseState mouseState;
        public MouseState previousMouseState;
        public OptionExit(OptionExitMgr optionsExit)
        {
            this.optionsExit = optionsExit;
        }
        public void LoadContent()
        {
            exitButtonT1 = TheExit.Content.Load<Texture2D>("ExitSprites/no");
            exitButtonR1 = new Rectangle(482, 400, exitButtonT1.Width, exitButtonT1.Height);
            exitButtonT2 = TheExit.Content.Load<Texture2D>("ExitSprites/yes");
            exitButtonR2 = new Rectangle(666, 400, exitButtonT2.Width, exitButtonT2.Height);

            exitPanel = TheExit.Content.Load<Texture2D>("ExitSprites/exitgamepanel");
        }
        void ButtonExLogic()
        {
            previousMouseState = mouseState;
            mouseState = Mouse.GetState();
            //button no
            if (previousMouseState.LeftButton == ButtonState.Pressed && mouseState.LeftButton == ButtonState.Released
                && exitButtonR1.Contains(mouseState.Position))
            {
                Globals.MainMenu = true;
            }
            //button yes
            if (previousMouseState.LeftButton == ButtonState.Pressed && mouseState.LeftButton == ButtonState.Released
                && exitButtonR2.Contains(mouseState.Position))
            {
                Globals.Exit = true;
            }
        }
        public void Update()
        {
            ButtonExLogic();
        }
        public void Draw()
        {
            Globals.SpriteBatch.Draw(exitPanel, new Vector2(454, 283), Color.White);
            Globals.SpriteBatch.Draw(exitButtonT1, exitButtonR1, Color.White);
            Globals.SpriteBatch.Draw(exitButtonT2, exitButtonR2, Color.White);
        }
    }
}

