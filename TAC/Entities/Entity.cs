using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TAC
{
    abstract class Entity
    {
        protected float X { get; set; }
        protected float Y { get; set; }
        protected int Health { get; set; }
        protected int MaxHealth { get; set; }

        protected Rectangle textureSubRect;

        public Entity()
        {
            X = 0.0f;
            Y = 0.0f;
            MaxHealth = 10;
            Health = MaxHealth;
            textureSubRect = new Rectangle(0, 0, 32, 32);
        }
        
        public Entity(int x, int y, int maxHealth, Rectangle textureSubRect)
        {
            X = x;
            Y = y;
            MaxHealth = maxHealth;
            Health = MaxHealth;
            this.textureSubRect = textureSubRect;
        }

        protected void move(float x, float y)
        {
            X += x;
            Y += y;
        }

        public abstract void tick();

        public void render(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Assets.characters, new Rectangle((int)X, (int)Y, 32, 32), textureSubRect, Color.White);
        }
    }
}
