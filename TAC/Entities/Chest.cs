using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace TAC
{
    class Chest : Entity
    {
        public List<Item> items = new List<Item>();
        private Tooltip tooltip;

        StorageInventory inventory;
        public bool ShowingInventory { get; set; }

        public Chest() : base()
        {
            MaxHealth = 0;
            Health = 0;
            textureSubRect = new Rectangle(16, 0, 16, 16);
            CollisionBounds = new Rectangle(0, 0, 16, 16);

            tooltip = new Tooltip("Chest", items.Count + " items", "");

            inventory = new StorageInventory(this);

            ShowingInventory = false;
        }
        public Chest(int x, int y) : base()
        {
            MaxHealth = 0;
            Health = 0;
            textureSubRect = new Rectangle(16, 0, 16, 16);
            CollisionBounds = new Rectangle(0, 0, 16, 16);

            X = x;
            Y = y;

            items.Add(new Sword("OBJ. 279(E)"));
            items.Add(new Helmet());
            items.Add(new Chestplate());
            items.Add(new Leggings());
            items.Add(new Boots());

            tooltip = new Tooltip("Chest", items.Count + " items", "");

            inventory = new StorageInventory(this);
            ShowingInventory = false;
        }
         
        public override void tick()
        {
            if (new Rectangle((int)(X - GameState.gameCameraOffset.X), (int)(Y - GameState.gameCameraOffset.Y), textureSubRect.Width, textureSubRect.Height).Contains(Mouse.GetState().Position) && Mouse.GetState().RightButton == ButtonState.Pressed && !ShowingInventory)
            {
                ShowingInventory = true;
            }

            if (ShowingInventory)
            {
                inventory.tick();
            }
        }

        public override void render(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Assets.chests, new Rectangle((int)(X - GameState.gameCameraOffset.X), (int)(Y - GameState.gameCameraOffset.Y), 16, 16), textureSubRect, Color.White);
        }

        public override void postRender(SpriteBatch spriteBatch)
        {
            if (new Rectangle((int)(X - GameState.gameCameraOffset.X), (int)(Y - GameState.gameCameraOffset.Y), textureSubRect.Width, textureSubRect.Height).Contains(Mouse.GetState().Position) && !ShowingInventory)
            {
                tooltip.render(spriteBatch, Mouse.GetState().X + 16, Mouse.GetState().Y + 16);
            }

            if (ShowingInventory)
            {
                inventory.render(spriteBatch);
            }
        }
    }
}
