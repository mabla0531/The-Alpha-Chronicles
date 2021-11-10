using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAC
{
    class InfoPanel
    {
        private int x, y;

        private Color hpColor;

        public InfoPanel()
        {

            x = 0;
            y = Handler.game.GraphicsDevice.Viewport.Height - 128;
        }

        public void render(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Assets.drawRect, new Rectangle(x, y, Handler.game.GraphicsDevice.Viewport.Width, 128), Color.DarkSlateGray);
            spriteBatch.Draw(Assets.characters, new Rectangle((int)(x + 4), (int)(y + 4), 64, 64), new Rectangle(0, 128, 64, 64), Color.White);

            //do HP calculation for health text color
            float hpRatio = (float)Handler.player.Health / (float)Handler.player.MaxHealth;
            if (hpRatio < .25f)
                hpColor = Color.Red;
            else if (hpRatio < .5f)
                hpColor = Color.Orange;
            else if (hpRatio < .75f)
                hpColor = Color.Yellow;
            else if (hpRatio < 1.0f)
                hpColor = Color.Lime;
            else
                hpColor = Color.LimeGreen;

            spriteBatch.DrawString(Assets.minecraftFont12, "HP: " + Handler.player.Health + "/" + Handler.player.MaxHealth, new Vector2(x + 4, y + 72), hpColor);
            spriteBatch.DrawString(Assets.minecraftFont12, "AT: " + Handler.player.Attack, new Vector2(x + 4, y + 88), Color.LightGray);
            spriteBatch.DrawString(Assets.minecraftFont12, "DF: " + Handler.player.Defense, new Vector2(x + 4, y + 104), Color.LightGray);

            if (Handler.player.Hand != null)
                Handler.player.Hand.render(spriteBatch, (int)(x + 72), (int)(y + 4));

            
        }
    }
}
