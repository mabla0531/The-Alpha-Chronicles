using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Linq;

namespace TAC
{
    class GameState : State
    {
        public static Vector2 gameCameraOffset;
        private readonly int GAMEWINDOWWIDTH, GAMEWINDOWHEIGHT;

        private Player player { get; }
        private Map map { get; }
        private Chest chest1;

        private List<Entity> entities;

        private InfoPanel infoPanel;

        public GameState(int gameWindowWidth, int gameWindowHeight)
        {
            map = new Map("map1.map");
            Handler.map = map;
            player = new Player();
            Handler.player = player;
            chest1 = new Chest(128, 128);


            GAMEWINDOWWIDTH = gameWindowWidth;
            GAMEWINDOWHEIGHT = gameWindowHeight;

            infoPanel = new InfoPanel();

            entities = new List<Entity>();
            entities.Add(player);
            entities.Add(chest1);
            Handler.entities = entities;
        }

        public override void tick()
        {
            //SORT ENTITIES BY Y VALUE
            entities = entities.OrderBy(e => e.Y).ToList();

            //TICK ENTITIES
            foreach (Entity e in entities)
            {
                e.tick();
            }

            //DO GAMECAMERA CALCULATION
            gameCameraOffset.X = (int)(player.X - (GAMEWINDOWWIDTH / 2));
            gameCameraOffset.Y = (int)(player.Y - (GAMEWINDOWHEIGHT / 2));

            if (gameCameraOffset.X < 0) //make sure the game camera isn't rendering blank space
                gameCameraOffset.X = 0;
            if (gameCameraOffset.X + GAMEWINDOWWIDTH > (map.WIDTH * 32))
                gameCameraOffset.X = (map.WIDTH * 32) - GAMEWINDOWWIDTH;

            if (gameCameraOffset.Y < 0) //same as above, but for Y axis
                gameCameraOffset.Y = 0;
            if (gameCameraOffset.Y + (GAMEWINDOWHEIGHT - 128) > (map.HEIGHT * 32))
                gameCameraOffset.Y = (map.HEIGHT * 32) - (GAMEWINDOWHEIGHT - 128);
        }

        public override void render(SpriteBatch spriteBatch)
        {
            map.render(spriteBatch);

            foreach (Entity e in entities)
            {
                e.render(spriteBatch);
            }
            
            foreach (Entity e in entities)
            {
                e.postRender(spriteBatch);
            }

            infoPanel.render(spriteBatch);
        }
    }
}
