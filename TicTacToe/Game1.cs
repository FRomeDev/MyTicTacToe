using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TicTacToe
{
    public static class GlobalVariable
    {
        public static SpriteBatch spriteBatch;
    }
    public class TicTacToe : Game
    {
        GraphicsDeviceManager graphics;
        GameManager gameManager;
        public TicTacToe()
        {

            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

        }

        protected override void Initialize()
        {
            IsMouseVisible = true;
            GlobalVariable.spriteBatch = new SpriteBatch(GraphicsDevice);
            graphics.PreferredBackBufferWidth = 1000;
            graphics.ApplyChanges();

            base.Initialize();
        }
        protected override void LoadContent()
        {
            gameManager = new GameManager(this);

        }
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Microsoft.Xna.Framework.Input.Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            gameManager.Update();
            base.Update(gameTime);
        }
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            GlobalVariable.spriteBatch.Begin();

            gameManager.Draw();
            GlobalVariable.spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
