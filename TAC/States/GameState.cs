using Microsoft.Xna.Framework.Graphics;
using System.Diagnostics;

namespace TAC
{
    class GameState : State
    {
        private int gameCameraOffsetX, gameCameraOffsetY;
        private readonly int GAMEWINDOWWIDTH, GAMEWINDOWHEIGHT;

        private Entity player { get; }
        private Map map { get; }

        public GameState(int gameWindowWidth, int gameWindowHeight)
        {
            map = new Map("map1.map");
            player = new Player();

            Handler.map = map;
            Handler.player = player;

            GAMEWINDOWWIDTH = gameWindowWidth;
            GAMEWINDOWHEIGHT = gameWindowHeight;
        }

        public override void tick()
        {
            player.tick();

            //DO GAMECAMERA CALCULATION
            gameCameraOffsetX = (int)(player.X - (GAMEWINDOWWIDTH / 2));
            gameCameraOffsetY = (int)(player.Y - (GAMEWINDOWHEIGHT / 2));

            if (gameCameraOffsetX < 0) //make sure the game camera isn't rendering blank space
                gameCameraOffsetX = 0;
            if (gameCameraOffsetX + GAMEWINDOWWIDTH > (map.WIDTH * 32))
                gameCameraOffsetX = (map.WIDTH * 32) - GAMEWINDOWWIDTH;

            if (gameCameraOffsetY < 0) //same as above, but for Y axis
                gameCameraOffsetY = 0;
            if (gameCameraOffsetY + GAMEWINDOWHEIGHT > (map.HEIGHT * 32))
                gameCameraOffsetY = (map.HEIGHT * 32) - GAMEWINDOWHEIGHT;

            Debug.WriteLine(gameCameraOffsetX + " " + gameCameraOffsetY);
        }

        public override void render(SpriteBatch spriteBatch)
        {
            map.render(spriteBatch, gameCameraOffsetX, gameCameraOffsetY);
            player.render(spriteBatch, gameCameraOffsetX, gameCameraOffsetY);
        }
    }
}
