using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace TAC
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private Stack<State> states = new Stack<State>();
        State gameState;

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
            Assets.drawRect = new Texture2D(_graphics.GraphicsDevice, 1, 1);
            Assets.drawRect.SetData(new[] { Color.White });

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(_graphics.GraphicsDevice);

            Assets.characters = Content.Load<Texture2D>("Character");
            Assets.tileMap = Content.Load<Texture2D>("Map");
            Assets.items = Content.Load<Texture2D>("Items");
            Assets.minecraftFont12 = Content.Load<SpriteFont>("Minecraft12");
            Assets.minecraftFont6 = Content.Load<SpriteFont>("Minecraft6");
            Assets.chests = Content.Load<Texture2D>("Chests");
        }

        protected override void Update(GameTime gameTime)
        {
            gameState.tick();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin(samplerState: SamplerState.PointClamp);

            gameState.render(_spriteBatch);

            _spriteBatch.End();
        }
    }
}
