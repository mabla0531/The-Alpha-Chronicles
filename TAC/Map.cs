using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;

namespace TAC
{
    class Map
    {

        private List<Tile> tiles = new List<Tile>();
        private readonly int WIDTH, HEIGHT;

        public Map(string file)
        {
            string fileContent = File.ReadAllText(file);
            string[] tokens = fileContent.Split(new char[] { ' ', '\t', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            WIDTH  = int.Parse(tokens[0]);
            HEIGHT = int.Parse(tokens[1]);

            Rectangle textureRect1 = new Rectangle(0, 0, 32, 32);   //TEMPORARY TEXTURE RECTANGLES, SYSTEM SHOULD BE UPDATED TO PUSH NEW STATIC TILE PROTOTYPES INSTEAD
            Rectangle textureRect2 = new Rectangle(0, 32, 32, 32);

            int tokenNum = 2;

            for (int y = 0; y < HEIGHT; y++)
            {
                for (int x = 0; x < WIDTH; x++)
                {
                    tiles.Add(new Tile(x * 32, y * 32, 32, 32, (int.Parse(tokens[tokenNum]) == 1 ? textureRect1 : textureRect2), false));
                    tokenNum++;
                }
            }
                
        }

        public void tick()
        {
            
        }

        public void render(SpriteBatch spriteBatch)
        {
            foreach (Tile t in tiles) {
                spriteBatch.Draw(Assets.tileMap, new Rectangle(t.X, t.Y, t.Width, t.Height), t.TextureSource, Color.White);
            }
        }
    }
}
