using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace TAC
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private Stack<State> states = new Stack<State>();
        State gameState;
        Texture2D tiles;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            Handler.game = this;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            gameState = new GameState(_graphics.GraphicsDevice.Viewport.Width, _graphics.GraphicsDevice.Viewport.Height);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(_graphics.GraphicsDevice);

            Assets.characters = Content.Load<Texture2D>("Character");
            Assets.tileMap = Content.Load<Texture2D>("Map");
            tiles = Content.Load<Texture2D>("Map");
        }

        protected override void Update(GameTime gameTime)
        {
            gameState.tick();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();

            gameState.render(_spriteBatch);

            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
