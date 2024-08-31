using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using TicTacToe.Managers;

namespace TicTacToe.Scenes.Selection
{
    public class Selection
    {
        readonly SelectionMgr SelectionMger;
        TicTacToe TheSelectM => SelectionMger.TheSM;
        private Texture2D readyTex, roundsTex, oneTex, threeTex, fiveTex, versusTex,
            arrowL1Tex, arrowR1Tex;

        private Texture2D characterTex1_1, characterTex1_2, characterTex2_1, characterTex2_2,
            arrowL2Tex, arrowR2Tex, arrowL3Tex, arrowR3Tex;

        private Texture2D player1Tex, player2Tex, cpuTex,
             arrowL4Tex, arrowR4Tex;

        private Texture2D crossesTex, nougthsTex,
            arrowL5Tex, arrowR5Tex, arrowL6Tex, arrowR6Tex;

        private Rectangle readyRect, roundsRect,
            arrowL1Rect, arrowR1Rect, numbersRRect, versusRect;

        private Rectangle characterRectP1, characterRectP2,
            arrowL2Rect, arrowR2Rect, arrowL3Rect, arrowR3Rect;

        private Rectangle players1Rect, players2Rect,
            arrowL4Rect, arrowR4Rect;

        private Rectangle signSelectP1Rect, singSelectP2Rect,
            arrowL5Rect, arrowR5Rect, arrowL6Rect, arrowR6Rect;

        private Color shadebuttonM1 = Color.White;

        // Sounds

        SoundEffect sError;

        // Aux
        private int roundsPointLocal = 1;
        private int characSelectP1 = 1;
        private int characSelectP2 = 1;
        private int selectPlayers2 = 2;
        private bool crossOrNougth1 = false;
        private bool crossOrNougth2 = false;

