using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using TicTacToe.Managers;



namespace TicTacToe.Scenes.Game
{
    public class Game
    {
        readonly GameMgr gameManager;
        TicTacToe TheGame => gameManager.TheGame;

        private Texture2D _backgroundTexture;
        private Texture2D xImage;
        private Texture2D oImage;
        private Texture2D xMiniImage;
        private Texture2D oMiniImage;
        private SpriteFont bigFont;
        private SpriteFont mediumFont;
        private Texture2D buttonDefault;
        private Texture2D buttonDarkGray;
        //texture and Rectangle of buttons for gameplay
        private Texture2D buttonGpText1, buttonGpText2, buttonGpText3, buttonGpText4, buttonGpText5,
            buttonGpText6, buttonGpText7, buttonGpText8, buttonGpText9;
        private Rectangle buttonGpRect1, buttonGpRect2, buttonGpRect3, buttonGpRect4,
            buttonGpRect5, buttonGpRect6, buttonGpRect7, buttonGpRect8, buttonGpRect9;

        private Texture2D nextRoundText;
        private Rectangle nextRoundRect;

        private Texture2D scoreText;

        private Texture2D framePlayerText;

        private Texture2D p1Profile1_1;
        private Texture2D p1Profile1_2;

        private Texture2D p1Profile2_1;
        private Texture2D p1Profile2_2;

        private Texture2D turnP1Text;
        private Texture2D turnP2Text;
        private Texture2D cpuText;

        private Texture2D roundsText;

        private Texture2D OandMMText;
        private Rectangle OandMMRect;

        private Texture2D OandMMPanelText;

        private Texture2D mainMenuText, optionsText;
        private Rectangle mainMenuRect, optionsRect;

        private Texture2D exitOptionsText;
        private Rectangle exitOptionsRect;

        private Texture2D panelVictoryText;

        private Texture2D mainMenuVictoryText, retryText, selectText;
        private Rectangle mainMenuVictoryRect, retryRect, selectRect;

        private Texture2D backgroundChooseText, randomText, chooseText, goText, p1Text, p2CpuText;
        private Rectangle randomRect, chooseRect, goRect, p1Rect, p2CpuRect;

        readonly Random randomPlayer = new Random();
        readonly Random randomStartCpu = new Random();
        readonly int[] board = new int[9];

        private bool players = false;
        private bool winner;
        private bool tied;
        private MouseState mouseState;
        private MouseState previousMouseState;
        private Color shadeInterface1 = Color.White;

        //aux:
        private bool onePointW;
        private bool onePointD;
        private bool clickonrectangle;
        private bool buttonGameplayPress;
        private int textureCount;
        private int victorys;
        private bool buttonOandMM;
        private bool thereIsAWinner;
        private int victoryPoints;
        private bool switchChoose = true;
        private bool chooseClick;
        private int playerStart;
        private int cpuStart;
        private int randomlycpu;
        private bool notRepeatstart;
        private bool randomlyLoop = true;
        private bool turnCpu;
        private int timer;
        //score:
        private int winsPX;
        private int winsPO;
        private int drawP;
        //Sounds:
        SoundEffect sVictory;
        SoundEffect sDraw;
        SoundEffect sCrosses;
        SoundEffect sNoughts;

