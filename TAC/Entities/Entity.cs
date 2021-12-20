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
        public int Health { get; set; }
        public int MaxHealth { get; set; }

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

        protected void moveX(float xMove)
        {
            //check collision with tiles before doing movement

            if ((xMove < 0.0f && (Handler.map.getTile((int)(X + xMove + CollisionBounds.X), (int)(Y + CollisionBounds.Y)).Solid ||
                                  Handler.map.getTile((int)(X + xMove + CollisionBounds.X), (int)(Y + CollisionBounds.Y + CollisionBounds.Height)).Solid)) ||
                (xMove > 0.0f && (Handler.map.getTile((int)(X + xMove + CollisionBounds.X + CollisionBounds.Width), (int)(Y + CollisionBounds.Y)).Solid ||
                                  Handler.map.getTile((int)(X + xMove + CollisionBounds.X + CollisionBounds.Width), (int)(Y + CollisionBounds.Y + CollisionBounds.Height)).Solid)))
            {
                return;
            }

            Rectangle moveRect = new Rectangle((int)(X + CollisionBounds.X + xMove), (int)(Y + CollisionBounds.Y), CollisionBounds.Width, CollisionBounds.Height);
            //check collision with entities before doing movement
            foreach(Entity e in Handler.entities)
            {
                if (e != this && new Rectangle((int)(e.X + e.CollisionBounds.X), (int)(e.Y + e.CollisionBounds.Y), e.CollisionBounds.Width, e.CollisionBounds.Height).Intersects(moveRect)) return;
            }

            X += xMove;
        }

        protected void moveY(float yMove)
        {
            //check collision with tiles before doing movement
            if ((yMove < 0.0f && (Handler.map.getTile((int)(X + CollisionBounds.X), (int)(Y + yMove + CollisionBounds.Y)).Solid ||
                                  Handler.map.getTile((int)(X + CollisionBounds.X + CollisionBounds.Width), (int)(Y + yMove + CollisionBounds.Y)).Solid)) ||
                (yMove > 0.0f && (Handler.map.getTile((int)(X + CollisionBounds.X), (int)(Y + yMove + CollisionBounds.Y + CollisionBounds.Height)).Solid ||
                                  Handler.map.getTile((int)(X + CollisionBounds.X + CollisionBounds.Width), (int)(Y + yMove + CollisionBounds.Y + CollisionBounds.Height)).Solid)))
            {
                return;
            }

            Rectangle moveRect = new Rectangle((int)(X + CollisionBounds.X), (int)(Y + CollisionBounds.Y + yMove), CollisionBounds.Width, CollisionBounds.Height);
            //check collision with entities before doing movement
            foreach (Entity e in Handler.entities)
            {
                if (e != this && new Rectangle((int)(e.X + e.CollisionBounds.X), (int)(e.Y + e.CollisionBounds.Y), e.CollisionBounds.Width, e.CollisionBounds.Height).Intersects(moveRect)) return;
            }

            Y += yMove;
        }

        public abstract void tick();

        public virtual void render(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Assets.characters, new Rectangle((int)(X - GameState.gameCameraOffset.X), (int)(Y - GameState.gameCameraOffset.Y), 32, 32), textureSubRect, Color.White);
        }

        public virtual void postRender(SpriteBatch spriteBatch)
        {

        }

        public Vector2 getLocationAsVector2()
        {
            return new Vector2(X, Y);
        }
    }
}