        // 
        public MouseState mouseState;
        public MouseState previousMouseState;
        public Selection(SelectionMgr newGameManager)
        {
            this.SelectionMger = newGameManager;
        }
        public void LoadContent()
        {
            //Sounds
            sError = TheSelectM.Content.Load<SoundEffect>("Sounds/Error");

            // Ready
            readyTex = TheSelectM.Content.Load<Texture2D>("SelectionSprites/ready");
            readyRect = new Rectangle(475, 600, readyTex.Width, readyTex.Height);

            // Rounds
            roundsTex = TheSelectM.Content.Load<Texture2D>("SelectionSprites/rounds");
            roundsRect = new Rectangle(500, 60, roundsTex.Width, roundsTex.Height);

            // Rounds Arrows
            arrowL1Tex = TheSelectM.Content.Load<Texture2D>("SelectionSprites/arrowLeft");
            arrowL1Rect = new Rectangle(610, 55, arrowL1Tex.Width, arrowL1Tex.Height);
            arrowR1Tex = TheSelectM.Content.Load<Texture2D>("SelectionSprites/arrowRight");
            arrowR1Rect = new Rectangle(690, 55, arrowR1Tex.Width, arrowR1Tex.Height);

            // Rounds numbers
            oneTex = TheSelectM.Content.Load<Texture2D>("SelectionSprites/one");
            numbersRRect = new Rectangle(650, 55, oneTex.Width, oneTex.Height);
            threeTex = TheSelectM.Content.Load<Texture2D>("SelectionSprites/three");
            fiveTex = TheSelectM.Content.Load<Texture2D>("SelectionSprites/five");

            // Characters
            characterTex1_1 = TheSelectM.Content.Load<Texture2D>("SelectionSprites/Characters/Player1/cavernicola1.1");
            characterRectP1 = new Rectangle(165, 270, characterTex1_1.Width, characterTex1_1.Height);
            characterTex1_2 = TheSelectM.Content.Load<Texture2D>("SelectionSprites/Characters/Player1/cavernicola1.2");

            characterTex2_1 = TheSelectM.Content.Load<Texture2D>("SelectionSprites/Characters/Player2/cavernicola2.2");
            characterRectP2 = new Rectangle(805, 270, characterTex2_1.Width, characterTex2_1.Height);
            characterTex2_2 = TheSelectM.Content.Load<Texture2D>("SelectionSprites/Characters/Player2/cavernicola2.1");

            // Characters Arrows
            arrowL2Tex = TheSelectM.Content.Load<Texture2D>("SelectionSprites/arrowLeft");
            arrowL2Rect = new Rectangle(110, 410, arrowL2Tex.Width, arrowL2Tex.Height);
            arrowR2Tex = TheSelectM.Content.Load<Texture2D>("SelectionSprites/arrowRight");
            arrowR2Rect = new Rectangle(480, 410, arrowR2Tex.Width, arrowR2Tex.Height);

            arrowL3Tex = TheSelectM.Content.Load<Texture2D>("SelectionSprites/arrowLeft");
            arrowL3Rect = new Rectangle(754, 410, arrowL3Tex.Width, arrowL3Tex.Height);
            arrowR3Tex = TheSelectM.Content.Load<Texture2D>("SelectionSprites/arrowRight");
            arrowR3Rect = new Rectangle(1124, 410, arrowR3Tex.Width, arrowR3Tex.Height);

            // Versus
            versusTex = TheSelectM.Content.Load<Texture2D>("SelectionSprites/vs");
            versusRect = new Rectangle(595, 402, versusTex.Width, versusTex.Height);

            // Players
            player1Tex = TheSelectM.Content.Load<Texture2D>("SelectionSprites/player1");
            players1Rect = new Rectangle(252, 236, player1Tex.Width, player1Tex.Height);
            player2Tex = TheSelectM.Content.Load<Texture2D>("SelectionSprites/player2");
            players2Rect = new Rectangle(896, 236, player2Tex.Width, player2Tex.Height);
            cpuTex = TheSelectM.Content.Load<Texture2D>("SelectionSprites/cpu");

            // Player2 Arrows

            arrowL4Tex = TheSelectM.Content.Load<Texture2D>("SelectionSprites/arrowLeft");
            arrowL4Rect = new Rectangle(850, 233, arrowL4Tex.Width, arrowL4Tex.Height);
            arrowR4Tex = TheSelectM.Content.Load<Texture2D>("SelectionSprites/arrowRight");
            arrowR4Rect = new Rectangle(1027, 233, arrowR4Tex.Width, arrowR4Tex.Height);

            // Select
            crossesTex = TheSelectM.Content.Load<Texture2D>("SelectionSprites/crosses");
            signSelectP1Rect = new Rectangle(252, 628, crossesTex.Width, crossesTex.Height);
            nougthsTex = TheSelectM.Content.Load<Texture2D>("SelectionSprites/nougths");
            singSelectP2Rect = new Rectangle(896, 628, nougthsTex.Width, nougthsTex.Height);

            // Select Arrows
            arrowL5Tex = TheSelectM.Content.Load<Texture2D>("SelectionSprites/arrowLeft");
            arrowL5Rect = new Rectangle(206, 624, arrowL5Tex.Width, arrowL5Tex.Height);
            arrowR5Tex = TheSelectM.Content.Load<Texture2D>("SelectionSprites/arrowRight");
            arrowR5Rect = new Rectangle(386, 624, arrowR5Tex.Width, arrowR5Tex.Height);

            arrowL6Tex = TheSelectM.Content.Load<Texture2D>("SelectionSprites/arrowLeft");
            arrowL6Rect = new Rectangle(850, 624, arrowL6Tex.Width, arrowL6Tex.Height);
            arrowR6Tex = TheSelectM.Content.Load<Texture2D>("SelectionSprites/arrowRight");
            arrowR6Rect = new Rectangle(1027, 624, arrowR6Tex.Width, arrowR6Tex.Height);
        }
        void ReadyAndRoundsBL()
        {
            // Ready Logic    

            if (previousMouseState.LeftButton == ButtonState.Pressed && mouseState.LeftButton == ButtonState.Released
                && readyRect.Contains(mouseState.Position))
            {
                Globals.PressReady = true;
            }
            // Rounds Logic

            //Arrows Rounds Logic
            Globals.RoundsPoints = roundsPointLocal;
            if (previousMouseState.LeftButton == ButtonState.Pressed && mouseState.LeftButton == ButtonState.Released
              && arrowL1Rect.Contains(mouseState.Position))
            {
                if (roundsPointLocal > 1)
                {
                    roundsPointLocal = roundsPointLocal - 2;
                }
                else
                {
                    sError.CreateInstance().Play();
                    sError.CreateInstance().Stop();
                }
            }
            if (previousMouseState.LeftButton == ButtonState.Pressed && mouseState.LeftButton == ButtonState.Released
              && arrowR1Rect.Contains(mouseState.Position))
            {
                if (roundsPointLocal < 5)
                {
                    roundsPointLocal = roundsPointLocal + 2;
                }
                else
                {
                    sError.CreateInstance().Play();
                    sError.CreateInstance().Stop();
                }
            }

        }
        void CharacterBL()
        {
            // Character Select Logic

            // PJ1
            if (previousMouseState.LeftButton == ButtonState.Pressed && mouseState.LeftButton == ButtonState.Released
                && arrowL2Rect.Contains(mouseState.Position))
            {
                if (characSelectP1 > 1)
                {
                    characSelectP1--;
                }
                else
                {
                    sError.CreateInstance().Play();
                    sError.CreateInstance().Stop();
                }
            }
            if (previousMouseState.LeftButton == ButtonState.Pressed && mouseState.LeftButton == ButtonState.Released
                && arrowR2Rect.Contains(mouseState.Position))
            {
                if (characSelectP1 < 2)
                {
                    characSelectP1++;
                }
                else
                {
                    sError.CreateInstance().Play();
                    sError.CreateInstance().Stop();
                }
            }
            // PJ2
            if (previousMouseState.LeftButton == ButtonState.Pressed && mouseState.LeftButton == ButtonState.Released
                && arrowL3Rect.Contains(mouseState.Position))
            {
                if (characSelectP2 > 1)
                {
                    characSelectP2--;
                }
                else
                {
                    sError.CreateInstance().Play();
                    sError.CreateInstance().Stop();
                }
            }
            if (previousMouseState.LeftButton == ButtonState.Pressed && mouseState.LeftButton == ButtonState.Released
                && arrowR3Rect.Contains(mouseState.Position))
            {
                if (characSelectP2 < 2)
                {
                    characSelectP2++;
                }
                else
                {
                    sError.CreateInstance().Play();
                    sError.CreateInstance().Stop();
                }
            }
        }

