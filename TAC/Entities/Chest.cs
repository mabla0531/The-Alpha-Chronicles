using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace TAC
{
    class Chest : Entity
    {
        public List<Item> items = new List<Item>();
        private Tooltip tooltip;
        public Chest() : base()
        {
            MaxHealth = 0;
            Health = 0;
            textureSubRect = new Rectangle(16, 0, 16, 16);
            CollisionBounds = new Rectangle(0, 0, 16, 16);

            items.Add(new Sword());

            tooltip = new Tooltip("Chest", items.Count + " items", "henlo");
        }
        public Chest(int x, int y) : base()
        {
            MaxHealth = 0;
            Health = 0;
            textureSubRect = new Rectangle(16, 0, 16, 16);
            CollisionBounds = new Rectangle(0, 0, 16, 16);

            X = x;
            Y = y;

            items.Add(new Sword());

            tooltip = new Tooltip("Chest", items.Count + " items", "henlo");
        }

        public override void tick()
        {
            
        }

        public override void render(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Assets.chests, new Rectangle((int)X - GameState.gameCameraOffsetX, (int)Y - GameState.gameCameraOffsetY, 16, 16), textureSubRect, Color.White);

            if (new Rectangle((int)X - GameState.gameCameraOffsetX, (int)Y - GameState.gameCameraOffsetY, textureSubRect.Width, textureSubRect.Height).Contains(Mouse.GetState().Position))
            {
                tooltip.render(spriteBatch, Mouse.GetState().X + 16, Mouse.GetState().Y + 16);
            }
        }
    }
}
