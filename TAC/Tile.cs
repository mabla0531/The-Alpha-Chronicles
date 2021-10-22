using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TAC
{
    class Tile
    {
        public static Tile dirtTile = new Tile();

        public int X { get; }
        public int Y { get; }
        public int Width { get; }
        public int Height { get; }
        public Rectangle TextureSource { get; }
        public bool Solid { get; }

        public Tile()
        {
            X = 10;
            Y = 10;
            Width = 32;
            Height = 32;
            TextureSource = new Rectangle(0, 0, 32, 32);
            Solid = false;
        }
        public Tile(int x, int y, int width, int height, Rectangle textureSource, bool solid)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
            TextureSource = textureSource;
            Solid = solid;
        }


    }
}
