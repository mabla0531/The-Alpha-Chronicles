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
        public int WIDTH { get; }
        public int HEIGHT { get; }

        public Map(string file)
        {
            string fileContent = File.ReadAllText(file);
            string[] tokens = fileContent.Split(new char[] { ' ', '\t', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            WIDTH = int.Parse(tokens[0]);
            HEIGHT = int.Parse(tokens[1]);

            int tokenNum = 2;

            for (int y = 0; y < HEIGHT; y++)
            {
                for (int x = 0; x < WIDTH; x++)
                {
                    if (tokens[tokenNum] == "0")
                    {
                        tiles.Add(Tile.TileFromPrototype(Tile.grassTile, x * 32, y * 32));
                    }
                    else if (tokens[tokenNum] == "1")
                    {
                        tiles.Add(Tile.TileFromPrototype(Tile.wallTile, x * 32, y * 32));
                    }
                    tokenNum++;
                }
            }
        }

        public void tick()
        {

        }

        public void render(SpriteBatch spriteBatch)
        {
            foreach (Tile t in tiles)
            {
                spriteBatch.Draw(Assets.tileMap, new Rectangle((int)(t.X - GameState.gameCameraOffset.X), (int)(t.Y - GameState.gameCameraOffset.Y), t.Width, t.Height), t.TextureSource, Color.White);
            }
        }

        public Tile getTile(int x, int y)
        {
            foreach (Tile t in tiles)
            {
                if (new Rectangle(t.X, t.Y, t.Width, t.Height).Contains(new Point(x, y)))
                {
                    return t;
                }
            }
            return new Tile();
        }
    }
}
