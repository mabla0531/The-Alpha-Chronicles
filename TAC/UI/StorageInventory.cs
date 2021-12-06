using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TAC
{
    class StorageInventory
    {
        private Chest container;
        private int itemNum;

        private int previousMouseWheelValue;

        public StorageInventory(Chest c)
        {
            container = c;
            previousMouseWheelValue = Mouse.GetState().ScrollWheelValue;
        }

        public void tick()
        {
            if (Mouse.GetState().ScrollWheelValue > previousMouseWheelValue)
            {
                itemNum--;
            }
            if (Mouse.GetState().ScrollWheelValue < previousMouseWheelValue)
            {
                itemNum++;
            }
            previousMouseWheelValue = Mouse.GetState().ScrollWheelValue;

            if (itemNum < 0)
                itemNum = 0;
            if (itemNum > container.items.Count - 1)
                itemNum = container.items.Count - 1;
            if (container.items.Count >= 5 && itemNum > container.items.Count - 5)
                itemNum = container.items.Count - 5;

            if (new Rectangle((int)(container.X + 256), (int)container.Y + 16, 16, 16).Contains(Mouse.GetState().Position) && Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                container.ShowingInventory = false;
            }
        }

        public void render(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Assets.drawRect, new Rectangle((int)(container.X + 16), (int)(container.Y + 16), 256, 128), Color.DarkSlateGray);
            spriteBatch.Draw(Assets.drawRect, new Rectangle((int)(container.X + 16), (int)(container.Y + 16), 256, 16), Color.LightGray);

            spriteBatch.Draw(Assets.items, new Rectangle((int)(container.X + 256), (int)container.Y + 16, 16, 16), new Rectangle(0, 288, 16, 16), Color.White);

            if (container.items.Count > 0)
                spriteBatch.DrawString(Assets.minecraftFont12, container.items[itemNum].Name, new Vector2((int)(container.X + 16), (int)(container.Y + 32)), Color.LightGray);
            else
                spriteBatch.DrawString(Assets.minecraftFont12, "---EMPTY---", new Vector2((int)(container.X + 16), (int)(container.Y + 32)), Color.LightGray);

            if (itemNum < container.items.Count - 1)
                spriteBatch.DrawString(Assets.minecraftFont12, container.items[itemNum + 1].Name, new Vector2((int)(container.X + 16), (int)(container.Y + 48)), Color.LightGray);
            if (itemNum < container.items.Count - 2)
                spriteBatch.DrawString(Assets.minecraftFont12, container.items[itemNum + 2].Name, new Vector2((int)(container.X + 16), (int)(container.Y + 64)), Color.LightGray);
            if (itemNum < container.items.Count - 3)
                spriteBatch.DrawString(Assets.minecraftFont12, container.items[itemNum + 3].Name, new Vector2((int)(container.X + 16), (int)(container.Y + 80)), Color.LightGray);
            if (itemNum < container.items.Count - 4)
                spriteBatch.DrawString(Assets.minecraftFont12, container.items[itemNum + 4].Name, new Vector2((int)(container.X + 16), (int)(container.Y + 96)), Color.LightGray);
        }
    }
}
