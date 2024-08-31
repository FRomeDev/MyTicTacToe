using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using TicTacToe.Managers;

namespace TicTacToe.Scenes.MainMenu
{
    public class MainMenu
    {
        readonly MainMenuMgr mainMenu;
        TicTacToe TheMenu => mainMenu.TheMenu;
        private Texture2D buttonTex1, buttonTex2, buttonTex3, buttonTex4;
        private Rectangle buttonRect1, buttonRect2, buttonRect3, buttonRect4;

        private Color shadebuttonM1 = Color.White, shadebuttonM2 = Color.White, shadebuttonM3 = Color.White,
                      shadebuttonM4 = Color.White;

        public MouseState mouseState;
        public MouseState previousMouseState;

        //aux
        public MainMenu(MainMenuMgr mainMenu)
        {
            this.mainMenu = mainMenu;
        }
        public void LoadContent()
        {
            buttonTex1 = TheMenu.Content.Load<Texture2D>("MainMenuSprites/start");
            buttonRect1 = new Rectangle(567, 470, buttonTex1.Width, buttonTex1.Height);
            buttonTex2 = TheMenu.Content.Load<Texture2D>("MainMenuSprites/options");
            buttonRect2 = new Rectangle(567, 527, buttonTex2.Width, buttonTex2.Height);
            buttonTex3 = TheMenu.Content.Load<Texture2D>("MainMenuSprites/credits");
            buttonRect3 = new Rectangle(567, 584, buttonTex3.Width, buttonTex3.Height);
            buttonTex4 = TheMenu.Content.Load<Texture2D>("MainMenuSprites/exit");
            buttonRect4 = new Rectangle(567, 640, buttonTex4.Width, buttonTex4.Height);
        }
        void ButtonMMLogic()
        {
            //button start    

            if (previousMouseState.LeftButton == ButtonState.Pressed && mouseState.LeftButton == ButtonState.Released
                && buttonRect1.Contains(mouseState.Position))
            {
                Globals.PressSelection = true;
            }

            //dark button logic

            if (mouseState.LeftButton == ButtonState.Pressed && buttonRect1.Contains(mouseState.Position))
            {
                shadebuttonM1 = Color.DarkGray;
            }
            else
            {
                shadebuttonM1 = Color.White;
            }

            //button options

            if (previousMouseState.LeftButton == ButtonState.Pressed && mouseState.LeftButton == ButtonState.Released
                && buttonRect2.Contains(mouseState.Position))
            {
                Globals.MainMenuOrGame = 1;
                Globals.PressOptions = true;
            }

            //dark button logic

            if (mouseState.LeftButton == ButtonState.Pressed && buttonRect2.Contains(mouseState.Position))
            {
                shadebuttonM2 = Color.DarkGray;
            }
            else
            {
                shadebuttonM2 = Color.White;
            }

            //button credits

            if (previousMouseState.LeftButton == ButtonState.Pressed && mouseState.LeftButton == ButtonState.Released
                && buttonRect3.Contains(mouseState.Position))
            {
                //in progress
            }

            //dark button logic

            if (mouseState.LeftButton == ButtonState.Pressed && buttonRect3.Contains(mouseState.Position))
            {
                shadebuttonM3 = Color.DarkGray;
            }
            else
            {
                shadebuttonM3 = Color.White;
            }

            //button exit

            if (previousMouseState.LeftButton == ButtonState.Pressed && mouseState.LeftButton == ButtonState.Released
                && buttonRect4.Contains(mouseState.Position))
            {
                Globals.PressExit = true;
            }

            //dark button logic

            if (mouseState.LeftButton == ButtonState.Pressed && buttonRect4.Contains(mouseState.Position))
            {
                shadebuttonM4 = Color.DarkGray;
            }
            else
            {
                shadebuttonM4 = Color.White;
            }
        }
        public void Update()
        {
            previousMouseState = mouseState;
            mouseState = Mouse.GetState();

            ButtonMMLogic();

        }
        public void Draw()
        {

            Globals.SpriteBatch.Draw(buttonTex1, buttonRect1, shadebuttonM1);
            Globals.SpriteBatch.Draw(buttonTex2, buttonRect2, shadebuttonM2);
            Globals.SpriteBatch.Draw(buttonTex3, buttonRect3, shadebuttonM3);
            Globals.SpriteBatch.Draw(buttonTex4, buttonRect4, shadebuttonM4);

        }
    }
}
