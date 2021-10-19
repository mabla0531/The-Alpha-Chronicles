using Microsoft.Xna.Framework.Graphics;

namespace The_Alpha_Chronicles.States
{
    public class GameState : State
    {
        
        private Player player;
        private Map map;

        public GameState()
        {
            map = new Map();
            player = new Player();
        }

        public override void tick()
        {
            map.tick();
            player.tick();
        }

        public override void render(SpriteBatch spriteBatch)
        {
            map.render(spriteBatch);
            player.render(spriteBatch);
        }
    }
}