        void SelectPlayerBL()
        {
            // Select Logic

            // Player2
            if (previousMouseState.LeftButton == ButtonState.Pressed && mouseState.LeftButton == ButtonState.Released
              && arrowL4Rect.Contains(mouseState.Position))
            {
                if (selectPlayers2 > 2)
                {
                    selectPlayers2--;
                }
                else
                {
                    sError.CreateInstance().Play();
                    sError.CreateInstance().Stop();
                }
            }
            if (previousMouseState.LeftButton == ButtonState.Pressed && mouseState.LeftButton == ButtonState.Released
              && arrowR4Rect.Contains(mouseState.Position))
            {
                if (selectPlayers2 < 3)
                {

                    selectPlayers2++;
                }
                else
                {
                    sError.CreateInstance().Play();
                    sError.CreateInstance().Stop();
                }
            }
        }

        void CrossNougthBL()
        {
            // Player1 
            if (previousMouseState.LeftButton == ButtonState.Pressed && mouseState.LeftButton == ButtonState.Released
                 && arrowL5Rect.Contains(mouseState.Position))
            {
                if (crossOrNougth1 == true && crossOrNougth2 == true)
                {
                    crossOrNougth1 = false;
                    crossOrNougth2 = false;
                }
                else
                {
                    sError.CreateInstance().Play();
                    sError.CreateInstance().Stop();
                }

            }

            if (previousMouseState.LeftButton == ButtonState.Pressed && mouseState.LeftButton == ButtonState.Released
                && arrowR5Rect.Contains(mouseState.Position))
            {
                if (crossOrNougth1 == false && crossOrNougth2 == false)
                {
                    crossOrNougth1 = true;
                    crossOrNougth2 = true;
                }
                else
                {
                    sError.CreateInstance().Play();
                    sError.CreateInstance().Stop();
                }
            }

            // Player2

            if (previousMouseState.LeftButton == ButtonState.Pressed && mouseState.LeftButton == ButtonState.Released
                && arrowL6Rect.Contains(mouseState.Position))
            {
                if (crossOrNougth1 == true && crossOrNougth2 == true)
                {
                    crossOrNougth1 = false;
                    crossOrNougth2 = false;
                }
                else
                {
                    sError.CreateInstance().Play();
                    sError.CreateInstance().Stop();
                }
            }
            if (previousMouseState.LeftButton == ButtonState.Pressed && mouseState.LeftButton == ButtonState.Released
               && arrowR6Rect.Contains(mouseState.Position))
            {

                if (crossOrNougth1 == false && crossOrNougth2 == false)
                {
                    crossOrNougth1 = true;
                    crossOrNougth2 = true;
                }
                else
                {
                    sError.CreateInstance().Play();
                    sError.CreateInstance().Stop();
                }
            }
        }

