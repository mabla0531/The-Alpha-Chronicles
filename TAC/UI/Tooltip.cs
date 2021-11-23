using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TAC
{
    class Tooltip
    {

        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string Line3 { get; set; }

        public Tooltip(string line1, string line2, string line3)
        {
            Line1 = line1;
            Line2 = line2;
            Line3 = line3;
        }

        public void render(SpriteBatch spriteBatch, int x, int y)
        {
            spriteBatch.Draw(Assets.drawRect, new Rectangle(x, y, 64, 48), Color.DarkSlateGray);
            spriteBatch.DrawString(Assets.minecraftFont12, Line1, new Vector2(x + 2, y + 2), Color.White);
            spriteBatch.DrawString(Assets.minecraftFont12, Line2, new Vector2(x + 2, y + 16), Color.White);
            spriteBatch.DrawString(Assets.minecraftFont12, Line3, new Vector2(x + 2, y + 32), Color.White);
        }
    }
}
