using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TAC
{
    class GameState : State
    {

        private Entity Player1 { get; }
        private Map map1 { get; }

        public GameState()
        {
            map1 = new Map("map1.map");
            Player1 = new Player();
        }

        public override void tick()
        {
            Player1.tick();
        }

        public override void render(SpriteBatch spriteBatch)
        {
            map1.render(spriteBatch);
            Player1.render(spriteBatch);
        }
    }
}