        SoundEffect sError;
        public Game(GameMgr gameManager)
        {
            this.gameManager = gameManager;
        }
        public void LoadContent()
        {
            _backgroundTexture = TheGame.Content.Load<Texture2D>("GameSprites/Background");
            bigFont = TheGame.Content.Load<SpriteFont>("InterfaceF");
            mediumFont = TheGame.Content.Load<SpriteFont>("buttonFont");
            oImage = TheGame.Content.Load<Texture2D>("GameSprites/O");
            xImage = TheGame.Content.Load<Texture2D>("GameSprites/X");
            xMiniImage = TheGame.Content.Load<Texture2D>("GameSprites/MiniX");
            oMiniImage = TheGame.Content.Load<Texture2D>("GameSprites/MiniO");
            //Sounds:
            sVictory = TheGame.Content.Load<SoundEffect>("Sounds/SoundVictory");
            sDraw = TheGame.Content.Load<SoundEffect>("Sounds/SoundDraw");
            sNoughts = TheGame.Content.Load<SoundEffect>("Sounds/SoundO");
            sCrosses = TheGame.Content.Load<SoundEffect>("Sounds/SoundX");


            sError = TheGame.Content.Load<SoundEffect>("Sounds/Error");
            //button TicTacToe:

            buttonDefault = TheGame.Content.Load<Texture2D>("GameSprites/Button");
            buttonDarkGray = TheGame.Content.Load<Texture2D>("GameSprites/ButtonDarkGray");
            buttonGpText1 = TheGame.Content.Load<Texture2D>("GameSprites/Button");
            buttonGpRect1 = new Rectangle(131, 131, buttonGpText1.Width, buttonGpText1.Height);
            buttonGpText2 = TheGame.Content.Load<Texture2D>("GameSprites/Button");
            buttonGpRect2 = new Rectangle(313, 131, buttonGpText2.Width, buttonGpText2.Height);
            buttonGpText3 = TheGame.Content.Load<Texture2D>("GameSprites/Button");
            buttonGpRect3 = new Rectangle(496, 131, buttonGpText3.Width, buttonGpText3.Height);
            buttonGpText4 = TheGame.Content.Load<Texture2D>("GameSprites/Button");
            buttonGpRect4 = new Rectangle(131, 293, buttonGpText4.Width, buttonGpText4.Height);
            buttonGpText5 = TheGame.Content.Load<Texture2D>("GameSprites/Button");
            buttonGpRect5 = new Rectangle(313, 293, buttonGpText5.Width, buttonGpText5.Height);
            buttonGpText6 = TheGame.Content.Load<Texture2D>("GameSprites/Button");
            buttonGpRect6 = new Rectangle(496, 293, buttonGpText6.Width, buttonGpText6.Height);
            buttonGpText7 = TheGame.Content.Load<Texture2D>("GameSprites/Button");
            buttonGpRect7 = new Rectangle(131, 459, buttonGpText7.Width, buttonGpText7.Height);
            buttonGpText8 = TheGame.Content.Load<Texture2D>("GameSprites/Button");
            buttonGpRect8 = new Rectangle(313, 459, buttonGpText8.Width, buttonGpText8.Height);
            buttonGpText9 = TheGame.Content.Load<Texture2D>("GameSprites/Button");
            buttonGpRect9 = new Rectangle(496, 459, buttonGpText9.Width, buttonGpText9.Height);
            //Button interface:
            nextRoundText = TheGame.Content.Load<Texture2D>("GameSprites/NewRoundB");
            nextRoundRect = new Rectangle(790, 567, nextRoundText.Width, nextRoundText.Height);

            // Score
            scoreText = TheGame.Content.Load<Texture2D>("GameSprites/score");

            // Frame character
            framePlayerText = TheGame.Content.Load<Texture2D>("GameSprites/frame");

            p1Profile1_1 = TheGame.Content.Load<Texture2D>("GameSprites/P1CharacterProfile_1.1");
            p1Profile1_2 = TheGame.Content.Load<Texture2D>("GameSprites/P1CharacterProfile_1.2");

            p1Profile2_1 = TheGame.Content.Load<Texture2D>("GameSprites/P2CharacterProfile_2.1");
            p1Profile2_2 = TheGame.Content.Load<Texture2D>("GameSprites/P2CharacterProfile_2.2");

            // Turns
            turnP1Text = TheGame.Content.Load<Texture2D>("GameSprites/TurnP1");
            turnP2Text = TheGame.Content.Load<Texture2D>("GameSprites/TurnP2");
            cpuText = TheGame.Content.Load<Texture2D>("GameSprites/TurnCPU");

            // Rounds 
            roundsText = TheGame.Content.Load<Texture2D>("GameSprites/Rounds");

            // Options and Main Menu
            OandMMText = TheGame.Content.Load<Texture2D>("GameSprites/OandMMSprites/OptionsInGame");
            OandMMRect = new Rectangle(1193, 27, OandMMText.Width, OandMMText.Height);

            OandMMPanelText = TheGame.Content.Load<Texture2D>("GameSprites/OandMMSprites/Panel");

            exitOptionsText = TheGame.Content.Load<Texture2D>("GameSprites/OandMMSprites/exitOptions");
            exitOptionsRect = new Rectangle(786, 292, exitOptionsText.Width, exitOptionsText.Height);

            optionsText = TheGame.Content.Load<Texture2D>("GameSprites/OandMMSprites/OptionsButton");
            optionsRect = new Rectangle(510, 314, optionsText.Width, optionsText.Height);

            mainMenuText = TheGame.Content.Load<Texture2D>("GameSprites/OandMMSprites/MainMenuButton");
            mainMenuRect = new Rectangle(510, 384, mainMenuText.Width, mainMenuText.Height);

            // Victory menssage
            panelVictoryText = TheGame.Content.Load<Texture2D>("GameSprites/VictorySprites/VictoryPanel");

            retryText = TheGame.Content.Load<Texture2D>("GameSprites/VictorySprites/retry");
            retryRect = new Rectangle(340, 426, retryText.Width, retryText.Height);

            selectText = TheGame.Content.Load<Texture2D>("GameSprites/VictorySprites/select");
            selectRect = new Rectangle(557, 426, selectText.Width, selectText.Height);

            mainMenuVictoryText = TheGame.Content.Load<Texture2D>("GameSprites/VictorySprites/mainmenuVictory");
            mainMenuVictoryRect = new Rectangle(766, 426, mainMenuVictoryText.Width, mainMenuVictoryText.Height);

            // Choose

            backgroundChooseText = TheGame.Content.Load<Texture2D>("GameSprites/Choose/BGChoose");
            randomText = TheGame.Content.Load<Texture2D>("GameSprites/Choose/RandomB");
            randomRect = new Rectangle(439, 368, randomText.Width, randomText.Height);

            chooseText = TheGame.Content.Load<Texture2D>("GameSprites/Choose/ChooseB");
            chooseRect = new Rectangle(670, 368, chooseText.Width, chooseText.Height);

            goText = TheGame.Content.Load<Texture2D>("GameSprites/Choose/GoB");
            goRect = new Rectangle(553, 454, goText.Width, goText.Height);

            p1Text = TheGame.Content.Load<Texture2D>("GameSprites/Choose/P1B");
            p1Rect = new Rectangle(439, 412, p1Text.Width, p1Text.Height);

            p2CpuText = TheGame.Content.Load<Texture2D>("GameSprites/Choose/P2CpuB");
            p2CpuRect = new Rectangle(670, 412, p2CpuText.Width, p2CpuText.Height);

        }
        void Player1GPLogic()
        {
            timer = 0;
            randomlyLoop = true;
            //first rectangle
            if (previousMouseState.LeftButton == ButtonState.Pressed && mouseState.LeftButton == ButtonState.Released
                && buttonGpRect1.Contains(mouseState.Position) && winner == false)
            {
                if (buttonGpText1 != xImage && buttonGpText1 != oImage)
                {
                    if (players == false)
                    {
                        switch (Globals.CrossOrNougtP1)
                        {
                            case 1:
                                buttonGpText1 = xImage;
                                board[0] = 1;
                                players = true;
                                turnCpu = false;
                                textureCount++;
                                break;
                            case 2:
                                buttonGpText1 = oImage;
                                board[0] = 1;
                                players = true;
                                turnCpu = false;
                                textureCount++;
                                break;
                            default:

                                break;
                        }
                    }
                    clickonrectangle = true;
                }
            }
            //second rectangle
            if (previousMouseState.LeftButton == ButtonState.Pressed && mouseState.LeftButton == ButtonState.Released
                && buttonGpRect2.Contains(mouseState.Position) && winner == false)
            {
                if (buttonGpText2 != xImage && buttonGpText2 != oImage)
                {

                    if (players == false)
                    {
                        switch (Globals.CrossOrNougtP1)
                        {
                            case 1:
                                buttonGpText2 = xImage;
                                board[1] = 1;
                                players = true;
                                turnCpu = false;
                                textureCount++;
                                break;
                            case 2:
                                buttonGpText2 = oImage;
                                board[1] = 1;
                                players = true;
                                turnCpu = false;
                                textureCount++;
                                break;
                            default:

                                break;
                        }
                    }
                    clickonrectangle = true;
                }
            }
            //third rectangle
            if (previousMouseState.LeftButton == ButtonState.Pressed && mouseState.LeftButton == ButtonState.Released
                && buttonGpRect3.Contains(mouseState.Position) && winner == false)
            {
                if (buttonGpText3 != xImage && buttonGpText3 != oImage)
                {
                    if (players == false)
                    {
                        switch (Globals.CrossOrNougtP1)
                        {
                            case 1:
                                buttonGpText3 = xImage;
                                board[2] = 1;
                                players = true;
                                turnCpu = false;
                                textureCount++;
                                break;
                            case 2:
                                buttonGpText3 = oImage;
                                board[2] = 1;
                                players = true;
                                turnCpu = false;
                                textureCount++;
                                break;
                            default:

                                break;
                        }
                    }
                    clickonrectangle = true;
                }
            }
            //quarter rectangle
            if (previousMouseState.LeftButton == ButtonState.Pressed && mouseState.LeftButton == ButtonState.Released
                && buttonGpRect4.Contains(mouseState.Position) && winner == false)
            {
                if (buttonGpText4 != xImage && buttonGpText4 != oImage)
                {
                    if (players == false)
                    {
                        switch (Globals.CrossOrNougtP1)
                        {
                            case 1:
                                buttonGpText4 = xImage;
                                board[3] = 1;
                                players = true;
                                turnCpu = false;
                                textureCount++;
                                break;
                            case 2:
                                buttonGpText4 = oImage;
                                board[3] = 1;
                                players = true;
                                turnCpu = false;
                                textureCount++;
                                break;
                            default:

                                break;
                        }
                    }
                    clickonrectangle = true;
                }
            }
            //fifth rectangle
            if (previousMouseState.LeftButton == ButtonState.Pressed && mouseState.LeftButton == ButtonState.Released
                && buttonGpRect5.Contains(mouseState.Position) && winner == false)
            {
                if (buttonGpText5 != xImage && buttonGpText5 != oImage)
                {
                    if (players == false)
                    {
                        switch (Globals.CrossOrNougtP1)
                        {
                            case 1:
                                buttonGpText5 = xImage;
                                board[4] = 1;
                                players = true;
                                turnCpu = false;
                                textureCount++;
                                break;
                            case 2:
                                buttonGpText5 = oImage;
                                board[4] = 1;
                                players = true;
                                turnCpu = false;
                                textureCount++;
                                break;
                            default:

                                break;
                        }
                    }
                    clickonrectangle = true;
                }
            }
            //sixth rectangle
            if (previousMouseState.LeftButton == ButtonState.Pressed && mouseState.LeftButton == ButtonState.Released
                && buttonGpRect6.Contains(mouseState.Position) && winner == false)
            {
                if (buttonGpText6 != xImage && buttonGpText6 != oImage)
                {
                    if (players == false)
                    {
                        switch (Globals.CrossOrNougtP1)
                        {
                            case 1:
                                buttonGpText6 = xImage;
                                board[5] = 1;
                                players = true;
                                turnCpu = false;
                                textureCount++;
                                break;
                            case 2:
                                buttonGpText6 = oImage;
                                board[5] = 1;
                                players = true;
                                turnCpu = false;
                                textureCount++;
                                break;
                            default:

                                break;
                        }
                    }
                    clickonrectangle = true;
                }
            }
            //seventh rectangle
            if (previousMouseState.LeftButton == ButtonState.Pressed && mouseState.LeftButton == ButtonState.Released
                && buttonGpRect7.Contains(mouseState.Position) && winner == false)
            {
                if (buttonGpText7 != xImage && buttonGpText7 != oImage)
                {
                    if (players == false)
                    {
                        switch (Globals.CrossOrNougtP1)
                        {
                            case 1:
                                buttonGpText7 = xImage;
                                board[6] = 1;
                                players = true;
                                turnCpu = false;
                                textureCount++;
                                break;
                            case 2:
                                buttonGpText7 = oImage;
                                board[6] = 1;
                                players = true;
                                turnCpu = false;
                                textureCount++;
                                break;
                            default:

                                break;
                        }
                    }
                    clickonrectangle = true;
                }
            }
            //eighth rectangle
            if (previousMouseState.LeftButton == ButtonState.Pressed && mouseState.LeftButton == ButtonState.Released
                && buttonGpRect8.Contains(mouseState.Position) && winner == false)
            {
                if (buttonGpText8 != xImage && buttonGpText8 != oImage)
                {
                    if (players == false)
                    {
                        switch (Globals.CrossOrNougtP1)
                        {
                            case 1:
                                buttonGpText8 = xImage;
                                board[7] = 1;
                                players = true;
                                turnCpu = false;
                                textureCount++;
                                break;
                            case 2:
                                buttonGpText8 = oImage;
                                board[7] = 1;
                                players = true;
                                turnCpu = false;
                                textureCount++;
                                break;
                            default:

                                break;
                        }
                    }
                    clickonrectangle = true;
                }
            }
            //ninth rectangle
            if (previousMouseState.LeftButton == ButtonState.Pressed && mouseState.LeftButton == ButtonState.Released
                && buttonGpRect9.Contains(mouseState.Position) && winner == false)
            {
                if (buttonGpText9 != xImage && buttonGpText9 != oImage)
                {
                    if (players == false)
                    {
                        switch (Globals.CrossOrNougtP1)
                        {
                            case 1:
                                buttonGpText9 = xImage;
                                board[8] = 1;
                                players = true;
                                turnCpu = false;
                                textureCount++;
                                break;
                            case 2:
                                buttonGpText9 = oImage;
                                board[8] = 1;
                                players = true;
                                turnCpu = false;
                                textureCount++;
                                break;
                            default:

                                break;
                        }
                    }
                    clickonrectangle = true;
                }
            }
        }
        void Player2GPLogic()
        {
            //first rectangle
            if (previousMouseState.LeftButton == ButtonState.Pressed && mouseState.LeftButton == ButtonState.Released
                && buttonGpRect1.Contains(mouseState.Position) && winner == false)
            {
                if (buttonGpText1 != xImage && buttonGpText1 != oImage)
                {
                    if (players == true)
                    {
                        switch (Globals.CrossOrNougtP2)
                        {
                            case 1:
                                buttonGpText1 = oImage;

                                players = false;

                                textureCount++;
                                break;
                            case 2:
                                buttonGpText1 = xImage;

                                players = false;

                                textureCount++;
                                break;
                            default:

                                break;
                        }
                    }

                    clickonrectangle = true;
                }
            }
            //second rectangle
            if (previousMouseState.LeftButton == ButtonState.Pressed && mouseState.LeftButton == ButtonState.Released
                && buttonGpRect2.Contains(mouseState.Position) && winner == false)
            {
                if (buttonGpText2 != xImage && buttonGpText2 != oImage)
                {
                    if (players == true)
                    {
                        switch (Globals.CrossOrNougtP2)
                        {
                            case 1:
                                buttonGpText2 = oImage;

                                players = false;

                                textureCount++;
                                break;
                            case 2:
                                buttonGpText2 = xImage;

                                players = false;

                                textureCount++;
                                break;
                            default:

                                break;
                        }
                    }
                    clickonrectangle = true;
                }
            }
            //third rectangle
            if (previousMouseState.LeftButton == ButtonState.Pressed && mouseState.LeftButton == ButtonState.Released
                && buttonGpRect3.Contains(mouseState.Position) && winner == false)
            {
                if (buttonGpText3 != xImage && buttonGpText3 != oImage)
                {
                    if (players == true)
                    {
                        switch (Globals.CrossOrNougtP2)
                        {
                            case 1:
                                buttonGpText3 = oImage;

                                players = false;

                                textureCount++;
                                break;
                            case 2:
                                buttonGpText3 = xImage;

                                players = false;

                                textureCount++;
                                break;
                            default:

                                break;
                        }
                    }
                    clickonrectangle = true;
                }
            }
            //quarter rectangle
            if (previousMouseState.LeftButton == ButtonState.Pressed && mouseState.LeftButton == ButtonState.Released
                && buttonGpRect4.Contains(mouseState.Position) && winner == false)
            {
                if (buttonGpText4 != xImage && buttonGpText4 != oImage)
                {
                    if (players == true)
                    {

                        switch (Globals.CrossOrNougtP2)
                        {
                            case 1:
                                buttonGpText4 = oImage;

                                players = false;

                                textureCount++;
                                break;
                            case 2:
                                buttonGpText4 = xImage;

                                players = false;

                                textureCount++;
                                break;
                            default:

                                break;
                        }
                    }
                    clickonrectangle = true;
                }
            }
            //fifth rectangle
            if (previousMouseState.LeftButton == ButtonState.Pressed && mouseState.LeftButton == ButtonState.Released
                && buttonGpRect5.Contains(mouseState.Position) && winner == false)
            {
                if (buttonGpText5 != xImage && buttonGpText5 != oImage)
                {
                    if (players == true)
                    {
                        switch (Globals.CrossOrNougtP2)
                        {
                            case 1:
                                buttonGpText5 = oImage;

                                players = false;

                                textureCount++;
                                break;
                            case 2:
                                buttonGpText5 = xImage;

                                players = false;

                                textureCount++;
                                break;
                            default:

                                break;
                        }
                    }
                    clickonrectangle = true;
                }
            }
            //sixth rectangle
            if (previousMouseState.LeftButton == ButtonState.Pressed && mouseState.LeftButton == ButtonState.Released
                && buttonGpRect6.Contains(mouseState.Position) && winner == false)
            {
                if (buttonGpText6 != xImage && buttonGpText6 != oImage)
                {
                    if (players == true)
                    {
                        switch (Globals.CrossOrNougtP2)
                        {
                            case 1:
                                buttonGpText6 = oImage;

                                players = false;

                                textureCount++;
                                break;
                            case 2:
                                buttonGpText6 = xImage;

                                players = false;

                                textureCount++;
                                break;
                            default:

                                break;
                        }

                    }
                    clickonrectangle = true;
                }
            }
            //seventh rectangle
            if (previousMouseState.LeftButton == ButtonState.Pressed && mouseState.LeftButton == ButtonState.Released
                && buttonGpRect7.Contains(mouseState.Position) && winner == false)
            {
                if (buttonGpText7 != xImage && buttonGpText7 != oImage)
                {
                    if (players == true)
                    {
                        switch (Globals.CrossOrNougtP2)
                        {
                            case 1:
                                buttonGpText7 = oImage;

                                players = false;

                                textureCount++;
                                break;
                            case 2:
                                buttonGpText7 = xImage;

                                players = false;

                                textureCount++;
                                break;
                            default:

                                break;
                        }

                    }
                    clickonrectangle = true;
                }
            }
            //eighth rectangle
            if (previousMouseState.LeftButton == ButtonState.Pressed && mouseState.LeftButton == ButtonState.Released
                && buttonGpRect8.Contains(mouseState.Position) && winner == false)
            {
                if (buttonGpText8 != xImage && buttonGpText8 != oImage)
                {
                    if (players == true)
                    {
                        switch (Globals.CrossOrNougtP2)
                        {
                            case 1:
                                buttonGpText8 = oImage;

                                players = false;

                                textureCount++;
                                break;
                            case 2:
                                buttonGpText8 = xImage;

                                players = false;

                                textureCount++;
                                break;
                            default:

                                break;
                        }
                    }
                    clickonrectangle = true;
                }
            }
            //ninth rectangle
            if (previousMouseState.LeftButton == ButtonState.Pressed && mouseState.LeftButton == ButtonState.Released
                && buttonGpRect9.Contains(mouseState.Position) && winner == false)
            {
                if (buttonGpText9 != xImage && buttonGpText9 != oImage)
                {
                    if (players == true)
                    {
                        switch (Globals.CrossOrNougtP2)
                        {
                            case 1:
                                buttonGpText9 = oImage;

                                players = false;

                                textureCount++;
                                break;
                            case 2:
                                buttonGpText9 = xImage;

                                players = false;

                                textureCount++;
                                break;
                            default:

                                break;
                        }
                    }
                    clickonrectangle = true;
                }
            }
        }
        void CpuGPLogic()
        {
            // cpu start

            // CPU reaction timer.
            timer++;

            // Cpu tie logic
            if (tied == true && timer == 30)
            {
                buttonGpText1 = buttonDefault;
                buttonGpText2 = buttonDefault;
                buttonGpText3 = buttonDefault;
                buttonGpText4 = buttonDefault;
                buttonGpText5 = buttonDefault;
                buttonGpText6 = buttonDefault;
                buttonGpText7 = buttonDefault;
                buttonGpText8 = buttonDefault;
                buttonGpText9 = buttonDefault;
                board[0] = 0;
                board[1] = 0;
                board[2] = 0;
                board[3] = 0;
                board[4] = 0;
                board[5] = 0;
                board[6] = 0;
                board[7] = 0;
                board[8] = 0;
                onePointW = false;
                onePointD = false;
                winner = false;
                tied = false;
                Globals.VictoryOrDraw = false;
                textureCount = 0;
                notRepeatstart = false;
                timer = 0;
            }
            // Cpu Logic
            if (timer == 30 && winner == false)
            {

                if (playerStart == 2 && notRepeatstart == false && turnCpu == false)
                {
                    cpuStart = randomStartCpu.Next(1, 10);
                    switch (Globals.CrossOrNougtP2)
                    {
                        case 1:
                            switch (cpuStart)
                            {
                                case 1:
                                    buttonGpText1 = oImage;
                                    board[0] = 2;
                                    players = false;
                                    turnCpu = true;
                                    textureCount++;
                                    break;
                                case 2:
                                    buttonGpText2 = oImage;
                                    board[1] = 2;
                                    players = false;
                                    turnCpu = true;
                                    textureCount++;
                                    break;
                                case 3:
                                    buttonGpText3 = oImage;
                                    board[2] = 2;
                                    players = false;
                                    turnCpu = true;
                                    textureCount++;
                                    break;
                                case 4:
                                    buttonGpText4 = oImage;
                                    board[3] = 2;
                                    players = false;
                                    turnCpu = true;
                                    textureCount++;
                                    break;
                                case 5:
                                    buttonGpText5 = oImage;
                                    board[4] = 2;
                                    players = false;
                                    turnCpu = true;
                                    textureCount++;
                                    break;
                                case 6:
                                    buttonGpText6 = oImage;
                                    board[5] = 2;
                                    players = false;
                                    turnCpu = true;
                                    textureCount++;
                                    break;
                                case 7:
                                    buttonGpText7 = oImage;
                                    board[6] = 2;
                                    players = false;
                                    turnCpu = true;
                                    textureCount++;
                                    break;
                                case 8:
                                    buttonGpText8 = oImage;
                                    board[7] = 2;
                                    players = false;
                                    turnCpu = true;
                                    textureCount++;
                                    break;
                                case 9:
                                    buttonGpText9 = oImage;
                                    board[8] = 2;
                                    players = false;
                                    turnCpu = true;
                                    textureCount++;
                                    break;
                                default:
                                    break;
                            }
                            break;
                        case 2:
                            switch (cpuStart)
                            {
                                case 1:
                                    buttonGpText1 = xImage;
                                    board[0] = 2;
                                    players = false;
                                    turnCpu = true;
                                    textureCount++;
                                    break;
                                case 2:
                                    buttonGpText2 = xImage;
                                    board[1] = 2;
                                    players = false;
                                    turnCpu = true;
                                    textureCount++;
                                    break;
                                case 3:
                                    buttonGpText3 = xImage;
                                    board[2] = 2;
                                    players = false;
                                    turnCpu = true;
                                    textureCount++;
                                    break;
                                case 4:
                                    buttonGpText4 = xImage;
                                    board[3] = 2;
                                    players = false;
                                    turnCpu = true;
                                    textureCount++;
                                    break;
                                case 5:
                                    buttonGpText5 = xImage;
                                    board[4] = 2;
                                    players = false;
                                    turnCpu = true;
                                    textureCount++;
                                    break;
                                case 6:
                                    buttonGpText6 = xImage;
                                    board[5] = 2;
                                    players = false;
                                    turnCpu = true;
                                    textureCount++;
                                    break;
                                case 7:
                                    buttonGpText7 = xImage;
                                    board[6] = 2;
                                    players = false;
                                    turnCpu = true;
                                    textureCount++;
                                    break;
                                case 8:
                                    buttonGpText8 = xImage;
                                    board[7] = 2;
                                    players = false;
                                    turnCpu = true;
                                    textureCount++;
                                    break;
                                case 9:
                                    buttonGpText9 = xImage;
                                    board[8] = 2;
                                    players = false;
                                    turnCpu = true;
                                    textureCount++;
                                    break;
                                default:
                                    break;
                            }
                            break;
                        default:
                            break;
                    }
                    clickonrectangle = true;
                    notRepeatstart = true;
                }
                // cpu player logic

                if (board[0] == 2 && board[1] == 2 && board[2] == 0 && turnCpu == false)
                {
                    if (Globals.CrossOrNougtP2 == 1)
                    {
                        buttonGpText3 = oImage;
                        board[2] = 2;
                        players = false;
                        turnCpu = true;
                        textureCount++;
                    }
                    if (Globals.CrossOrNougtP2 == 2)
                    {
                        buttonGpText3 = xImage;
                        board[2] = 2;
                        players = false;
                        turnCpu = true;
                        textureCount++;
                    }
                    clickonrectangle = true;
                }
                if (board[3] == 2 && board[4] == 2 && board[5] == 0 && turnCpu == false)
                {
                    if (Globals.CrossOrNougtP2 == 1)
                    {
                        buttonGpText6 = oImage;
                        board[5] = 2;
                        players = false;
                        turnCpu = true;
                        textureCount++;
                    }
                    if (Globals.CrossOrNougtP2 == 2)
                    {
                        buttonGpText6 = xImage;
                        board[5] = 2;
                        players = false;
                        turnCpu = true;
                        textureCount++;
                    }
                    clickonrectangle = true;
                }
                if (board[6] == 2 && board[7] == 2 && board[8] == 0 && turnCpu == false)
                {
                    if (Globals.CrossOrNougtP2 == 1)
                    {
                        buttonGpText9 = oImage;
                        board[8] = 2;
                        players = false;
                        turnCpu = true;
                        textureCount++;
                    }
                    if (Globals.CrossOrNougtP2 == 2)
                    {
                        buttonGpText9 = xImage;
                        board[8] = 2;
                        players = false;
                        turnCpu = true;
                        textureCount++;
                    }
                    clickonrectangle = true;
                }
                if (board[0] == 2 && board[3] == 2 && board[6] == 0 && turnCpu == false)
                {
                    if (Globals.CrossOrNougtP2 == 1)
                    {
                        buttonGpText7 = oImage;
                        board[6] = 2;
                        players = false;
                        turnCpu = true;
                        textureCount++;
                    }
                    if (Globals.CrossOrNougtP2 == 2)
                    {
                        buttonGpText7 = xImage;
                        board[6] = 2;
                        players = false;
                        turnCpu = true;
                        textureCount++;
                    }
                    clickonrectangle = true;
                }
                if (board[1] == 2 && board[4] == 2 && board[7] == 0 && turnCpu == false)
                {
                    if (Globals.CrossOrNougtP2 == 1)
                    {
                        buttonGpText8 = oImage;
                        board[7] = 2;
                        players = false;
                        turnCpu = true;
                        textureCount++;
                    }
                    if (Globals.CrossOrNougtP2 == 2)
                    {
                        buttonGpText8 = xImage;
                        board[7] = 2;
                        players = false;
                        turnCpu = true;
                        textureCount++;
                    }
                    clickonrectangle = true;
                }
                if (board[2] == 2 && board[5] == 2 && board[8] == 0 && turnCpu == false)
                {
                    if (Globals.CrossOrNougtP2 == 1)
                    {
                        buttonGpText9 = oImage;
                        board[8] = 2;
                        players = false;
                        turnCpu = true;
                        textureCount++;
                    }
                    if (Globals.CrossOrNougtP2 == 2)
                    {
                        buttonGpText9 = xImage;
                        board[8] = 2;
                        players = false;
                        turnCpu = true;
                        textureCount++;
                    }
                    clickonrectangle = true;
                }
                if (board[0] == 2 && board[4] == 2 && board[8] == 0 && turnCpu == false)
                {
                    if (Globals.CrossOrNougtP2 == 1)
                    {
                        buttonGpText9 = oImage;
                        board[8] = 2;
                        players = false;
                        turnCpu = true;
                        textureCount++;
                    }
                    if (Globals.CrossOrNougtP2 == 2)
                    {
                        buttonGpText9 = xImage;
                        board[8] = 2;
                        players = false;
                        turnCpu = true;
                        textureCount++;
                    }
                    clickonrectangle = true;
                }
                if (board[2] == 2 && board[4] == 2 && board[6] == 0 && turnCpu == false)
                {
                    if (Globals.CrossOrNougtP2 == 1)
                    {
                        buttonGpText7 = oImage;
                        board[6] = 2;
                        players = false;
                        turnCpu = true;
                        textureCount++;
                    }
                    if (Globals.CrossOrNougtP2 == 2)
                    {
                        buttonGpText7 = xImage;
                        board[6] = 2;
                        players = false;
                        turnCpu = true;
                        textureCount++;
                    }
                    clickonrectangle = true;
                }

                // reverse attack 

                if (board[0] == 0 && board[1] == 2 && board[2] == 2 && turnCpu == false)
                {
                    if (Globals.CrossOrNougtP2 == 1)
                    {
                        buttonGpText1 = oImage;
                        board[0] = 2;
                        players = false;
                        turnCpu = true;
                        textureCount++;
                    }
                    if (Globals.CrossOrNougtP2 == 2)
                    {
                        buttonGpText1 = xImage;
                        board[0] = 2;
                        players = false;
                        turnCpu = true;
                        textureCount++;
                    }
                    clickonrectangle = true;
                }
                if (board[3] == 0 && board[4] == 2 && board[5] == 2 && turnCpu == false)
                {
                    if (Globals.CrossOrNougtP2 == 1)
                    {
                        buttonGpText4 = oImage;
                        board[3] = 2;
                        players = false;
                        turnCpu = true;
                        textureCount++;
                    }
                    if (Globals.CrossOrNougtP2 == 2)
                    {
                        buttonGpText4 = xImage;
                        board[3] = 2;
                        players = false;
                        turnCpu = true;
                        textureCount++;
                    }
                    clickonrectangle = true;
                }
                if (board[6] == 0 && board[7] == 2 && board[8] == 2 && turnCpu == false)
                {
                    if (Globals.CrossOrNougtP2 == 1)
                    {
                        buttonGpText7 = oImage;
                        board[6] = 2;
                        players = false;
                        turnCpu = true;
                        textureCount++;
                    }
                    if (Globals.CrossOrNougtP2 == 2)
                    {
                        buttonGpText7 = xImage;
                        board[6] = 2;
                        players = false;
                        turnCpu = true;
                        textureCount++;
                    }
                    clickonrectangle = true;
                }
                if (board[0] == 0 && board[3] == 2 && board[6] == 2 && turnCpu == false)
                {
                    if (Globals.CrossOrNougtP2 == 1)
                    {
                        buttonGpText1 = oImage;
                        board[0] = 2;
                        players = false;
                        turnCpu = true;
                        textureCount++;
                    }
                    if (Globals.CrossOrNougtP2 == 2)
                    {
                        buttonGpText1 = xImage;
                        board[0] = 2;
                        players = false;
                        turnCpu = true;
                        textureCount++;
                    }
                    clickonrectangle = true;
                }
                if (board[1] == 0 && board[4] == 2 && board[7] == 2 && turnCpu == false)
                {
                    if (Globals.CrossOrNougtP2 == 1)
                    {
                        buttonGpText2 = oImage;
                        board[1] = 2;
                        players = false;
                        turnCpu = true;
                        textureCount++;
                    }
                    if (Globals.CrossOrNougtP2 == 2)
                    {
                        buttonGpText2 = xImage;
                        board[1] = 2;
                        players = false;
                        turnCpu = true;
                        textureCount++;
                    }
                    clickonrectangle = true;
                }
                if (board[2] == 0 && board[5] == 2 && board[8] == 2 && turnCpu == false)
                {
                    if (Globals.CrossOrNougtP2 == 1)
                    {
                        buttonGpText3 = oImage;
                        board[2] = 2;
                        players = false;
                        turnCpu = true;
                        textureCount++;
                    }
                    if (Globals.CrossOrNougtP2 == 2)
                    {
                        buttonGpText3 = xImage;
                        board[2] = 2;
                        players = false;
                        turnCpu = true;
                        textureCount++;
                    }
                    clickonrectangle = true;
                }
                if (board[0] == 0 && board[4] == 2 && board[8] == 2 && turnCpu == false)
                {
                    if (Globals.CrossOrNougtP2 == 1)
                    {
                        buttonGpText1 = oImage;
                        board[0] = 2;
                        players = false;
                        turnCpu = true;
                        textureCount++;
                    }
                    if (Globals.CrossOrNougtP2 == 2)
                    {
                        buttonGpText1 = xImage;
                        board[0] = 2;
                        players = false;
                        turnCpu = true;
                        textureCount++;
                    }
                    clickonrectangle = true;
                }
                if (board[2] == 0 && board[4] == 2 && board[6] == 2 && turnCpu == false)
                {
                    if (Globals.CrossOrNougtP2 == 1)
                    {
                        buttonGpText3 = oImage;
                        board[2] = 2;
                        players = false;
                        turnCpu = true;
                        textureCount++;
                    }
                    if (Globals.CrossOrNougtP2 == 2)
                    {
                        buttonGpText3 = xImage;
                        board[2] = 2;
                        players = false;
                        turnCpu = true;
                        textureCount++;
                    }
                    clickonrectangle = true;
                }
                // middle attack
                if (board[0] == 2 && board[1] == 0 && board[2] == 2 && turnCpu == false)
                {
                    if (Globals.CrossOrNougtP2 == 1)
                    {
                        buttonGpText2 = oImage;
                        board[1] = 2;
                        players = false;
                        turnCpu = true;
                        textureCount++;
                    }
                    if (Globals.CrossOrNougtP2 == 2)
                    {
                        buttonGpText2 = xImage;
                        board[1] = 2;
                        players = false;
                        turnCpu = true;
                        textureCount++;
                    }
                    clickonrectangle = true;
                }
                if (board[3] == 2 && board[4] == 0 && board[5] == 2 && turnCpu == false)
                {
                    if (Globals.CrossOrNougtP2 == 1)
                    {
                        buttonGpText5 = oImage;
                        board[4] = 2;
                        players = false;
                        turnCpu = true;
                        textureCount++;
                    }
                    if (Globals.CrossOrNougtP2 == 2)
                    {
                        buttonGpText5 = xImage;
                        board[4] = 2;
                        players = false;
                        turnCpu = true;
                        textureCount++;
                    }
                    clickonrectangle = true;
                }
                if (board[6] == 2 && board[7] == 0 && board[8] == 2 && turnCpu == false)
                {
                    if (Globals.CrossOrNougtP2 == 1)
                    {
                        buttonGpText8 = oImage;
                        board[7] = 2;
                        players = false;
                        turnCpu = true;
                        textureCount++;
                    }
                    if (Globals.CrossOrNougtP2 == 2)
                    {
                        buttonGpText8 = xImage;
                        board[7] = 2;
                        players = false;
                        turnCpu = true;
                        textureCount++;
                    }
                    clickonrectangle = true;
                }
                if (board[0] == 2 && board[3] == 0 && board[6] == 2 && turnCpu == false)
                {
                    if (Globals.CrossOrNougtP2 == 1)
                    {
                        buttonGpText4 = oImage;
                        board[3] = 2;
                        players = false;
                        turnCpu = true;
                        textureCount++;
                    }
                    if (Globals.CrossOrNougtP2 == 2)
                    {
                        buttonGpText4 = xImage;
                        board[3] = 2;
                        players = false;
                        turnCpu = true;
                        textureCount++;
                    }
                    clickonrectangle = true;
                }
                if (board[1] == 2 && board[4] == 0 && board[7] == 2 && turnCpu == false)
                {
                    if (Globals.CrossOrNougtP2 == 1)
                    {
                        buttonGpText5 = oImage;
                        board[4] = 2;
                        players = false;
                        turnCpu = true;
                        textureCount++;
                    }
                    if (Globals.CrossOrNougtP2 == 2)
                    {
                        buttonGpText5 = xImage;
                        board[4] = 2;
                        players = false;
                        turnCpu = true;
                        textureCount++;
                    }
                    clickonrectangle = true;
                }
                if (board[2] == 2 && board[5] == 0 && board[8] == 2 && turnCpu == false)
                {
                    if (Globals.CrossOrNougtP2 == 1)
                    {
                        buttonGpText6 = oImage;
                        board[5] = 2;
                        players = false;
                        turnCpu = true;
                        textureCount++;
                    }
                    if (Globals.CrossOrNougtP2 == 2)
                    {
                        buttonGpText6 = xImage;
                        board[5] = 2;
                        players = false;
                        turnCpu = true;
                        textureCount++;
                    }
                    clickonrectangle = true;
                }
                if (board[0] == 2 && board[4] == 0 && board[8] == 2 && turnCpu == false)
                {
                    if (Globals.CrossOrNougtP2 == 1)
                    {
                        buttonGpText5 = oImage;
                        board[4] = 2;
                        players = false;
                        turnCpu = true;
                        textureCount++;
                    }
                    if (Globals.CrossOrNougtP2 == 2)
                    {
                        buttonGpText5 = xImage;
                        board[4] = 2;
                        players = false;
                        turnCpu = true;
                        textureCount++;
                    }
                    clickonrectangle = true;
                }
                if (board[2] == 2 && board[4] == 0 && board[6] == 2 && turnCpu == false)
                {
                    if (Globals.CrossOrNougtP2 == 1)
                    {
                        buttonGpText5 = oImage;
                        board[4] = 2;
                        players = false;
                        turnCpu = true;
                        textureCount++;
                    }
                    if (Globals.CrossOrNougtP2 == 2)
                    {
                        buttonGpText5 = xImage;
                        board[4] = 2;
                        players = false;
                        turnCpu = true;
                        textureCount++;
                    }
                    clickonrectangle = true;
                }
                // Defense

                if (board[0] == 1 && board[1] == 1 && board[2] == 0 && turnCpu == false)
                {
                    if (Globals.CrossOrNougtP2 == 1)
                    {
                        buttonGpText3 = oImage;
                        board[2] = 2;
                        players = false;
                        turnCpu = true;
                        textureCount++;
                    }
                    if (Globals.CrossOrNougtP2 == 2)
                    {
                        buttonGpText3 = xImage;
                        board[2] = 2;
                        players = false;
                        turnCpu = true;
                        textureCount++;
                    }
                    clickonrectangle = true;
                }
                if (board[3] == 1 && board[4] == 1 && board[5] == 0 && turnCpu == false)
                {
                    if (Globals.CrossOrNougtP2 == 1)
                    {
                        buttonGpText6 = oImage;
                        board[5] = 2;
                        players = false;
                        turnCpu = true;
                        textureCount++;
                    }
                    if (Globals.CrossOrNougtP2 == 2)
                    {
                        buttonGpText6 = xImage;
                        board[5] = 2;
                        players = false;
                        turnCpu = true;
                        textureCount++;
                    }
                    clickonrectangle = true;
                }
                if (board[6] == 1 && board[7] == 1 && board[8] == 0 && turnCpu == false)
                {
                    if (Globals.CrossOrNougtP2 == 1)
                    {
                        buttonGpText9 = oImage;
                        board[8] = 2;
                        players = false;
                        turnCpu = true;
                        textureCount++;
                    }
                    if (Globals.CrossOrNougtP2 == 2)
                    {
                        buttonGpText9 = xImage;
                        board[8] = 2;
                        players = false;
                        turnCpu = true;
                        textureCount++;
                    }
                    clickonrectangle = true;
                }
                if (board[0] == 1 && board[3] == 1 && board[6] == 0 && turnCpu == false)
                {
                    if (Globals.CrossOrNougtP2 == 1)
                    {
                        buttonGpText7 = oImage;
                        board[6] = 2;
                        players = false;
                        turnCpu = true;
                        textureCount++;
                    }
                    if (Globals.CrossOrNougtP2 == 2)
                    {
                        buttonGpText7 = xImage;
                        board[6] = 2;
                        players = false;
                        turnCpu = true;
                        textureCount++;
                    }
                    clickonrectangle = true;
                }
                if (board[1] == 1 && board[4] == 1 && board[7] == 0 && turnCpu == false)
                {
                    if (Globals.CrossOrNougtP2 == 1)
                    {
                        buttonGpText8 = oImage;
                        board[7] = 2;
                        players = false;
                        turnCpu = true;
                        textureCount++;
                    }
                    if (Globals.CrossOrNougtP2 == 2)
                    {
                        buttonGpText8 = xImage;
                        board[7] = 2;
                        players = false;
                        turnCpu = true;
                        textureCount++;
                    }
                    clickonrectangle = true;
                }
                if (board[2] == 1 && board[5] == 1 && board[8] == 0 && turnCpu == false)
                {
                    if (Globals.CrossOrNougtP2 == 1)
                    {
                        buttonGpText9 = oImage;
                        board[8] = 2;
                        players = false;
                        turnCpu = true;
                        textureCount++;
                    }
                    if (Globals.CrossOrNougtP2 == 2)
                    {
                        buttonGpText9 = xImage;
                        board[8] = 2;
                        players = false;
                        turnCpu = true;
                        textureCount++;
                    }
                    clickonrectangle = true;
                }
                if (board[0] == 1 && board[4] == 1 && board[8] == 0 && turnCpu == false)
                {
                    if (Globals.CrossOrNougtP2 == 1)
                    {
                        buttonGpText9 = oImage;
                        board[8] = 2;
                        players = false;
                        turnCpu = true;
                        textureCount++;
                    }
                    if (Globals.CrossOrNougtP2 == 2)
                    {
                        buttonGpText9 = xImage;
                        board[8] = 2;
                        players = false;
                        turnCpu = true;
                        textureCount++;
                    }
                    clickonrectangle = true;
                }
                if (board[2] == 1 && board[4] == 1 && board[6] == 0 && turnCpu == false)
                {
                    if (Globals.CrossOrNougtP2 == 1)
                    {
                        buttonGpText7 = oImage;
                        board[6] = 2;
                        players = false;
                        turnCpu = true;
                        textureCount++;
                    }
                    if (Globals.CrossOrNougtP2 == 2)
                    {
                        buttonGpText7 = xImage;
                        board[6] = 2;
                        players = false;
                        turnCpu = true;
                        textureCount++;
                    }
                    clickonrectangle = true;
                }
                // reverse defense 
                if (board[0] == 0 && board[1] == 1 && board[2] == 1 && turnCpu == false)
                {
                    if (Globals.CrossOrNougtP2 == 1)
                    {
                        buttonGpText1 = oImage;
                        board[0] = 2;
                        players = false;
                        turnCpu = true;
                        textureCount++;
                    }
                    if (Globals.CrossOrNougtP2 == 2)
                    {
                        buttonGpText1 = xImage;
                        board[0] = 2;
                        players = false;
                        turnCpu = true;
                        textureCount++;
                    }
                    clickonrectangle = true;
                }
                if (board[3] == 0 && board[4] == 1 && board[5] == 1 && turnCpu == false)
                {
                    if (Globals.CrossOrNougtP2 == 1)
                    {
                        buttonGpText4 = oImage;
                        board[3] = 2;
                        players = false;
                        turnCpu = true;
                        textureCount++;
                    }
                    if (Globals.CrossOrNougtP2 == 2)
                    {
                        buttonGpText4 = xImage;
                        board[3] = 2;
                        players = false;
                        turnCpu = true;
                        textureCount++;
                    }
                    clickonrectangle = true;
                }
                if (board[6] == 0 && board[7] == 1 && board[8] == 1 && turnCpu == false)
                {
                    if (Globals.CrossOrNougtP2 == 1)
                    {
                        buttonGpText7 = oImage;
                        board[6] = 2;
                        players = false;
                        turnCpu = true;
                        textureCount++;
                    }
                    if (Globals.CrossOrNougtP2 == 2)
                    {
                        buttonGpText7 = xImage;
                        board[6] = 2;
                        players = false;
                        turnCpu = true;
                        textureCount++;
                    }
                    clickonrectangle = true;
                }
                if (board[0] == 0 && board[3] == 1 && board[6] == 1 && turnCpu == false)
                {
                    if (Globals.CrossOrNougtP2 == 1)
                    {
                        buttonGpText1 = oImage;
                        board[0] = 2;
                        players = false;
                        turnCpu = true;
                        textureCount++;
                    }
                    if (Globals.CrossOrNougtP2 == 2)
                    {
                        buttonGpText1 = xImage;
                        board[0] = 2;
                        players = false;
                        turnCpu = true;
                        textureCount++;
                    }
                    clickonrectangle = true;
                }
                if (board[1] == 0 && board[4] == 1 && board[7] == 1 && turnCpu == false)
                {
                    if (Globals.CrossOrNougtP2 == 1)
                    {
                        buttonGpText2 = oImage;
                        board[1] = 2;
                        players = false;
                        turnCpu = true;
                        textureCount++;
                    }
                    if (Globals.CrossOrNougtP2 == 2)
                    {
                        buttonGpText2 = xImage;
                        board[1] = 2;
                        players = false;
                        turnCpu = true;
                        textureCount++;
                    }
                    clickonrectangle = true;
                }
                if (board[2] == 0 && board[5] == 1 && board[8] == 1 && turnCpu == false)
                {
                    if (Globals.CrossOrNougtP2 == 1)
                    {
                        buttonGpText3 = oImage;
                        board[2] = 2;
                        players = false;
                        turnCpu = true;
                        textureCount++;
                    }
                    if (Globals.CrossOrNougtP2 == 2)
                    {
                        buttonGpText3 = xImage;
                        board[2] = 2;
                        players = false;
                        turnCpu = true;
                        textureCount++;
                    }
                    clickonrectangle = true;
                }
                if (board[0] == 0 && board[4] == 1 && board[8] == 1 && turnCpu == false)
                {
                    if (Globals.CrossOrNougtP2 == 1)
                    {
                        buttonGpText1 = oImage;
                        board[0] = 2;
                        players = false;
                        turnCpu = true;
                        textureCount++;
                    }
                    if (Globals.CrossOrNougtP2 == 2)
                    {
                        buttonGpText1 = xImage;
                        board[0] = 2;
                        players = false;
                        turnCpu = true;
                        textureCount++;
                    }
                    clickonrectangle = true;
                }
                if (board[2] == 0 && board[4] == 1 && board[6] == 1 && turnCpu == false)
                {
                    if (Globals.CrossOrNougtP2 == 1)
                    {
                        buttonGpText3 = oImage;
                        board[2] = 2;
                        players = false;
                        turnCpu = true;
                        textureCount++;
                    }
                    if (Globals.CrossOrNougtP2 == 2)
                    {
                        buttonGpText3 = xImage;
                        board[2] = 2;
                        players = false;
                        turnCpu = true;
                        textureCount++;
                    }
                    clickonrectangle = true;
                }
                // middle defense
                if (board[0] == 1 && board[1] == 0 && board[2] == 1 && turnCpu == false)
                {
                    if (Globals.CrossOrNougtP2 == 1)
                    {
                        buttonGpText2 = oImage;
                        board[1] = 2;
                        players = false;
                        turnCpu = true;
                        textureCount++;
                    }
                    if (Globals.CrossOrNougtP2 == 2)
                    {
                        buttonGpText2 = xImage;
                        board[1] = 2;
                        players = false;
                        turnCpu = true;
                        textureCount++;
                    }
                    clickonrectangle = true;
                }
                if (board[3] == 1 && board[4] == 0 && board[5] == 1 && turnCpu == false)
                {
                    if (Globals.CrossOrNougtP2 == 1)
                    {
                        buttonGpText5 = oImage;
                        board[4] = 2;
                        players = false;
                        turnCpu = true;
                        textureCount++;
                    }
                    if (Globals.CrossOrNougtP2 == 2)
                    {
                        buttonGpText5 = xImage;
                        board[4] = 2;
                        players = false;
                        turnCpu = true;
                        textureCount++;
                    }
                    clickonrectangle = true;
                }
                if (board[6] == 1 && board[7] == 0 && board[8] == 1 && turnCpu == false)
                {
                    if (Globals.CrossOrNougtP2 == 1)
                    {
                        buttonGpText8 = oImage;
                        board[7] = 2;
                        players = false;
                        turnCpu = true;
                        textureCount++;
                    }
                    if (Globals.CrossOrNougtP2 == 2)
                    {
                        buttonGpText8 = xImage;
                        board[7] = 2;
                        players = false;
                        turnCpu = true;
                        textureCount++;
                    }
                    clickonrectangle = true;
                }
                if (board[0] == 1 && board[3] == 0 && board[6] == 1 && turnCpu == false)
                {
                    if (Globals.CrossOrNougtP2 == 1)
                    {
                        buttonGpText4 = oImage;
                        board[3] = 2;
                        players = false;
                        turnCpu = true;
                        textureCount++;
                    }
                    if (Globals.CrossOrNougtP2 == 2)
                    {
                        buttonGpText4 = xImage;
                        board[3] = 2;
                        players = false;
                        turnCpu = true;
                        textureCount++;
                    }
                    clickonrectangle = true;
                }
                if (board[1] == 1 && board[4] == 0 && board[7] == 1 && turnCpu == false)
                {
                    if (Globals.CrossOrNougtP2 == 1)
                    {
                        buttonGpText5 = oImage;
                        board[4] = 2;
                        players = false;
                        turnCpu = true;
                        textureCount++;
                    }
                    if (Globals.CrossOrNougtP2 == 2)
                    {
                        buttonGpText5 = xImage;
                        board[4] = 2;
                        players = false;
                        turnCpu = true;
                        textureCount++;
                    }
                    clickonrectangle = true;
                }
                if (board[2] == 1 && board[5] == 0 && board[8] == 1 && turnCpu == false)
                {
                    if (Globals.CrossOrNougtP2 == 1)
                    {
                        buttonGpText6 = oImage;
                        board[5] = 2;
                        players = false;
                        turnCpu = true;
                        textureCount++;
                    }
                    if (Globals.CrossOrNougtP2 == 2)
                    {
                        buttonGpText6 = xImage;
                        board[5] = 2;
                        players = false;
                        turnCpu = true;
                        textureCount++;
                    }
                    clickonrectangle = true;
                }
                if (board[0] == 1 && board[4] == 0 && board[8] == 1 && turnCpu == false)
                {
                    if (Globals.CrossOrNougtP2 == 1)
                    {
                        buttonGpText5 = oImage;
                        board[4] = 2;
                        players = false;
                        turnCpu = true;
                        textureCount++;
                    }
                    if (Globals.CrossOrNougtP2 == 2)
                    {
                        buttonGpText5 = xImage;
                        board[4] = 2;
                        players = false;
                        turnCpu = true;
                        textureCount++;
                    }
                    clickonrectangle = true;
                }
                if (board[2] == 1 && board[4] == 0 && board[6] == 1 && turnCpu == false)
                {
                    if (Globals.CrossOrNougtP2 == 1)
                    {
                        buttonGpText5 = oImage;
                        board[4] = 2;
                        players = false;
                        turnCpu = true;
                        textureCount++;
                    }
                    if (Globals.CrossOrNougtP2 == 2)
                    {
                        buttonGpText5 = xImage;
                        board[4] = 2;
                        players = false;
                        turnCpu = true;
                        textureCount++;
                    }
                    clickonrectangle = true;
                }

                // atack
                if (board[0] == 2 && board[1] == 0 && board[2] == 0 && turnCpu == false)
                {
                    if (Globals.CrossOrNougtP2 == 1)
                    {
                        buttonGpText3 = oImage;
                        board[2] = 2;
                        players = false;
                        turnCpu = true;
                        textureCount++;
                    }
                    if (Globals.CrossOrNougtP2 == 2)
                    {
                        buttonGpText3 = xImage;
                        board[2] = 2;
                        players = false;
                        turnCpu = true;
                        textureCount++;
                    }
                    clickonrectangle = true;
                }
                if (board[3] == 2 && board[4] == 0 && board[5] == 0 && turnCpu == false)
                {
                    if (Globals.CrossOrNougtP2 == 1)
                    {
                        buttonGpText6 = oImage;
                        board[5] = 2;
                        players = false;
                        turnCpu = true;
                        textureCount++;
                    }
                    if (Globals.CrossOrNougtP2 == 2)
                    {
                        buttonGpText6 = xImage;
                        board[5] = 2;
                        players = false;
                        turnCpu = true;
                        textureCount++;
                    }
                    clickonrectangle = true;
                }
                if (board[6] == 2 && board[7] == 0 && board[8] == 0 && turnCpu == false)
                {
                    if (Globals.CrossOrNougtP2 == 1)
                    {
                        buttonGpText9 = oImage;
                        board[8] = 2;
                        players = false;
                        turnCpu = true;
                        textureCount++;
                    }
                    if (Globals.CrossOrNougtP2 == 2)
                    {
                        buttonGpText9 = xImage;
                        board[8] = 2;
                        players = false;
                        turnCpu = true;
                        textureCount++;
                    }
                    clickonrectangle = true;
                }
                if (board[0] == 2 && board[3] == 0 && board[6] == 0 && turnCpu == false)
                {
                    if (Globals.CrossOrNougtP2 == 1)
                    {
                        buttonGpText7 = oImage;
                        board[6] = 2;
                        players = false;
                        turnCpu = true;
                        textureCount++;
                    }
                    if (Globals.CrossOrNougtP2 == 2)
                    {
                        buttonGpText7 = xImage;
                        board[6] = 2;
                        players = false;
                        turnCpu = true;
                        textureCount++;
                    }
                    clickonrectangle = true;
                }
                if (board[1] == 2 && board[4] == 0 && board[7] == 0 && turnCpu == false)
                {
                    if (Globals.CrossOrNougtP2 == 1)
                    {
                        buttonGpText8 = oImage;
                        board[7] = 2;
                        players = false;
                        turnCpu = true;
                        textureCount++;
                    }
                    if (Globals.CrossOrNougtP2 == 2)
                    {
                        buttonGpText8 = xImage;
                        board[7] = 2;
                        players = false;
                        turnCpu = true;
                        textureCount++;
                    }
                    clickonrectangle = true;
                }
                if (board[2] == 2 && board[5] == 0 && board[8] == 0 && turnCpu == false)
                {
                    if (Globals.CrossOrNougtP2 == 1)
                    {
                        buttonGpText9 = oImage;
                        board[8] = 2;
                        players = false;
                        turnCpu = true;
                        textureCount++;
                    }
                    if (Globals.CrossOrNougtP2 == 2)
                    {
                        buttonGpText9 = xImage;
                        board[8] = 2;
                        players = false;
                        turnCpu = true;
                        textureCount++;
                    }
                    clickonrectangle = true;
                }
                if (board[0] == 2 && board[4] == 0 && board[8] == 0 && turnCpu == false)
                {
                    if (Globals.CrossOrNougtP2 == 1)
                    {
                        buttonGpText9 = oImage;
                        board[8] = 2;
                        players = false;
                        turnCpu = true;
                        textureCount++;
                    }
                    if (Globals.CrossOrNougtP2 == 2)
                    {
                        buttonGpText9 = xImage;
                        board[8] = 2;
                        players = false;
                        turnCpu = true;
                        textureCount++;
                    }
                    clickonrectangle = true;
                }
                if (board[2] == 2 && board[4] == 0 && board[6] == 0 && turnCpu == false)
                {
                    if (Globals.CrossOrNougtP2 == 1)
                    {
                        buttonGpText7 = oImage;
                        board[6] = 2;
                        players = false;
                        turnCpu = true;
                        textureCount++;
                    }
                    if (Globals.CrossOrNougtP2 == 2)
                    {
                        buttonGpText7 = xImage;
                        board[6] = 2;
                        players = false;
                        turnCpu = true;
                        textureCount++;
                    }
                    clickonrectangle = true;
                }
                // reverse attack 
                if (board[0] == 0 && board[1] == 0 && board[2] == 2 && turnCpu == false)
                {
                    if (Globals.CrossOrNougtP2 == 1)
                    {
                        buttonGpText1 = oImage;
                        board[0] = 2;
                        players = false;
                        turnCpu = true;
                        textureCount++;
                    }
                    if (Globals.CrossOrNougtP2 == 2)
                    {
                        buttonGpText1 = xImage;
                        board[0] = 2;
                        players = false;
                        turnCpu = true;
                        textureCount++;
                    }
                    clickonrectangle = true;
                }
                if (board[3] == 0 && board[4] == 0 && board[5] == 2 && turnCpu == false)
                {
                    if (Globals.CrossOrNougtP2 == 1)
                    {
                        buttonGpText4 = oImage;
                        board[3] = 2;
                        players = false;
                        turnCpu = true;
                        textureCount++;
                    }
                    if (Globals.CrossOrNougtP2 == 2)
                    {
                        buttonGpText4 = xImage;
                        board[3] = 2;
                        players = false;
                        turnCpu = true;
                        textureCount++;
                    }
                    clickonrectangle = true;
                }
                if (board[6] == 0 && board[7] == 0 && board[8] == 2 && turnCpu == false)
                {
                    if (Globals.CrossOrNougtP2 == 1)
                    {
                        buttonGpText7 = oImage;
                        board[6] = 2;
                        players = false;
                        turnCpu = true;
                        textureCount++;
                    }
                    if (Globals.CrossOrNougtP2 == 2)
                    {
                        buttonGpText7 = xImage;
                        board[6] = 2;
                        players = false;
                        turnCpu = true;
                        textureCount++;
                    }
                    clickonrectangle = true;
                }
                if (board[0] == 0 && board[3] == 0 && board[6] == 2 && turnCpu == false)
                {
                    if (Globals.CrossOrNougtP2 == 1)
                    {
                        buttonGpText1 = oImage;
                        board[0] = 2;
                        players = false;
                        turnCpu = true;
                        textureCount++;
                    }
                    if (Globals.CrossOrNougtP2 == 2)
                    {
                        buttonGpText1 = xImage;
                        board[0] = 2;
                        players = false;
                        turnCpu = true;
                        textureCount++;
                    }
                    clickonrectangle = true;
                }
                if (board[1] == 0 && board[4] == 0 && board[7] == 2 && turnCpu == false)
                {
                    if (Globals.CrossOrNougtP2 == 1)
                    {
                        buttonGpText2 = oImage;
                        board[1] = 2;
                        players = false;
                        turnCpu = true;
                        textureCount++;
                    }
                    if (Globals.CrossOrNougtP2 == 2)
                    {
                        buttonGpText2 = xImage;
                        board[1] = 2;
                        players = false;
                        turnCpu = true;
                        textureCount++;
                    }
                    clickonrectangle = true;
                }
                if (board[2] == 0 && board[5] == 0 && board[8] == 2 && turnCpu == false)
                {
                    if (Globals.CrossOrNougtP2 == 1)
                    {
                        buttonGpText3 = oImage;
                        board[2] = 2;
                        players = false;
                        turnCpu = true;
                        textureCount++;
                    }
                    if (Globals.CrossOrNougtP2 == 2)
                    {
                        buttonGpText3 = xImage;
                        board[2] = 2;
                        players = false;
                        turnCpu = true;
                        textureCount++;
                    }
                    clickonrectangle = true;
                }
                if (board[0] == 0 && board[4] == 0 && board[8] == 2 && turnCpu == false)
                {
                    if (Globals.CrossOrNougtP2 == 1)
                    {
                        buttonGpText1 = oImage;
                        board[0] = 2;
                        players = false;
                        turnCpu = true;
                        textureCount++;
                    }
                    if (Globals.CrossOrNougtP2 == 2)
                    {
                        buttonGpText1 = xImage;
                        board[0] = 2;
                        players = false;
                        turnCpu = true;
                        textureCount++;
                    }
                    clickonrectangle = true;
                }
                if (board[2] == 0 && board[4] == 0 && board[6] == 2 && turnCpu == false)
                {
                    if (Globals.CrossOrNougtP2 == 1)
                    {
                        buttonGpText3 = oImage;
                        board[2] = 2;
                        players = false;
                        turnCpu = true;
                        textureCount++;
                    }
                    if (Globals.CrossOrNougtP2 == 2)
                    {
                        buttonGpText3 = xImage;
                        board[2] = 2;
                        players = false;
                        turnCpu = true;
                        textureCount++;
                    }
                    clickonrectangle = true;
                }
                // middle attack
                if (board[0] == 0 && board[1] == 2 && board[2] == 0 && turnCpu == false)
                {
                    if (Globals.CrossOrNougtP2 == 1)
                    {
                        buttonGpText3 = oImage;
                        board[2] = 2;
                        players = false;
                        turnCpu = true;
                        textureCount++;
                    }
                    if (Globals.CrossOrNougtP2 == 2)
                    {
                        buttonGpText3 = xImage;
                        board[2] = 2;
                        players = false;
                        turnCpu = true;
                        textureCount++;
                    }
                    clickonrectangle = true;
                }
                if (board[3] == 0 && board[4] == 2 && board[5] == 0 && turnCpu == false)
                {
                    if (Globals.CrossOrNougtP2 == 1)
                    {
                        buttonGpText4 = oImage;
                        board[3] = 2;
                        players = false;
                        turnCpu = true;
                        textureCount++;
                    }
                    if (Globals.CrossOrNougtP2 == 2)
                    {
                        buttonGpText4 = xImage;
                        board[3] = 2;
                        players = false;
                        turnCpu = true;
                        textureCount++;
                    }
                    clickonrectangle = true;
                }
                if (board[6] == 0 && board[7] == 2 && board[8] == 0 && turnCpu == false)
                {
                    if (Globals.CrossOrNougtP2 == 1)
                    {
                        buttonGpText9 = oImage;
                        board[8] = 2;
                        players = false;
                        turnCpu = true;
                        textureCount++;
                    }
                    if (Globals.CrossOrNougtP2 == 2)
                    {
                        buttonGpText9 = xImage;
                        board[8] = 2;
                        players = false;
                        turnCpu = true;
                        textureCount++;
                    }
                    clickonrectangle = true;
                }
                if (board[0] == 0 && board[3] == 2 && board[6] == 0 && turnCpu == false)
                {
                    if (Globals.CrossOrNougtP2 == 1)
                    {
                        buttonGpText1 = oImage;
                        board[0] = 2;
                        players = false;
                        turnCpu = true;
                        textureCount++;
                    }
                    if (Globals.CrossOrNougtP2 == 2)
                    {
                        buttonGpText1 = xImage;
                        board[0] = 2;
                        players = false;
                        turnCpu = true;
                        textureCount++;
                    }
                    clickonrectangle = true;
                }
                if (board[1] == 0 && board[4] == 2 && board[7] == 0 && turnCpu == false)
                {
                    if (Globals.CrossOrNougtP2 == 1)
                    {
                        buttonGpText8 = oImage;
                        board[7] = 2;
                        players = false;
                        turnCpu = true;
                        textureCount++;
                    }
                    if (Globals.CrossOrNougtP2 == 2)
                    {
                        buttonGpText8 = xImage;
                        board[7] = 2;
                        players = false;
                        turnCpu = true;
                        textureCount++;
                    }
                    clickonrectangle = true;
                }
                if (board[2] == 0 && board[5] == 2 && board[8] == 0 && turnCpu == false)
                {
                    if (Globals.CrossOrNougtP2 == 1)
                    {
                        buttonGpText3 = oImage;
                        board[2] = 2;
                        players = false;
                        turnCpu = true;
                        textureCount++;
                    }
                    if (Globals.CrossOrNougtP2 == 2)
                    {
                        buttonGpText3 = xImage;
                        board[2] = 2;
                        players = false;
                        turnCpu = true;
                        textureCount++;
                    }
                    clickonrectangle = true;
                }
                if (board[0] == 0 && board[4] == 2 && board[8] == 0 && turnCpu == false)
                {
                    if (Globals.CrossOrNougtP2 == 1)
                    {
                        buttonGpText9 = oImage;
                        board[8] = 2;
                        players = false;
                        turnCpu = true;
                        textureCount++;
                    }
                    if (Globals.CrossOrNougtP2 == 2)
                    {
                        buttonGpText9 = xImage;
                        board[8] = 2;
                        players = false;
                        turnCpu = true;
                        textureCount++;
                    }
                    clickonrectangle = true;
                }
                if (board[2] == 0 && board[4] == 2 && board[6] == 0 && turnCpu == false)
                {
                    if (Globals.CrossOrNougtP2 == 1)
                    {
                        buttonGpText3 = oImage;
                        board[2] = 2;
                        players = false;
                        turnCpu = true;
                        textureCount++;
                    }
                    if (Globals.CrossOrNougtP2 == 2)
                    {
                        buttonGpText3 = xImage;
                        board[2] = 2;
                        players = false;
                        turnCpu = true;
                        textureCount++;
                    }
                    clickonrectangle = true;
                }

                // Randomly type 1
                if (board[0] == 0 && board[1] == 0 && board[2] == 0 && board[3] == 0 && board[4] == 0
                     && board[5] == 0 && board[6] == 0 && board[7] == 0 && board[8] == 0)
                {
                    randomlycpu = randomStartCpu.Next(1, 10);

                    switch (Globals.CrossOrNougtP2)
                    {
                        case 1:
                            switch (randomlycpu)
                            {
                                case 1:
                                    buttonGpText1 = oImage;
                                    board[0] = 2;
                                    players = false;
                                    turnCpu = true;
                                    textureCount++;
                                    break;
                                case 2:
                                    buttonGpText2 = oImage;
                                    board[1] = 2;
                                    players = false;
                                    turnCpu = true;
                                    textureCount++;
                                    break;
                                case 3:
                                    buttonGpText3 = oImage;
                                    board[2] = 2;
                                    players = false;
                                    turnCpu = true;
                                    textureCount++;
                                    break;
                                case 4:
                                    buttonGpText4 = oImage;
                                    board[3] = 2;
                                    players = false;
                                    turnCpu = true;
                                    textureCount++;
                                    break;
                                case 5:
                                    buttonGpText5 = oImage;
                                    board[4] = 2;
                                    players = false;
                                    turnCpu = true;
                                    textureCount++;
                                    break;
                                case 6:
                                    buttonGpText6 = oImage;
                                    board[5] = 2;
                                    players = false;
                                    turnCpu = true;
                                    textureCount++;
                                    break;
                                case 7:
                                    buttonGpText7 = oImage;
                                    board[6] = 2;
                                    players = false;
                                    turnCpu = true;
                                    textureCount++;
                                    break;
                                case 8:
                                    buttonGpText8 = oImage;
                                    board[7] = 2;
                                    players = false;
                                    turnCpu = true;
                                    textureCount++;
                                    break;
                                case 9:
                                    buttonGpText9 = oImage;
                                    board[8] = 2;
                                    players = false;
                                    turnCpu = true;
                                    textureCount++;
                                    break;
                                default:
                                    break;
                            }
                            break;
                        case 2:
                            switch (randomlycpu)
                            {
                                case 1:
                                    buttonGpText1 = xImage;
                                    board[0] = 2;
                                    players = false;
                                    turnCpu = true;
                                    textureCount++;
                                    break;
                                case 2:
                                    buttonGpText2 = xImage;
                                    board[1] = 2;
                                    players = false;
                                    turnCpu = true;
                                    textureCount++;
                                    break;
                                case 3:
                                    buttonGpText3 = xImage;
                                    board[2] = 2;
                                    players = false;
                                    turnCpu = true;
                                    textureCount++;
                                    break;
                                case 4:
                                    buttonGpText4 = xImage;
                                    board[3] = 2;
                                    players = false;
                                    turnCpu = true;
                                    textureCount++;
                                    break;
                                case 5:
                                    buttonGpText5 = xImage;
                                    board[4] = 2;
                                    players = false;
                                    turnCpu = true;
                                    textureCount++;
                                    break;
                                case 6:
                                    buttonGpText6 = xImage;
                                    board[5] = 2;
                                    players = false;
                                    turnCpu = true;
                                    textureCount++;
                                    break;
                                case 7:
                                    buttonGpText7 = xImage;
                                    board[6] = 2;
                                    players = false;
                                    turnCpu = true;
                                    textureCount++;
                                    break;
                                case 8:
                                    buttonGpText8 = xImage;
                                    board[7] = 2;
                                    players = false;
                                    turnCpu = true;
                                    textureCount++;
                                    break;
                                case 9:
                                    buttonGpText9 = xImage;
                                    board[8] = 2;
                                    players = false;
                                    turnCpu = true;
                                    textureCount++;
                                    break;
                                default:
                                    break;
                            }
                            break;
                        default:
                            break;
                    }
                    clickonrectangle = true;

                }

                // Randomly type 2
                while (randomlyLoop == true && turnCpu == false)
                {
                    randomlycpu = randomStartCpu.Next(1, 10);

                    if (board[randomlycpu - 1] == 0)
                    {
                        switch (Globals.CrossOrNougtP2)
                        {
                            case 1:
                                switch (randomlycpu)
                                {
                                    case 1:
                                        buttonGpText1 = oImage;
                                        board[0] = 2;
                                        players = false;
                                        turnCpu = true;
                                        randomlyLoop = false;
                                        textureCount++;
                                        break;
                                    case 2:
                                        buttonGpText2 = oImage;
                                        board[1] = 2;
                                        players = false;
                                        turnCpu = true;
                                        randomlyLoop = false;
                                        textureCount++;
                                        break;
                                    case 3:
                                        buttonGpText3 = oImage;
                                        board[2] = 2;
                                        players = false;
                                        turnCpu = true;
                                        randomlyLoop = false;
                                        textureCount++;
                                        break;
                                    case 4:
                                        buttonGpText4 = oImage;
                                        board[3] = 2;
                                        players = false;
                                        turnCpu = true;
                                        randomlyLoop = false;
                                        textureCount++;
                                        break;
                                    case 5:
                                        buttonGpText5 = oImage;
                                        board[4] = 2;
                                        players = false;
                                        turnCpu = true;
                                        randomlyLoop = false;
                                        textureCount++;
                                        break;
                                    case 6:
                                        buttonGpText6 = oImage;
                                        board[5] = 2;
                                        players = false;
                                        turnCpu = true;
                                        randomlyLoop = false;
                                        textureCount++;
                                        break;
                                    case 7:
                                        buttonGpText7 = oImage;
                                        board[6] = 2;
                                        players = false;
                                        turnCpu = true;
                                        randomlyLoop = false;
                                        textureCount++;
                                        break;
                                    case 8:
                                        buttonGpText8 = oImage;
                                        board[7] = 2;
                                        players = false;
                                        turnCpu = true;
                                        randomlyLoop = false;
                                        textureCount++;
                                        break;
                                    case 9:
                                        buttonGpText9 = oImage;
                                        board[8] = 2;
                                        players = false;
                                        turnCpu = true;
                                        randomlyLoop = false;
                                        textureCount++;
                                        break;
                                    default:
                                        break;
                                }
                                break;
                            case 2:
                                switch (randomlycpu)
                                {
                                    case 1:
                                        buttonGpText1 = xImage;
                                        board[0] = 2;
                                        players = false;
                                        turnCpu = true;
                                        randomlyLoop = false;
                                        textureCount++;
                                        break;
                                    case 2:
                                        buttonGpText2 = xImage;
                                        board[1] = 2;
                                        players = false;
                                        turnCpu = true;
                                        randomlyLoop = false;
                                        textureCount++;
                                        break;
                                    case 3:
                                        buttonGpText3 = xImage;
                                        board[2] = 2;
                                        players = false;
                                        turnCpu = true;
                                        randomlyLoop = false;
                                        textureCount++;
                                        break;
                                    case 4:
                                        buttonGpText4 = xImage;
                                        board[3] = 2;
                                        players = false;
                                        turnCpu = true;
                                        randomlyLoop = false;
                                        textureCount++;
                                        break;
                                    case 5:
                                        buttonGpText5 = xImage;
                                        board[4] = 2;
                                        players = false;
                                        turnCpu = true;
                                        randomlyLoop = false;
                                        textureCount++;
                                        break;
                                    case 6:
                                        buttonGpText6 = xImage;
                                        board[5] = 2;
                                        players = false;
                                        turnCpu = true;
                                        randomlyLoop = false;
                                        textureCount++;
                                        break;
                                    case 7:
                                        buttonGpText7 = xImage;
                                        board[6] = 2;
                                        players = false;
                                        turnCpu = true;
                                        randomlyLoop = false;
                                        textureCount++;
                                        break;
                                    case 8:
                                        buttonGpText8 = xImage;
                                        board[7] = 2;
                                        players = false;
                                        turnCpu = true;
                                        randomlyLoop = false;
                                        textureCount++;
                                        break;
                                    case 9:
                                        buttonGpText9 = xImage;
                                        board[8] = 2;
                                        players = false;
                                        turnCpu = true;
                                        randomlyLoop = false;
                                        textureCount++;
                                        break;
                                    default:
                                        break;
                                }
                                break;
                            default:
                                break;
                        }
                        clickonrectangle = true;
                    }
                }
                sNoughts.CreateInstance().Play();
                sNoughts.CreateInstance().Stop();
            };
        }
        void WinAndDrawL()
        {
            //Win and draw count//

            //Win player1(X) and Win player2(O)

            if (buttonGpText1 == xImage && buttonGpText2 == xImage && buttonGpText3 == xImage
                    || buttonGpText1 == oImage && buttonGpText2 == oImage && buttonGpText3 == oImage)
            {
                if (buttonGpText1 == xImage)
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
            if (buttonGpText1 == xImage && buttonGpText5 == xImage && buttonGpText9 == xImage
                    || buttonGpText1 == oImage && buttonGpText5 == oImage && buttonGpText9 == oImage)
            {
                if (buttonGpText1 == xImage)
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
            if (buttonGpText1 == xImage && buttonGpText4 == xImage && buttonGpText7 == xImage
                    || buttonGpText1 == oImage && buttonGpText4 == oImage && buttonGpText7 == oImage)
            {
                if (buttonGpText1 == xImage)
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
            if (buttonGpText3 == xImage && buttonGpText5 == xImage && buttonGpText7 == xImage
                    || buttonGpText3 == oImage && buttonGpText5 == oImage && buttonGpText7 == oImage)
            {
                if (buttonGpText3 == xImage)
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
            if (buttonGpText3 == xImage && buttonGpText6 == xImage && buttonGpText9 == xImage
                    || buttonGpText3 == oImage && buttonGpText6 == oImage && buttonGpText9 == oImage)
            {
                if (buttonGpText3 == xImage)
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
            if (buttonGpText5 == xImage && buttonGpText4 == xImage && buttonGpText6 == xImage
                    || buttonGpText5 == oImage && buttonGpText4 == oImage && buttonGpText6 == oImage)
            {
                if (buttonGpText5 == xImage)
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
            if (buttonGpText5 == xImage && buttonGpText2 == xImage && buttonGpText8 == xImage
                    || buttonGpText5 == oImage && buttonGpText2 == oImage && buttonGpText8 == oImage)
            {
                if (buttonGpText5 == xImage)
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
            if (buttonGpText7 == xImage && buttonGpText8 == xImage && buttonGpText9 == xImage
                  || buttonGpText7 == oImage && buttonGpText8 == oImage && buttonGpText9 == oImage)
            {
                if (buttonGpText7 == xImage)
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
                    tied = true;
                    onePointD = true;

                }
            }
            switch (Globals.RoundsPoints)
            {
                case 1:
                    if (winsPX == 1)
                    {
                        if (Globals.CrossOrNougtP1 == 1)
                        {
                            victoryPoints = 1;
                            thereIsAWinner = true;
                        }

                        if (Globals.CrossOrNougtP1 == 2)
                        {
                            victoryPoints = 1;
                            thereIsAWinner = true;
                        }
                    }
                    if (winsPO == 1)
                    {
                        if (Globals.CrossOrNougtP2 == 1)
                        {
                            victoryPoints = 2;
                            thereIsAWinner = true;
                        }

                        if (Globals.CrossOrNougtP2 == 2)
                        {
                            victoryPoints = 2;
                            thereIsAWinner = true;
                        }
                    }
                    break;
                case 3:
                    if (winsPX == 2)
                    {
                        if (Globals.CrossOrNougtP1 == 1)
                        {
                            victoryPoints = 1;
                            thereIsAWinner = true;
                        }

                        if (Globals.CrossOrNougtP1 == 2)
                        {
                            victoryPoints = 1;
                            thereIsAWinner = true;
                        }

                    }
                    if (winsPO == 2)
                    {
                        if (Globals.CrossOrNougtP2 == 1)
                        {
                            victoryPoints = 2;
                            thereIsAWinner = true;
                        }

                        if (Globals.CrossOrNougtP2 == 2)
                        {
                            victoryPoints = 2;
                            thereIsAWinner = true;
                        }
                    }
                    break;
                case 5:
                    if (winsPX == 3)
                    {
                        if (Globals.CrossOrNougtP1 == 1)
                        {
                            victoryPoints = 1;
                            thereIsAWinner = true;
                        }

                        if (Globals.CrossOrNougtP1 == 2)
                        {
                            victoryPoints = 1;
                            thereIsAWinner = true;
                        }

                    }
                    if (winsPO == 3)
                    {
                        if (Globals.CrossOrNougtP2 == 1)
                        {
                            victoryPoints = 2;
                            thereIsAWinner = true;
                        }

                        if (Globals.CrossOrNougtP2 == 2)
                        {
                            victoryPoints = 2;
                            thereIsAWinner = true;
                        }
                    }
                    break;
                default:

                    break;
            }
            victorys = winsPX + winsPO;

        }
        void ButtonInterfaceL()
        {
            //Next Round Logic:
            if (mouseState.LeftButton == ButtonState.Pressed && nextRoundRect.Contains(mouseState.Position))
            {
                shadeInterface1 = Color.DarkGray;
            }
            else
            {
                shadeInterface1 = Color.White;
            }
            if (previousMouseState.LeftButton == ButtonState.Pressed && mouseState.LeftButton == ButtonState.Released
                && nextRoundRect.Contains(mouseState.Position) && (winner == true || tied == true))
            {
                buttonGpText1 = buttonDefault;
                buttonGpText2 = buttonDefault;
                buttonGpText3 = buttonDefault;
                buttonGpText4 = buttonDefault;
                buttonGpText5 = buttonDefault;
                buttonGpText6 = buttonDefault;
                buttonGpText7 = buttonDefault;
                buttonGpText8 = buttonDefault;
                buttonGpText9 = buttonDefault;
                board[0] = 0;
                board[1] = 0;
                board[2] = 0;
                board[3] = 0;
                board[4] = 0;
                board[5] = 0;
                board[6] = 0;
                board[7] = 0;
                board[8] = 0;
                onePointW = false;
                onePointD = false;
                winner = false;
                tied = false;
                Globals.VictoryOrDraw = false;
                textureCount = 0;
                notRepeatstart = false;
                timer = 0;
            }
            // Open Window
            if (mouseState.LeftButton == ButtonState.Pressed && OandMMRect.Contains(mouseState.Position))
            {
                buttonOandMM = true;
            }

        }
        void OandMML()
        {
            // Exit Window
            if (mouseState.LeftButton == ButtonState.Pressed && exitOptionsRect.Contains(mouseState.Position))
            {
                buttonOandMM = false;
            }
            // Buttons Window
            if (mouseState.LeftButton == ButtonState.Pressed && mainMenuRect.Contains(mouseState.Position))
            {
                Globals.MainMenu = true;
                buttonOandMM = false;
                buttonGpText1 = buttonDefault;
                buttonGpText2 = buttonDefault;
                buttonGpText3 = buttonDefault;
                buttonGpText4 = buttonDefault;
                buttonGpText5 = buttonDefault;
                buttonGpText6 = buttonDefault;
                buttonGpText7 = buttonDefault;
                buttonGpText8 = buttonDefault;
                buttonGpText9 = buttonDefault;
                onePointW = false;
                onePointD = false;
                winner = false;
                tied = false;
                Globals.VictoryOrDraw = false;
                textureCount = 0;
                winsPX = 0;
                winsPO = 0;
                drawP = 0;
                thereIsAWinner = false;
                switchChoose = true;
                notRepeatstart = false;
            }
            if (mouseState.LeftButton == ButtonState.Pressed && optionsRect.Contains(mouseState.Position))
            {
                Globals.MainMenuOrGame = 2;
                Globals.Options = true;

            }

        }
        void VictoryL()
        {
            // retry game button
            if (mouseState.LeftButton == ButtonState.Pressed && retryRect.Contains(mouseState.Position))
            {
                buttonGpText1 = buttonDefault;
                buttonGpText2 = buttonDefault;
                buttonGpText3 = buttonDefault;
                buttonGpText4 = buttonDefault;
                buttonGpText5 = buttonDefault;
                buttonGpText6 = buttonDefault;
                buttonGpText7 = buttonDefault;
                buttonGpText8 = buttonDefault;
                buttonGpText9 = buttonDefault;
                board[0] = 0;
                board[1] = 0;
                board[2] = 0;
                board[3] = 0;
                board[4] = 0;
                board[5] = 0;
                board[6] = 0;
                board[7] = 0;
                board[8] = 0;
                onePointW = false;
                onePointD = false;
                winner = false;
                tied = false;
                Globals.VictoryOrDraw = false;
                textureCount = 0;
                winsPX = 0;
                winsPO = 0;
                drawP = 0;
                thereIsAWinner = false;
                timer = 0;
            }
            // select button
            if (mouseState.LeftButton == ButtonState.Pressed && selectRect.Contains(mouseState.Position))
            {
                buttonGpText1 = buttonDefault;
                buttonGpText2 = buttonDefault;
                buttonGpText3 = buttonDefault;
                buttonGpText4 = buttonDefault;
                buttonGpText5 = buttonDefault;
                buttonGpText6 = buttonDefault;
                buttonGpText7 = buttonDefault;
                buttonGpText8 = buttonDefault;
                buttonGpText9 = buttonDefault;
                board[0] = 0;
                board[1] = 0;
                board[2] = 0;
                board[3] = 0;
                board[4] = 0;
                board[5] = 0;
                board[6] = 0;
                board[7] = 0;
                board[8] = 0;
                onePointW = false;
                onePointD = false;
                winner = false;
                tied = false;
                Globals.VictoryOrDraw = false;
                textureCount = 0;
                winsPX = 0;
                winsPO = 0;
                drawP = 0;
                Globals.Selection = true;
                thereIsAWinner = false;
                notRepeatstart = false;
                timer = 0;
            }
            // main menu button
            if (mouseState.LeftButton == ButtonState.Pressed && mainMenuVictoryRect.Contains(mouseState.Position))
            {
                buttonGpText1 = buttonDefault;
                buttonGpText2 = buttonDefault;
                buttonGpText3 = buttonDefault;
                buttonGpText4 = buttonDefault;
                buttonGpText5 = buttonDefault;
                buttonGpText6 = buttonDefault;
                buttonGpText7 = buttonDefault;
                buttonGpText8 = buttonDefault;
                buttonGpText9 = buttonDefault;
                board[0] = 0;
                board[1] = 0;
                board[2] = 0;
                board[3] = 0;
                board[4] = 0;
                board[5] = 0;
                board[6] = 0;
                board[7] = 0;
                board[8] = 0;
                onePointW = false;
                onePointD = false;
                winner = false;
                tied = false;
                Globals.VictoryOrDraw = false;
                textureCount = 0;
                winsPX = 0;
                winsPO = 0;
                drawP = 0;
                Globals.MainMenu = true;
                thereIsAWinner = false;
                notRepeatstart = false;
                timer = 0;
            }
        }
        void DarkButtonL()
        {
            if (mouseState.LeftButton == ButtonState.Pressed && buttonGpRect1.Contains(mouseState.Position)
                || mouseState.LeftButton == ButtonState.Pressed && buttonGpRect2.Contains(mouseState.Position)
                || mouseState.LeftButton == ButtonState.Pressed && buttonGpRect3.Contains(mouseState.Position)
                || mouseState.LeftButton == ButtonState.Pressed && buttonGpRect4.Contains(mouseState.Position)
                || mouseState.LeftButton == ButtonState.Pressed && buttonGpRect5.Contains(mouseState.Position)
                || mouseState.LeftButton == ButtonState.Pressed && buttonGpRect6.Contains(mouseState.Position)
                || mouseState.LeftButton == ButtonState.Pressed && buttonGpRect7.Contains(mouseState.Position)
                || mouseState.LeftButton == ButtonState.Pressed && buttonGpRect8.Contains(mouseState.Position)
                || mouseState.LeftButton == ButtonState.Pressed && buttonGpRect9.Contains(mouseState.Position))
            {
                buttonGameplayPress = true;
            }
            else
            {
                buttonGameplayPress = false;
            }
        }
        void ChooseL()
        {
            if (previousMouseState.LeftButton == ButtonState.Pressed && mouseState.LeftButton == ButtonState.Released
                && goRect.Contains(mouseState.Position))
            {
                if (playerStart > 0)
                {
                    switchChoose = false;
                }
                else
                {
                    sError.CreateInstance().Play();
                    sError.CreateInstance().Stop();
                }
            }
            if (previousMouseState.LeftButton == ButtonState.Pressed && mouseState.LeftButton == ButtonState.Released
                && randomRect.Contains(mouseState.Position))
            {
                playerStart = randomPlayer.Next(1, 3);
            }

            if (previousMouseState.LeftButton == ButtonState.Pressed && mouseState.LeftButton == ButtonState.Released
                && chooseRect.Contains(mouseState.Position) && chooseClick == false)
            {

                chooseClick = true;

            }

            if (previousMouseState.LeftButton == ButtonState.Pressed && mouseState.LeftButton == ButtonState.Released
                && p1Rect.Contains(mouseState.Position) && chooseClick == true)
            {
                players = false;
                playerStart = 1;
                chooseClick = false;
            }

            if (previousMouseState.LeftButton == ButtonState.Pressed && mouseState.LeftButton == ButtonState.Released
                && p2CpuRect.Contains(mouseState.Position) && chooseClick == true)
            {

                players = true;
                playerStart = 2;
                chooseClick = false;
            }
        }
        void SoundsPlay()
        {
            //victory sound
            if (winner == true & Globals.VictoryOrDraw == false)
            {
                sVictory.CreateInstance().Play();
                sVictory.CreateInstance().Stop();
                Globals.VictoryOrDraw = true;
            }
            //draw sound
            if (winner == false && textureCount == 9 && Globals.VictoryOrDraw == false)
            {
                sDraw.CreateInstance().Play();
                sDraw.CreateInstance().Stop();
                Globals.VictoryOrDraw = true;
            }
            //click sounds
            if (previousMouseState.LeftButton == ButtonState.Pressed && mouseState.LeftButton == ButtonState.Released &&
                clickonrectangle == true && winner == false)
            {
                if (players == false)
                {
                    sCrosses.CreateInstance().Play();
                    sCrosses.CreateInstance().Stop();
                }
                if (players == true)
                {
                    sNoughts.CreateInstance().Play();
                    sNoughts.CreateInstance().Stop();
                }

            }
        }
        public void Update()
        {
            //gameplay Logic:
            clickonrectangle = false;
            previousMouseState = mouseState;
            mouseState = Mouse.GetState();
            if (switchChoose)
            {
                ChooseL();
            }
            else
            {
                if (buttonOandMM == true || thereIsAWinner == true)
                {
                    if (buttonOandMM == true)
                    {
                        OandMML();
                    }
                    if (thereIsAWinner == true)
                    {
                        VictoryL();
                    }
                }
                else
                {
                    if (players == false)
                    {
                        Player1GPLogic();
                    }
                    else
                    {
                        if (Globals.EnemyIsRobot == false)
                        {
                            Player2GPLogic();
                        }
                        else
                        {
                            CpuGPLogic();
                        }
                    }
                }
            }
            WinAndDrawL();
            ButtonInterfaceL();
            SoundsPlay();
            DarkButtonL();
        }
        void DrawBackground()
        {
            Globals.SpriteBatch.Draw(_backgroundTexture, new Vector2(110, 110), Color.White);
        }
        void DrawButtonGameplay()
        {
            Globals.SpriteBatch.Draw(buttonGpText1, buttonGpRect1, Color.White);
            Globals.SpriteBatch.Draw(buttonGpText2, buttonGpRect2, Color.White);
            Globals.SpriteBatch.Draw(buttonGpText3, buttonGpRect3, Color.White);
            Globals.SpriteBatch.Draw(buttonGpText4, buttonGpRect4, Color.White);
            Globals.SpriteBatch.Draw(buttonGpText5, buttonGpRect5, Color.White);
            Globals.SpriteBatch.Draw(buttonGpText6, buttonGpRect6, Color.White);
            Globals.SpriteBatch.Draw(buttonGpText7, buttonGpRect7, Color.White);
            Globals.SpriteBatch.Draw(buttonGpText8, buttonGpRect8, Color.White);
            Globals.SpriteBatch.Draw(buttonGpText9, buttonGpRect9, Color.White);
        }
        void DrawDarkbutton()
        {
            if (buttonGameplayPress && buttonGpRect1.Contains(mouseState.Position)
               && buttonGpText1 != xImage && buttonGpText1 != oImage)
            {
                Globals.SpriteBatch.Draw(buttonDarkGray, buttonGpRect1, Color.White);
            }
            if (buttonGameplayPress && buttonGpRect2.Contains(mouseState.Position)
                && buttonGpText2 != xImage && buttonGpText2 != oImage)
            {
                Globals.SpriteBatch.Draw(buttonDarkGray, buttonGpRect2, Color.White);
            }
            if (buttonGameplayPress && buttonGpRect3.Contains(mouseState.Position)
                && buttonGpText3 != xImage && buttonGpText3 != oImage)
            {
                Globals.SpriteBatch.Draw(buttonDarkGray, buttonGpRect3, Color.White);
            }
            if (buttonGameplayPress && buttonGpRect4.Contains(mouseState.Position)
                && buttonGpText4 != xImage && buttonGpText4 != oImage)
            {
                Globals.SpriteBatch.Draw(buttonDarkGray, buttonGpRect4, Color.White);
            }
            if (buttonGameplayPress && buttonGpRect5.Contains(mouseState.Position)
                && buttonGpText5 != xImage && buttonGpText5 != oImage)
            {
                Globals.SpriteBatch.Draw(buttonDarkGray, buttonGpRect5, Color.White);
            }
            if (buttonGameplayPress && buttonGpRect6.Contains(mouseState.Position)
                && buttonGpText6 != xImage && buttonGpText6 != oImage)
            {
                Globals.SpriteBatch.Draw(buttonDarkGray, buttonGpRect6, Color.White);
            }
            if (buttonGameplayPress && buttonGpRect7.Contains(mouseState.Position)
                && buttonGpText7 != xImage && buttonGpText7 != oImage)
            {
                Globals.SpriteBatch.Draw(buttonDarkGray, buttonGpRect7, Color.White);
            }
            if (buttonGameplayPress && buttonGpRect8.Contains(mouseState.Position)
                && buttonGpText8 != xImage && buttonGpText8 != oImage)
            {
                Globals.SpriteBatch.Draw(buttonDarkGray, buttonGpRect8, Color.White);
            }
            if (buttonGameplayPress && buttonGpRect9.Contains(mouseState.Position)
                && buttonGpText9 != xImage && buttonGpText9 != oImage)
            {
                Globals.SpriteBatch.Draw(buttonDarkGray, buttonGpRect9, Color.White);
            }
        }
        void DrawButtonInterface()
        {
            Globals.SpriteBatch.Draw(nextRoundText, nextRoundRect, shadeInterface1);
        }
        void DrawInterface()
        {
            // Score inferface 
            Globals.SpriteBatch.Draw(scoreText, new Vector2(912, 227), Color.White);

            Globals.SpriteBatch.DrawString(bigFont, "" + winsPX, new Vector2(995, 263), Color.White);

            Globals.SpriteBatch.DrawString(bigFont, "" + winsPO, new Vector2(995, 329), Color.White);

            Globals.SpriteBatch.DrawString(bigFont, "" + drawP, new Vector2(995, 403), Color.White);

            //Winning message
            if (winner == true && players == true)
            {
                Globals.SpriteBatch.DrawString(mediumFont, "CROSSES WIN ROUND", new Vector2(836, 500), Color.White);
            }
            if (winner == true && players == false)
            {
                Globals.SpriteBatch.DrawString(mediumFont, "NOUGHTS WIN ROUND", new Vector2(836, 500), Color.White);
            }
            //Drawning message
            if (winner == false && textureCount == 9)
            {
                Globals.SpriteBatch.DrawString(mediumFont, "DRAW", new Vector2(930, 500), Color.White);
            }
            // Draw Player turn
            Globals.SpriteBatch.Draw(framePlayerText, new Vector2(722, 22), Color.White);

            if (players == false)
            {
                Globals.SpriteBatch.Draw(turnP1Text, new Vector2(725, 152), Color.White);
                switch (Globals.CharacSelectP1)
                {
                    case 1:
                        Globals.SpriteBatch.Draw(p1Profile1_1, new Vector2(725, 22), Color.White);
                        break;
                    case 2:
                        Globals.SpriteBatch.Draw(p1Profile1_2, new Vector2(725, 22), Color.White);
                        break;
                    default:
                        break;
                }

                switch (Globals.CrossOrNougtP1)
                {
                    case 1:
                        Globals.SpriteBatch.Draw(xMiniImage, new Vector2(873, 128), Color.White);
                        break;
                    case 2:
                        Globals.SpriteBatch.Draw(oMiniImage, new Vector2(873, 128), Color.White);
                        break;
                    default:
                        break;
                }
            }
            else
            {
                if (Globals.EnemyIsRobot == false)
                {
                    Globals.SpriteBatch.Draw(turnP2Text, new Vector2(725, 152), Color.White);
                }
                else
                {
                    Globals.SpriteBatch.Draw(cpuText, new Vector2(725, 152), Color.White);
                }
                switch (Globals.CharacSelectP2)
                {
                    case 1:
                        Globals.SpriteBatch.Draw(p1Profile2_1, new Vector2(725, 22), Color.White);
                        break;
                    case 2:
                        Globals.SpriteBatch.Draw(p1Profile2_2, new Vector2(725, 22), Color.White);
                        break;
                    default:
                        break;
                }

                switch (Globals.CrossOrNougtP2)
                {
                    case 1:
                        Globals.SpriteBatch.Draw(oMiniImage, new Vector2(873, 128), Color.White);
                        break;
                    case 2:
                        Globals.SpriteBatch.Draw(xMiniImage, new Vector2(873, 128), Color.White);
                        break;
                    default:
                        break;
                }
            }
            // Draw Rounds
            Globals.SpriteBatch.Draw(roundsText, new Vector2(1011, 154), Color.White);
            Globals.SpriteBatch.DrawString(mediumFont, victorys + " / " + Globals.RoundsPoints, new Vector2(1140, 150), Color.White);

            // Draw Options button
            Globals.SpriteBatch.Draw(OandMMText, OandMMRect, Color.White);
        }
        void DrawOandMM()
        {

            // Draw Options And Main Menu
            Globals.SpriteBatch.Draw(OandMMPanelText, new Vector2(398, 283), Color.White);
            Globals.SpriteBatch.Draw(mainMenuText, mainMenuRect, Color.White);
            Globals.SpriteBatch.Draw(optionsText, optionsRect, Color.White);
            Globals.SpriteBatch.Draw(exitOptionsText, exitOptionsRect, Color.White);

        }
        void DrawVictory()
        {
            Globals.SpriteBatch.Draw(panelVictoryText, new Vector2(283, 226), Color.White);

            switch (victoryPoints)
            {
                case 1:
                    Globals.SpriteBatch.DrawString(bigFont, "PLAYER1 VICTORY!!!", new Vector2(430, 330), Color.White);
                    break;
                case 2:
                    Globals.SpriteBatch.DrawString(bigFont, "PLAYER2 VICTORY!!!", new Vector2(430, 330), Color.White);
                    break;
                case 3:
                    Globals.SpriteBatch.DrawString(bigFont, "CPU VICTORY!!!", new Vector2(430, 330), Color.White);
                    break;
                default:
                    break;
            }

            Globals.SpriteBatch.Draw(retryText, retryRect, Color.White);
            Globals.SpriteBatch.Draw(selectText, selectRect, Color.White);
            Globals.SpriteBatch.Draw(mainMenuVictoryText, mainMenuVictoryRect, Color.White);

        }
        void DrawChoose()
        {
            Globals.SpriteBatch.Draw(backgroundChooseText, new Vector2(0, 0), Color.White);

            Globals.SpriteBatch.Draw(randomText, randomRect, Color.White);

            if (chooseClick)
            {
                Globals.SpriteBatch.Draw(chooseText, chooseRect, Color.White);
                Globals.SpriteBatch.Draw(p1Text, p1Rect, Color.White);
                Globals.SpriteBatch.Draw(p2CpuText, p2CpuRect, Color.White);
            }
            else
            {
                Globals.SpriteBatch.Draw(chooseText, chooseRect, Color.White);
            }
            Globals.SpriteBatch.Draw(goText, goRect, Color.White);
            switch (playerStart)
            {
                case 1:
                    Globals.SpriteBatch.DrawString(mediumFont, "PLAYER1", new Vector2(623, 327), Color.White);
                    players = false;
                    break;
                case 2:
                    if (Globals.EnemyIsRobot == false)
                    {
                        Globals.SpriteBatch.DrawString(mediumFont, "PLAYER2", new Vector2(623, 327), Color.White);
                        players = true;
                    }
                    else
                    {
                        Globals.SpriteBatch.DrawString(mediumFont, "CPU", new Vector2(623, 327), Color.White);
                        players = true;
                    }
                    break;
                default:
                    break;
            }
        }
        public void Draw()
        {
            if (switchChoose)
            {
                DrawChoose();
            }
            else
            {
                DrawBackground();
                DrawButtonGameplay();
                DrawDarkbutton();
                DrawInterface();
                DrawButtonInterface();

                if (buttonOandMM)
                {

                    DrawOandMM();

                }
                if (thereIsAWinner)
                {

                    DrawVictory();

                }

            }
        }
    }
}