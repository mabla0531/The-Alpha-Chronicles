using Microsoft.Xna.Framework;

namespace TAC
{
    class Tile
    {
        public static Tile grassTile = new Tile(32, 32, new Rectangle(32, 64, 32, 32), false);
        public static Tile wallTile = new Tile(32, 32, new Rectangle(96, 32, 32, 32), true);


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
        public Tile(int width, int height, Rectangle textureSource, bool solid)
        {
            X = 0;
            Y = 0;
            Width = width;
            Height = height;
            TextureSource = textureSource;
            Solid = solid;
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

        public static Tile TileFromPrototype(Tile t, int x, int y)
        {
            return new Tile(x, y, t.Width, t.Height, t.TextureSource, t.Solid);
        }
    }
}
