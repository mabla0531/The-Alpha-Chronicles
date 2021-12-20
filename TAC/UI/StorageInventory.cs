using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;

namespace TAC
{
    class StorageInventory
    {
        private Chest container;
        private int currentItem = -1;
        private int itemNum;

        private int previousMouseWheelValue;

        private Rectangle takeButton = new Rectangle(20, 236, 64, 32);

        //array of screen locations that tell where to draw item names, also plays a part in mouse cursor handling
        private Vector2[] itemDisplayPoints = {
                new Vector2(20, 34),
                new Vector2(20, 52),
                new Vector2(20, 70),
                new Vector2(20, 88),
                new Vector2(20, 106)
            };

        public StorageInventory(Chest c)
        {
            container = c;
            previousMouseWheelValue = Mouse.GetState().ScrollWheelValue;

        }

        public void tick()
        {
            Debug.WriteLine(currentItem);
            if (Mouse.GetState().ScrollWheelValue > previousMouseWheelValue)
                itemNum--;
            if (Mouse.GetState().ScrollWheelValue < previousMouseWheelValue)
                itemNum++;
            previousMouseWheelValue = Mouse.GetState().ScrollWheelValue;

            //if the X button is clicked
            if (new Rectangle((new Vector2((int)(container.X + 256), (int)(container.Y + 16)) - GameState.gameCameraOffset).ToPoint(), new Point(16, 16)).Contains(Mouse.GetState().Position) && Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                container.ShowingInventory = false;
            }

            if (currentItem != -1 && new Rectangle((new Vector2(takeButton.X, takeButton.Y) + container.getLocationAsVector2() - GameState.gameCameraOffset).ToPoint(), new Point(takeButton.Width, takeButton.Height)).Contains(Mouse.GetState().Position) && Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                if (Handler.player.addItem(container.items[currentItem]))
                {
                    container.items.Remove(container.items[currentItem]);
                    currentItem = -1;
                }
                else
                {
                    //TELL THE PLAYER THAT HE IS TOO FAT AND WILL DIE 
                }
            }

            //various conditions to ensure proper display and scrolling of item list
            if (itemNum < 0)
                itemNum = 0;
            if (itemNum > container.items.Count - 1)
                itemNum = container.items.Count - 1;
            if (container.items.Count >= 5 && itemNum > container.items.Count - 5)
                itemNum = container.items.Count - 5;
        }

        public void render(SpriteBatch spriteBatch)
        {
            //main UI window
            spriteBatch.Draw(Assets.drawRect, new Rectangle((new Vector2(16,  16) + container.getLocationAsVector2() - GameState.gameCameraOffset).ToPoint(), new Point(256, 256)), Color.DarkSlateGray);
            //title bar
            spriteBatch.Draw(Assets.drawRect, new Rectangle((new Vector2(16,  16) + container.getLocationAsVector2() - GameState.gameCameraOffset).ToPoint(), new Point(256, 16)), Color.LightGray);
            //X button
            spriteBatch.Draw(Assets.items,    new Rectangle((new Vector2(256, 16) + container.getLocationAsVector2() - GameState.gameCameraOffset).ToPoint(), new Point(16,  16)), new Rectangle(0, 288, 16, 16), Color.White);
            //item bar
            spriteBatch.Draw(Assets.drawRect, new Rectangle((new Vector2(18, 126) + container.getLocationAsVector2() - GameState.gameCameraOffset).ToPoint(), new Point(252, 144)), Color.DarkCyan);

            if (container.items.Count > 0)
            {
                //draw all items within the range of the window
                for (int i = 0; i <= 4; i++)
                {
                    if (itemNum < container.items.Count - i)
                    {
                        if (new Rectangle((itemDisplayPoints[i] - new Vector2(4, 2) + container.getLocationAsVector2() - GameState.gameCameraOffset).ToPoint(), new Point(252, 18)).Contains(Mouse.GetState().Position))
                        {
                            //highlight the item moused over
                            spriteBatch.Draw(Assets.drawRect, new Rectangle((itemDisplayPoints[i] - new Vector2(4, 2) + container.getLocationAsVector2() - GameState.gameCameraOffset).ToPoint(), new Point(256, 20)), Color.LightGray);
                            spriteBatch.Draw(Assets.drawRect, new Rectangle((itemDisplayPoints[i] - new Vector2(2, 0) + container.getLocationAsVector2() - GameState.gameCameraOffset).ToPoint(), new Point(252, 16)), Color.DarkSlateGray);
                            //if the item moused over is clicked
                            if (Mouse.GetState().LeftButton == ButtonState.Pressed)
                            {
                                currentItem = itemNum + i;
                            }
                        }
                        //render item
                        spriteBatch.DrawString(Assets.minecraftFont12, container.items[itemNum + i].Name, itemDisplayPoints[i] + container.getLocationAsVector2() - GameState.gameCameraOffset, Color.LightGray);
                    }
                }
                if (currentItem != -1)
                {
                    spriteBatch.Draw(Assets.items, new Rectangle((new Vector2(20, 128) + container.getLocationAsVector2() - GameState.gameCameraOffset).ToPoint(), new Point(32, 32)), container.items[currentItem].TextureRect, Color.White);
                    spriteBatch.DrawString(Assets.minecraftFont12, container.items[currentItem].Name, new Vector2(54, 128) + container.getLocationAsVector2() - GameState.gameCameraOffset, Color.LightGray);
                    spriteBatch.DrawString(Assets.minecraftFont12, "Slot: " + container.items[currentItem].Slot, new Vector2(54, 144) + container.getLocationAsVector2() - GameState.gameCameraOffset, Color.LightGray);
                    spriteBatch.DrawString(Assets.minecraftFont12, "Health Bonus: " + container.items[currentItem].HealthMod, new Vector2(20, 160) + container.getLocationAsVector2() - GameState.gameCameraOffset, Color.LightGray);
                    spriteBatch.DrawString(Assets.minecraftFont12, "Defense Bonus: " + container.items[currentItem].DefenseMod, new Vector2(20, 176) + container.getLocationAsVector2() - GameState.gameCameraOffset, Color.LightGray);
                    spriteBatch.DrawString(Assets.minecraftFont12, "Attack Bonus: " + container.items[currentItem].AttackMod, new Vector2(20, 192) + container.getLocationAsVector2() - GameState.gameCameraOffset, Color.LightGray);
                    spriteBatch.DrawString(Assets.minecraftFont12, "Weight: " + container.items[currentItem].Weight, new Vector2(20, 208) + container.getLocationAsVector2() - GameState.gameCameraOffset, Color.LightGray);

                    spriteBatch.Draw(Assets.drawRect, new Rectangle((new Vector2(takeButton.X, takeButton.Y) + container.getLocationAsVector2() - GameState.gameCameraOffset).ToPoint(), new Point(takeButton.Width, takeButton.Height)), Color.DarkSlateBlue);
                    spriteBatch.DrawString(Assets.minecraftFont12, "TAKE", new Vector2(takeButton.X + 8, takeButton.Y + 8) + container.getLocationAsVector2() - GameState.gameCameraOffset, Color.LightGray);
                }
            }
            else
            {
                spriteBatch.DrawString(Assets.minecraftFont12, "---EMPTY---", itemDisplayPoints[0] + container.getLocationAsVector2() - GameState.gameCameraOffset, Color.LightGray);
            }  
        }
    }
}
