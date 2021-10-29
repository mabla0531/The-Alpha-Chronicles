using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Diagnostics;

namespace TAC
{
    abstract class Entity
    {
        public float X { get; set; }
        public float Y { get; set; }
        public Rectangle CollisionBounds { get; set; }
        protected int Health { get; set; }
        protected int MaxHealth { get; set; }

        protected Rectangle textureSubRect;

        public Entity()
        {
            X = 0.0f;
            Y = 0.0f;
            CollisionBounds = new Rectangle(0, 0, 32, 32);
            MaxHealth = 10;
            Health = MaxHealth;
            textureSubRect = new Rectangle(0, 0, 32, 32);
        }

        public Entity(int x, int y, Rectangle collisionBounds, int maxHealth, Rectangle textureSubRect)
        {
            X = x;
            Y = y;
            CollisionBounds = collisionBounds;
            MaxHealth = maxHealth;
            Health = MaxHealth;
            this.textureSubRect = textureSubRect;
        }

        protected void move(float xMove, float yMove)
        {
            //check collision with tiles before doing movement

            if ((xMove < 0.0f && (!Handler.map.getTile((int)(X + xMove + CollisionBounds.X), (int)(Y + CollisionBounds.Y)).Solid &&
                                  !Handler.map.getTile((int)(X + xMove + CollisionBounds.X), (int)(Y + CollisionBounds.Y + CollisionBounds.Height)).Solid)) ||
                (xMove > 0.0f && (!Handler.map.getTile((int)(X + xMove + CollisionBounds.X + CollisionBounds.Width), (int)(Y + CollisionBounds.Y)).Solid &&
                                  !Handler.map.getTile((int)(X + xMove + CollisionBounds.X + CollisionBounds.Width), (int)(Y + CollisionBounds.Y + CollisionBounds.Height)).Solid)))
            {
                X += xMove;
            }
            if ((yMove < 0.0f && (!Handler.map.getTile((int)(X + CollisionBounds.X), (int)(Y + yMove + CollisionBounds.Y)).Solid &&
                                  !Handler.map.getTile((int)(X + CollisionBounds.X + CollisionBounds.Width), (int)(Y + yMove + CollisionBounds.Y)).Solid)) ||
                (yMove > 0.0f && (!Handler.map.getTile((int)(X + CollisionBounds.X), (int)(Y + yMove + CollisionBounds.Y + CollisionBounds.Height)).Solid &&
                                  !Handler.map.getTile((int)(X + CollisionBounds.X + CollisionBounds.Width), (int)(Y + yMove + CollisionBounds.Y + CollisionBounds.Height)).Solid)))
            {
                Y += yMove;
            }
        }

        public abstract void tick();

        public virtual void render(SpriteBatch spriteBatch, int gameCameraOffsetX, int gameCameraOffsetY)
        {
            spriteBatch.Draw(Assets.characters, new Rectangle((int)X - gameCameraOffsetX, (int)Y - gameCameraOffsetY, 32, 32), textureSubRect, Color.White);
        }
    }
}
