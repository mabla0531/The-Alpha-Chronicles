using Microsoft.Xna.Framework.Graphics;

namespace TAC
{
    abstract class State
    {
        public abstract void tick();
        public abstract void render(SpriteBatch spriteBatch);
    }
}
