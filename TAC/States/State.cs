using Microsoft.Xna.Framework.Graphics;

namespace The_Alpha_Chronicles.States
{
    public abstract class State
    {
        public State()
        {
            
        }

        public abstract void tick();
        public abstract void render(SpriteBatch spriteBatch);
        
    }
}