        public void Update()
        {
            previousMouseState = mouseState;
            mouseState = Mouse.GetState();
            ReadyAndRoundsBL();
            CharacterBL();
            SelectPlayerBL();
            CrossNougthBL();
        }
        public void Draw()
        {

            Globals.SpriteBatch.Draw(readyTex, readyRect, shadebuttonM1);
            Globals.SpriteBatch.Draw(versusTex, versusRect, Color.White);
            Globals.SpriteBatch.Draw(roundsTex, roundsRect, Color.White);

            // Rounds Count
            switch (roundsPointLocal)
            {
                case 1:
                    Globals.SpriteBatch.Draw(oneTex, numbersRRect, Color.White);
                    break;
                case 3:
                    Globals.SpriteBatch.Draw(threeTex, numbersRRect, Color.White);
                    break;
                case 5:
                    Globals.SpriteBatch.Draw(fiveTex, numbersRRect, Color.White);
                    break;
                default:
                    Globals.SpriteBatch.Draw(oneTex, numbersRRect, Color.White);
                    break;
            }
            Globals.SpriteBatch.Draw(arrowL1Tex, arrowL1Rect, Color.White);
            Globals.SpriteBatch.Draw(arrowR1Tex, arrowR1Rect, Color.White);
            // Select Character
            switch (characSelectP1)
            {
                case 1:
                    Globals.SpriteBatch.Draw(characterTex1_1, characterRectP1, Color.White);
                    Globals.CharacSelectP1 = characSelectP1;
                    break;
                case 2:
                    Globals.SpriteBatch.Draw(characterTex1_2, characterRectP1, Color.White);
                    Globals.CharacSelectP1 = characSelectP1;
                    break;
            }
            Globals.SpriteBatch.Draw(arrowL2Tex, arrowL2Rect, Color.White);
            Globals.SpriteBatch.Draw(arrowR2Tex, arrowR2Rect, Color.White);
            switch (characSelectP2)
            {
                case 1:
                    Globals.SpriteBatch.Draw(characterTex2_1, characterRectP2, Color.White);
                    Globals.CharacSelectP2 = characSelectP2;
                    break;
                case 2:
                    Globals.SpriteBatch.Draw(characterTex2_2, characterRectP2, Color.White);
                    Globals.CharacSelectP2 = characSelectP2;
                    break;
            }
            Globals.SpriteBatch.Draw(arrowL3Tex, arrowL3Rect, Color.White);
            Globals.SpriteBatch.Draw(arrowR3Tex, arrowR3Rect, Color.White);
            // Select Player

            Globals.SpriteBatch.Draw(player1Tex, players1Rect, Color.White);
            switch (selectPlayers2)
            {
                case 2:
                    Globals.SpriteBatch.Draw(player2Tex, players2Rect, Color.White);
                    Globals.EnemyIsRobot = false;
                    break;
                case 3:
                    Globals.SpriteBatch.Draw(cpuTex, players2Rect, Color.White);
                    Globals.EnemyIsRobot = true;
                    break;
            }
            Globals.SpriteBatch.Draw(arrowL4Tex, arrowL4Rect, Color.White);
            Globals.SpriteBatch.Draw(arrowR4Tex, arrowR4Rect, Color.White);
            //
            if (crossOrNougth1 == false)
            {
                Globals.SpriteBatch.Draw(crossesTex, signSelectP1Rect, Color.White);
                Globals.CrossOrNougtP1 = 1;
            }
            else
            {
                Globals.SpriteBatch.Draw(nougthsTex, signSelectP1Rect, Color.White);
                Globals.CrossOrNougtP1 = 2;
            }

            Globals.SpriteBatch.Draw(arrowL5Tex, arrowL5Rect, Color.White);
            Globals.SpriteBatch.Draw(arrowR5Tex, arrowR5Rect, Color.White);
            if (crossOrNougth2 == false)
            {
                Globals.SpriteBatch.Draw(nougthsTex, singSelectP2Rect, Color.White);
                Globals.CrossOrNougtP2 = 1;
            }
            else
            {
                Globals.SpriteBatch.Draw(crossesTex, singSelectP2Rect, Color.White);
                Globals.CrossOrNougtP2 = 2;
            }
            Globals.SpriteBatch.Draw(arrowL6Tex, arrowL6Rect, Color.White);
            Globals.SpriteBatch.Draw(arrowR6Tex, arrowR6Rect, Color.White);

        }
    }
}
