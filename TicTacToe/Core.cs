using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using TicTacToe.Managers;

namespace TicTacToe

{
    public class TicTacToe : Game
    {
        enum Scenes
        {
            MAINMENU,
            GAME,
            SELECTION,
            OPTIONS,
            //CREDITS
            EXIT
        };
        private readonly GraphicsDeviceManager _graphics;
        private readonly int _resolutionWidth;
        private readonly int _resolutionHeight;
        // Managers
        private readonly GameMgr gameManager;
        private readonly MainMenuMgr mainMenuManager;
        private readonly SelectionMgr selectionManager;
        private readonly OptionsMgr optionsManager;
        private readonly OptionExitMgr exitManager;
        
        private Scenes activeScene;
        public TicTacToe()
        {
            _graphics = new GraphicsDeviceManager(this);
            _resolutionWidth = 1280;
            _resolutionHeight = 720; 
            _graphics.PreferredBackBufferWidth = _resolutionWidth;
            _graphics.PreferredBackBufferHeight = _resolutionHeight;
            _graphics.ApplyChanges();
            _graphics.HardwareModeSwitch = true;
            activeScene = Scenes.MAINMENU;
            gameManager = new GameMgr(this);
            mainMenuManager = new MainMenuMgr(this);
            selectionManager = new SelectionMgr(this);
            optionsManager = new OptionsMgr(this);
            exitManager = new OptionExitMgr(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        } 
        
        protected override void LoadContent()
        {
            Globals.Content = Content;
            Globals.SpriteBatch = new SpriteBatch(GraphicsDevice);
            gameManager.LoadContent();
            mainMenuManager.LoadContent();
            selectionManager.LoadContent();
            optionsManager.LoadContent();
            exitManager.LoadContent();
        }
        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape) && Globals.PressExit == false)
            { 

               Globals.PressExit = true;

            }
            //aux exit
            if (Globals.Exit)
            {
                Exit();
                Globals.Exit = false;
            }

            if (Globals.FullScreen)
            {
                _graphics.IsFullScreen = true;
                _graphics.ApplyChanges();
                Globals.FullScreen = false;
            }
            if (Globals.Windowed)
            {
                _graphics.IsFullScreen = false;
                _graphics.ApplyChanges();
                Globals.Windowed = false;
            }
            
            if (Globals.MainMenu)
            {
                activeScene = Scenes.MAINMENU;

                Globals.MainMenu = false;
            }
            if (Globals.Game)
            {
                activeScene = Scenes.GAME;

                Globals.Game = false;
            }

            if (Globals.Options)
            {
                activeScene = Scenes.OPTIONS;

                Globals.Options = false;
            }

            if (Globals.Selection)
            {
                activeScene = Scenes.SELECTION;

                Globals.Selection = false;
            }

            //update to scene manager
            switch (activeScene)
            {

                case Scenes.MAINMENU:

                    //mainmenu scene is
                    mainMenuManager.Update();
                    if (Globals.PressSelection)
                    {
                        activeScene = Scenes.SELECTION;
                        
                        Globals.PressSelection = false;
                    }
                    if (Globals.PressOptions)
                    {
                        activeScene = Scenes.OPTIONS;
                        Globals.PressOptions = false;
                    }
                    if (Globals.PressExit)
                    {
                        activeScene = Scenes.EXIT;
                        Globals.PressExit = false;
                    }
                    break;
                case Scenes.SELECTION:

                    //newgame scene is
                    selectionManager.Update();
                    if (Globals.PressReady)
                    {
                        activeScene = Scenes.GAME;
                        Globals.PressReady = false;
                    }
                    break;
                case Scenes.GAME:

                    //game scene is
                    gameManager.Update();
                    break;
                case Scenes.OPTIONS:

                    //options scene is
                    optionsManager.Update();
                    break;
                case Scenes.EXIT:

                    //exit scene is
                    exitManager.Update();
                    break;
                default:
                    mainMenuManager.Draw();
                    break;
            }
            base.Update(gameTime);
        }
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            Globals.SpriteBatch.Begin(samplerState: SamplerState.PointClamp);
            // Draw to scene manager
            switch (activeScene)
            {

                case Scenes.MAINMENU:

                    //mainmenu scene is
                    mainMenuManager.Draw();
                    break;
                case Scenes.SELECTION:

                    //newgame scene is
                    selectionManager.Draw();
                    break;
                case Scenes.GAME:

                    //game scene is

                    gameManager.Draw();

                    break;
                case Scenes.OPTIONS:

                    //options scene is
                    optionsManager.Draw();
                    break;
                case Scenes.EXIT:

                    //exit scene is
                    exitManager.Draw();
                    break;
                default:
                    mainMenuManager.Draw();
                    break;
            }
            Globals.SpriteBatch.End();
            base.Draw(gameTime);
        }

    }
}
