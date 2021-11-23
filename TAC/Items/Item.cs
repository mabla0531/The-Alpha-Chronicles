using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TAC
{
    class Item
    {
        public int HealthMod { get; set; }
        public int DefenseMod { get; set; }
        public int AttackMod { get; set; }
        public double Weight { get; set; }
        public string Slot { get; set; }

        public string Name { get; set; }
        public Rectangle TextureRect { get; set; }

        public virtual void tick()
        {

        }
        public virtual void render(SpriteBatch spriteBatch, int x, int y)
        {
            spriteBatch.Draw(Assets.items, new Rectangle(x, y, 32, 32), TextureRect, Color.White);
        }
    }
}
