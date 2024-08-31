using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TicTacToe
{
    public static class Globals
    {

        public static ContentManager Content { get; set; }
        public static SpriteBatch SpriteBatch { get; set; }

        // Variable

        public static int RoundsPoints { get; set; }
        public static int CharacSelectP1 { get; set; }

        public static int CharacSelectP2 { get; set; }

        public static int CrossOrNougtP1 { get; set; }

        public static int CrossOrNougtP2 { get; set; }

        //aux scene global
        public static bool MainMenu { get; set; }
        public static bool Game { get; set; }
        public static bool Options { get; set; }
        public static bool Selection { get; set; }
        public static bool PressSelection { get; set; }
        public static bool PressOptions { get; set; }
        public static bool PressExit { get; set; }
        public static bool EnemyIsRobot { get; set; }
        
        public static int MainMenuOrGame { get; set; }
        public static bool VictoryOrDraw { get; set; }
        public static bool PressReady { get; set; }
        //aux global
        public static bool Exit { get; set; }
        public static bool FullScreen { get; set; }

        public static bool Windowed { get; set; }
    }
}
