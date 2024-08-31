using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using TicTacToe.Managers;

namespace TicTacToe.Scenes.Options
{
    public class Options
    {
        readonly OptionsMgr options;
        TicTacToe TheOptions => options.TheOptions;

        private Texture2D panelTexture;
        private Texture2D applyText, backText;
        private Rectangle applyRect, backRect;

        private Texture2D off, on;
        private Texture2D offAndOnText;
        private Rectangle offAndOnRect;

        //aux
        private bool OaOToggle;

        public MouseState mouseState;
        public MouseState previousMouseState;
        public Options(OptionsMgr options)
        {
            this.options = options;          
        }
        public void LoadContent()
        {
            panelTexture = TheOptions.Content.Load<Texture2D>("OptionsSprites/OptionsPanel");

            off = TheOptions.Content.Load<Texture2D>("OptionsSprites/Off");
            on = TheOptions.Content.Load<Texture2D>("OptionsSprites/On");
            offAndOnText = TheOptions.Content.Load<Texture2D>("OptionsSprites/off"); 
            offAndOnRect = new Rectangle(600, 227, offAndOnText.Width, offAndOnText.Height);

            applyText = TheOptions.Content.Load<Texture2D>("OptionsSprites/apply");
            applyRect = new Rectangle(464, 511, applyText.Width, applyText.Height);
            backText = TheOptions.Content.Load<Texture2D>("OptionsSprites/back");
            backRect = new Rectangle(653, 511, backText.Width, backText.Height);
        }
        void ButtonOpLogic()
        {
            // apply button
            if (previousMouseState.LeftButton == ButtonState.Pressed && mouseState.LeftButton == ButtonState.Released
                && applyRect.Contains(mouseState.Position))
            {               
                if (OaOToggle == true)
                {
                Globals.FullScreen = true;
                
                }
                else
                {
                Globals.Windowed = true;

                }
            }

            // Back button
            if (previousMouseState.LeftButton == ButtonState.Pressed && mouseState.LeftButton == ButtonState.Released
                && backRect.Contains(mouseState.Position))
            {
                if (Globals.MainMenuOrGame == 1)
                {
                    Globals.MainMenu = true;
                }
                if (Globals.MainMenuOrGame == 2)
                {
                    Globals.Game = true;
                }
            }
        }
        void OffAndOnL()
        {
            // button off and on fullscreem
            if (previousMouseState.LeftButton == ButtonState.Pressed && mouseState.LeftButton == ButtonState.Released
                && offAndOnRect.Contains(mouseState.Position))
            {                
                if (OaOToggle)
                {
                    OaOToggle = false;
                }
                else
                {
                    OaOToggle = true;
                }
            }
        }
        public void Update()
        {
            previousMouseState = mouseState;
            mouseState = Mouse.GetState();
            ButtonOpLogic();
            OffAndOnL();
        }
        void OffAndOnDraw()
        {

            if (OaOToggle)
            {
              Globals.SpriteBatch.Draw(on, offAndOnRect, Color.White);
            }
            else
            {
              Globals.SpriteBatch.Draw(off, offAndOnRect, Color.White);
            }
        }
        public void Draw()
        {
            Globals.SpriteBatch.Draw(panelTexture, new Vector2(442, 162), Color.White);
          
            Globals.SpriteBatch.Draw(applyText, applyRect, Color.White);
            Globals.SpriteBatch.Draw(backText, backRect, Color.White);
            OffAndOnDraw();
        }
    }
}
