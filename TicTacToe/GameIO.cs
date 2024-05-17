using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace TicTacToe
{
    public class GameIO
    {
        GameManager gameManager;
        TicTacToe TheGame => gameManager.TheGame;
        private Texture2D _backgroundTexture;
        private Texture2D xImage;
        private Texture2D oImage;
        private Texture2D xMiniImage;
        private Texture2D oMiniImage;
        private Texture2D drawImage;
        private SpriteFont interfaceFont;
        private SpriteFont buttonFont;
        private Texture2D buttonDefault;
        //texture and Rectangle of buttons for gameplay
        private Texture2D buttonGpTexture1, buttonGpTexture2, buttonGpTexture3, buttonGpTexture4, buttonGpTexture5,
            buttonGpTexture6, buttonGpTexture7, buttonGpTexture8, buttonGpTexture9, bInterfaceTexture, bInterfaceTexture2;

        private Rectangle buttonGpRectangle1, buttonGpRectangle2, buttonGpRectangle3, buttonGpRectangle4,
            buttonGpRectangle5, buttonGpRectangle6, buttonGpRectangle7, buttonGpRectangle8, buttonGpRectangle9,
            bRoundsRectangle, bResetRectangle;

        private bool players;
        private bool winner;
        //aux:
        private bool onePointW;
        private bool onePointD;
        private int textureCount = 0;
        //score:
        private int winsPX = 0;
        private int winsPO = 0;
        private int drawP = 0;
        public GameIO(GameManager gameManager)
        {
            this.gameManager = gameManager;
            _backgroundTexture = TheGame.Content.Load<Texture2D>("Background");
            interfaceFont = TheGame.Content.Load<SpriteFont>("InterfaceF");
            buttonFont = TheGame.Content.Load<SpriteFont>("ButtonFont");
            oImage = TheGame.Content.Load<Texture2D>("O");
            xImage = TheGame.Content.Load<Texture2D>("X");
            xMiniImage = TheGame.Content.Load<Texture2D>("MiniX");
            oMiniImage = TheGame.Content.Load<Texture2D>("MiniO");
            drawImage = TheGame.Content.Load<Texture2D>("HandShake");
            //button TicTacToe:
            buttonDefault = TheGame.Content.Load<Texture2D>("Button");
            buttonGpTexture1 = TheGame.Content.Load<Texture2D>("Button");
            buttonGpRectangle1 = new Rectangle(18, 18, buttonGpTexture1.Width, buttonGpTexture1.Height);
            buttonGpTexture2 = TheGame.Content.Load<Texture2D>("Button");
            buttonGpRectangle2 = new Rectangle(188, 18, buttonGpTexture2.Width, buttonGpTexture2.Height);
            buttonGpTexture3 = TheGame.Content.Load<Texture2D>("Button");
            buttonGpRectangle3 = new Rectangle(358, 18, buttonGpTexture3.Width, buttonGpTexture3.Height);
            buttonGpTexture4 = TheGame.Content.Load<Texture2D>("Button");
            buttonGpRectangle4 = new Rectangle(18, 170, buttonGpTexture4.Width, buttonGpTexture4.Height);
            buttonGpTexture5 = TheGame.Content.Load<Texture2D>("Button");
            buttonGpRectangle5 = new Rectangle(188, 170, buttonGpTexture5.Width, buttonGpTexture5.Height);
            buttonGpTexture6 = TheGame.Content.Load<Texture2D>("Button");
            buttonGpRectangle6 = new Rectangle(358, 170, buttonGpTexture6.Width, buttonGpTexture6.Height);
            buttonGpTexture7 = TheGame.Content.Load<Texture2D>("Button");
            buttonGpRectangle7 = new Rectangle(18, 325, buttonGpTexture7.Width, buttonGpTexture7.Height);
            buttonGpTexture8 = TheGame.Content.Load<Texture2D>("Button");
            buttonGpRectangle8 = new Rectangle(188, 325, buttonGpTexture8.Width, buttonGpTexture8.Height);
            buttonGpTexture9 = TheGame.Content.Load<Texture2D>("Button");
            buttonGpRectangle9 = new Rectangle(358, 325, buttonGpTexture9.Width, buttonGpTexture9.Height);
            //Button interface:
            bInterfaceTexture = TheGame.Content.Load<Texture2D>("buttoninterface");
            bRoundsRectangle = new Rectangle(588, 425, bInterfaceTexture.Width, bInterfaceTexture.Height);
            bInterfaceTexture2 = TheGame.Content.Load<Texture2D>("buttoninterface");
            bResetRectangle = new Rectangle(788, 425, bInterfaceTexture2.Width, bInterfaceTexture2.Height);
        }
        void DrawBackground()
        {
            GlobalVariable.spriteBatch.Draw(_backgroundTexture, new Vector2(0, 0), Color.White);
        }
        public void DrawButtonGameplay()
        {
            GlobalVariable.spriteBatch.Draw(buttonGpTexture1, buttonGpRectangle1, Color.White);
            GlobalVariable.spriteBatch.Draw(buttonGpTexture2, buttonGpRectangle2, Color.White);
            GlobalVariable.spriteBatch.Draw(buttonGpTexture3, buttonGpRectangle3, Color.White);
            GlobalVariable.spriteBatch.Draw(buttonGpTexture4, buttonGpRectangle4, Color.White);
            GlobalVariable.spriteBatch.Draw(buttonGpTexture5, buttonGpRectangle5, Color.White);
            GlobalVariable.spriteBatch.Draw(buttonGpTexture6, buttonGpRectangle6, Color.White);
            GlobalVariable.spriteBatch.Draw(buttonGpTexture7, buttonGpRectangle7, Color.White);
            GlobalVariable.spriteBatch.Draw(buttonGpTexture8, buttonGpRectangle8, Color.White);
            GlobalVariable.spriteBatch.Draw(buttonGpTexture9, buttonGpRectangle9, Color.White);
        }
        void DrawButtonInterface()
        {
            GlobalVariable.spriteBatch.Draw(bInterfaceTexture, bRoundsRectangle, Color.White);
            GlobalVariable.spriteBatch.DrawString(buttonFont, "Next Round", new Vector2(600, 430), Color.Black);
            GlobalVariable.spriteBatch.Draw(bInterfaceTexture2, bResetRectangle, Color.White);
            GlobalVariable.spriteBatch.DrawString(buttonFont, "Reset", new Vector2(835, 430), Color.Black);
        }
        void DrawInterface()
        {
            GlobalVariable.spriteBatch.DrawString(interfaceFont, "TURN:", new Vector2(670, 20), Color.White);
            if (players == false)
            {
                GlobalVariable.spriteBatch.Draw(xMiniImage, new Vector2(820, 20), Color.White);
            }
            if (players == true)
            {
                GlobalVariable.spriteBatch.Draw(oMiniImage, new Vector2(820, 20), Color.White);
            }
            GlobalVariable.spriteBatch.DrawString(interfaceFont, "SCORE:", new Vector2(670, 100), Color.White);
            GlobalVariable.spriteBatch.Draw(xMiniImage, new Vector2(710, 165), Color.White);
            GlobalVariable.spriteBatch.DrawString(interfaceFont, ":" + winsPX, new Vector2(770, 155), Color.White);
            GlobalVariable.spriteBatch.Draw(oMiniImage, new Vector2(710, 225), Color.White);
            GlobalVariable.spriteBatch.DrawString(interfaceFont, ":" + winsPO, new Vector2(770, 215), Color.White);
            GlobalVariable.spriteBatch.Draw(drawImage, new Vector2(710, 285), Color.White);
            GlobalVariable.spriteBatch.DrawString(interfaceFont, ":" + drawP, new Vector2(770, 275), Color.White);
            //Winning message
            if (winner == true && players == true)
            {
                GlobalVariable.spriteBatch.DrawString(buttonFont, "CROSSES WIN!!!", new Vector2(670, 370), Color.White);
            }
            if (winner == true && players == false)
            {
                GlobalVariable.spriteBatch.DrawString(buttonFont, "NOUGHTS WIN!!!", new Vector2(670, 370), Color.White);
            }
            //Drawning message
            if (winner == false && textureCount == 9)
            {
                GlobalVariable.spriteBatch.DrawString(buttonFont, "DRAW!!!", new Vector2(720, 370), Color.White);
            }
        }
        public void Draw()
        {
            DrawBackground();
            DrawButtonGameplay();
            DrawInterface();
            DrawButtonInterface();
        }
        void GameLogic()
        {
            //Win and draw count//

            //Win player2(X) and Win player2(O)
            if (buttonGpTexture1 == xImage && buttonGpTexture2 == xImage && buttonGpTexture3 == xImage
                    || buttonGpTexture1 == oImage && buttonGpTexture2 == oImage && buttonGpTexture3 == oImage)
            {

                if (buttonGpTexture1 == xImage)
                {
                    if (onePointW == false)
                    {
                        winsPX++;
                        onePointW = true;
                        winner = true;
                    }
                }
                else
                {
                    if (onePointW == false)
                    {
                        winsPO++;
                        onePointW = true;
                        winner = true;
                    }

                }
            }
            if (buttonGpTexture1 == xImage && buttonGpTexture5 == xImage && buttonGpTexture9 == xImage
                    || buttonGpTexture1 == oImage && buttonGpTexture5 == oImage && buttonGpTexture9 == oImage)
            {
                if (buttonGpTexture1 == xImage)
                {
                    if (onePointW == false)
                    {
                        winsPX++;
                        onePointW = true;
                        winner = true;
                    }
                }
                else
                {
                    if (onePointW == false)
                    {
                        winsPO++;
                        onePointW = true;
                        winner = true;
                    }

                }
            }
            if (buttonGpTexture1 == xImage && buttonGpTexture4 == xImage && buttonGpTexture7 == xImage
                    || buttonGpTexture1 == oImage && buttonGpTexture4 == oImage && buttonGpTexture7 == oImage)
            {
                if (buttonGpTexture1 == xImage)
                {
                    if (onePointW == false)
                    {
                        winsPX++;
                        onePointW = true;
                        winner = true;
                    }
                }
                else
                {
                    if (onePointW == false)
                    {
                        winsPO++;
                        onePointW = true;
                        winner = true;
                    }

                }
            }
            if (buttonGpTexture3 == xImage && buttonGpTexture5 == xImage && buttonGpTexture7 == xImage
                    || buttonGpTexture3 == oImage && buttonGpTexture5 == oImage && buttonGpTexture7 == oImage)
            {
                if (buttonGpTexture3 == xImage)
                {
                    if (onePointW == false)
                    {
                        winsPX++;
                        onePointW = true;
                        winner = true;
                    }
                }
                else
                {
                    if (onePointW == false)
                    {
                        winsPO++;
                        onePointW = true;
                        winner = true;
                    }

                }
            }
            if (buttonGpTexture3 == xImage && buttonGpTexture6 == xImage && buttonGpTexture9 == xImage
                    || buttonGpTexture3 == oImage && buttonGpTexture6 == oImage && buttonGpTexture9 == oImage)
            {
                if (buttonGpTexture3 == xImage)
                {
                    if (onePointW == false)
                    {
                        winsPX++;
                        onePointW = true;
                        winner = true;
                    }
                }
                else
                {
                    if (onePointW == false)
                    {
                        winsPO++;
                        onePointW = true;
                        winner = true;
                    }

                }
            }
            if (buttonGpTexture5 == xImage && buttonGpTexture4 == xImage && buttonGpTexture6 == xImage
                    || buttonGpTexture5 == oImage && buttonGpTexture4 == oImage && buttonGpTexture6 == oImage)
            {
                if (buttonGpTexture5 == xImage)
                {
                    if (onePointW == false)
                    {
                        winsPX++;
                        onePointW = true;
                        winner = true;
                    }
                }
                else
                {
                    if (onePointW == false)
                    {
                        winsPO++;
                        onePointW = true;
                        winner = true;
                    }

                }
            }
            if (buttonGpTexture5 == xImage && buttonGpTexture2 == xImage && buttonGpTexture8 == xImage
                    || buttonGpTexture5 == oImage && buttonGpTexture2 == oImage && buttonGpTexture8 == oImage)
            {
                if (buttonGpTexture5 == xImage)
                {
                    if (onePointW == false)
                    {
                        winsPX++;
                        onePointW = true;
                        winner = true;
                    }
                }
                else
                {
                    if (onePointW == false)
                    {
                        winsPO++;
                        onePointW = true;
                        winner = true;
                    }

                }
            }
            if (buttonGpTexture7 == xImage && buttonGpTexture8 == xImage && buttonGpTexture9 == xImage
                  || buttonGpTexture7 == oImage && buttonGpTexture8 == oImage && buttonGpTexture9 == oImage)
            {
                if (buttonGpTexture7 == xImage)
                {
                    if (onePointW == false)
                    {
                        winsPX++;
                        onePointW = true;
                        winner = true;
                    }
                }
                else
                {
                    if (onePointW == false)
                    {
                        winsPO++;
                        onePointW = true;
                        winner = true;
                    }

                }
            }
            // Logic for Draw
            if (textureCount == 9 && winner == false)
            {
                if (onePointD == false)
                {
                    drawP++;
                    onePointD = true;

                }
            }
        }
        void ButtonInterface()
        {
            MouseState mouseState = Mouse.GetState();
            //Next Round Logic:
            if (mouseState.LeftButton == ButtonState.Pressed && bRoundsRectangle.Contains(mouseState.Position))
            {
                buttonGpTexture1 = buttonDefault;
                buttonGpTexture2 = buttonDefault;
                buttonGpTexture3 = buttonDefault;
                buttonGpTexture4 = buttonDefault;
                buttonGpTexture5 = buttonDefault;
                buttonGpTexture6 = buttonDefault;
                buttonGpTexture7 = buttonDefault;
                buttonGpTexture8 = buttonDefault;
                buttonGpTexture9 = buttonDefault;
                onePointW = false;
                onePointD = false;
                winner = false;
                textureCount = 0;
            }
            //Reset Logic:
            if (mouseState.LeftButton == ButtonState.Pressed && bResetRectangle.Contains(mouseState.Position))
            {
                buttonGpTexture1 = buttonDefault;
                buttonGpTexture2 = buttonDefault;
                buttonGpTexture3 = buttonDefault;
                buttonGpTexture4 = buttonDefault;
                buttonGpTexture5 = buttonDefault;
                buttonGpTexture6 = buttonDefault;
                buttonGpTexture7 = buttonDefault;
                buttonGpTexture8 = buttonDefault;
                buttonGpTexture9 = buttonDefault;
                onePointW = false;
                onePointD = false;
                winner = false;
                textureCount = 0;
                winsPX = 0;
                winsPO = 0;
                drawP = 0;
            }
        }
        public void Update()
        {
            //gameplay Logic:
            MouseState mouseState = Mouse.GetState();
            if (mouseState.LeftButton == ButtonState.Pressed && buttonGpRectangle1.Contains(mouseState.Position) && winner == false)
            {
                if (buttonGpTexture1 != xImage && buttonGpTexture1 != oImage)
                {

                    if (players == false)
                    {
                        buttonGpTexture1 = xImage;
                        players = true;
                        textureCount++;
                    }
                    else
                    {
                        buttonGpTexture1 = oImage;
                        players = false;
                        textureCount++;
                    }

                }
            }
            if (mouseState.LeftButton == ButtonState.Pressed && buttonGpRectangle2.Contains(mouseState.Position) && winner == false)
            {
                if (buttonGpTexture2 != xImage && buttonGpTexture2 != oImage)
                {

                    if (players == false)
                    {
                        buttonGpTexture2 = xImage;
                        players = true;
                        textureCount++;
                    }
                    else
                    {
                        buttonGpTexture2 = oImage;
                        players = false;
                        textureCount++;
                    }

                }
            }
            if (mouseState.LeftButton == ButtonState.Pressed && buttonGpRectangle3.Contains(mouseState.Position) && winner == false)
            {
                if (buttonGpTexture3 != xImage && buttonGpTexture3 != oImage)
                {

                    if (players == false)
                    {
                        buttonGpTexture3 = xImage;
                        players = true;
                        textureCount++;
                    }
                    else
                    {
                        buttonGpTexture3 = oImage;
                        players = false;
                        textureCount++;
                    }

                }
            }
            if (mouseState.LeftButton == ButtonState.Pressed && buttonGpRectangle4.Contains(mouseState.Position) && winner == false)
            {
                if (buttonGpTexture4 != xImage && buttonGpTexture4 != oImage)
                {

                    if (players == false)
                    {
                        buttonGpTexture4 = xImage;
                        players = true;
                        textureCount++;
                    }
                    else
                    {
                        buttonGpTexture4 = oImage;
                        players = false;
                        textureCount++;
                    }

                }
            }
            if (mouseState.LeftButton == ButtonState.Pressed && buttonGpRectangle5.Contains(mouseState.Position) && winner == false)
            {
                if (buttonGpTexture5 != xImage && buttonGpTexture5 != oImage)
                {

                    if (players == false)
                    {
                        buttonGpTexture5 = xImage;
                        players = true;
                        textureCount++;
                    }
                    else
                    {
                        buttonGpTexture5 = oImage;
                        players = false;
                        textureCount++;
                    }

                }
            }
            if (mouseState.LeftButton == ButtonState.Pressed && buttonGpRectangle6.Contains(mouseState.Position) && winner == false)
            {
                if (buttonGpTexture6 != xImage && buttonGpTexture6 != oImage)
                {

                    if (players == false)
                    {
                        buttonGpTexture6 = xImage;
                        players = true;
                        textureCount++;
                    }
                    else
                    {
                        buttonGpTexture6 = oImage;
                        players = false;
                        textureCount++;
                    }

                }
            }
            if (mouseState.LeftButton == ButtonState.Pressed && buttonGpRectangle7.Contains(mouseState.Position) && winner == false)
            {
                if (buttonGpTexture7 != xImage && buttonGpTexture7 != oImage)
                {

                    if (players == false)
                    {
                        buttonGpTexture7 = xImage;
                        players = true;
                        textureCount++;
                    }
                    else
                    {
                        buttonGpTexture7 = oImage;
                        players = false;
                        textureCount++;
                    }

                }
            }
            if (mouseState.LeftButton == ButtonState.Pressed && buttonGpRectangle8.Contains(mouseState.Position) && winner == false)
            {
                if (buttonGpTexture8 != xImage && buttonGpTexture8 != oImage)
                {

                    if (players == false)
                    {
                        buttonGpTexture8 = xImage;
                        players = true;
                        textureCount++;
                    }
                    else
                    {
                        buttonGpTexture8 = oImage;
                        players = false;
                        textureCount++;
                    }

                }
            }
            if (mouseState.LeftButton == ButtonState.Pressed && buttonGpRectangle9.Contains(mouseState.Position) && winner == false)
            {
                if (buttonGpTexture9 != xImage && buttonGpTexture9 != oImage)
                {

                    if (players == false)
                    {
                        buttonGpTexture9 = xImage;
                        players = true;
                        textureCount++;
                    }
                    else
                    {
                        buttonGpTexture9 = oImage;
                        players = false;
                        textureCount++;
                    }

                }
            }
            GameLogic();
            ButtonInterface();
        }
    }
}