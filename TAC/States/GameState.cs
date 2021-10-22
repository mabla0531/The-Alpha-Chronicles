using Microsoft.Xna.Framework.Graphics;
using System.Diagnostics;

namespace TAC
{
    class GameState : State
    {
        private int gameCameraOffsetX, gameCameraOffsetY;
        private readonly int GAMEWINDOWWIDTH, GAMEWINDOWHEIGHT;

        private Entity Player1 { get; }
        private Map map1 { get; }

        public GameState(int gameWindowWidth, int gameWindowHeight)
        {
            map1 = new Map("map1.map");
            Player1 = new Player();

            GAMEWINDOWWIDTH = gameWindowWidth;
            GAMEWINDOWHEIGHT = gameWindowHeight;
        }

        public override void tick()
        {
            Player1.tick();

            //DO GAMECAMERA CALCULATION
            gameCameraOffsetX = (int)(Player1.X - (GAMEWINDOWWIDTH / 2));
            gameCameraOffsetY = (int)(Player1.Y - (GAMEWINDOWHEIGHT / 2));

            if (gameCameraOffsetX < 0) //make sure the game camera isn't rendering blank space
                gameCameraOffsetX = 0;
            if (gameCameraOffsetX + GAMEWINDOWWIDTH > (map1.WIDTH * 32))
                gameCameraOffsetX = (map1.WIDTH * 32) - GAMEWINDOWWIDTH;

            if (gameCameraOffsetY < 0) //same as above, but for Y axis
                gameCameraOffsetY = 0;
            if (gameCameraOffsetY + GAMEWINDOWHEIGHT > (map1.HEIGHT * 32))
                gameCameraOffsetY = (map1.HEIGHT * 32) - GAMEWINDOWHEIGHT;

            Debug.WriteLine(gameCameraOffsetX + " " + gameCameraOffsetY);
        }

        public override void render(SpriteBatch spriteBatch)
        {
            map1.render(spriteBatch, gameCameraOffsetX, gameCameraOffsetY);
            Player1.render(spriteBatch, gameCameraOffsetX, gameCameraOffsetY);
        }
    }
}
