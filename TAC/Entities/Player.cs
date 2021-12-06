using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace TAC
{
    class Player : Entity
    {

        private float currentSpeed = 1.5f;
        private float walkSpeed = 1.5f;
        private float runSpeed = 2.5f;
        private int stamina = 100;
        private double carryWeight = 0.0d;
        private double carryCapacity = 10.0d;
        public int Attack { get; set; }
        public int Defense { get; set; }

        private bool tired = false;
        private Stopwatch cooldown = new Stopwatch();
        private Animation[] walkingAnimations;
        private Animation currentAnimation;
        private Rectangle idleFrame;
        private bool moving = false;
        private int animationWalkFrameDelta = 250,
                    animationRunFrameDelta = 150;

        public Item Hand { get; set; }
        public Item Head { get; set; }
        public Item Chest { get; set; }
        public Item Legs { get; set; }
        public Item Feet { get; set; }
        public List<Item> items = new List<Item>();

        public Player() : base()
        {
            X = 64;
            Y = 64;
            CollisionBounds = new Rectangle(8, 16, 16, 16);
            MaxHealth = 10;
            Health = 6;
            Attack = 2;
            Defense = 1;

            //up, down, left, right in order
            walkingAnimations = new Animation[]{ new Animation(4, 250, new Rectangle[]{ new Rectangle(32, 96, 32, 32),
                                                                                        new Rectangle(0,  96, 32, 32),
                                                                                        new Rectangle(32, 96, 32, 32),
                                                                                        new Rectangle(64, 96, 32, 32)}),
                                                 new Animation(4, 250, new Rectangle[]{ new Rectangle(32, 0, 32, 32),
                                                                                        new Rectangle(0,  0, 32, 32),
                                                                                        new Rectangle(32, 0, 32, 32),
                                                                                        new Rectangle(64, 0, 32, 32)}),
                                                 new Animation(4, 250, new Rectangle[]{ new Rectangle(32, 32, 32, 32),
                                                                                        new Rectangle(0,  32, 32, 32),
                                                                                        new Rectangle(32, 32, 32, 32),
                                                                                        new Rectangle(64, 32, 32, 32)}),
                                                 new Animation(4, 250, new Rectangle[]{ new Rectangle(32, 64, 32, 32),
                                                                                        new Rectangle(0,  64, 32, 32),
                                                                                        new Rectangle(32, 64, 32, 32),
                                                                                        new Rectangle(64, 64, 32, 32)})};

            currentAnimation = walkingAnimations[1]; //down animation as standard
            idleFrame = new Rectangle(32, 0, 32, 32);
        }

        public void addItem(Item i)
        {
            if (carryWeight + i.Weight <= carryCapacity)
            {
                items.Add(i);
                carryWeight += i.Weight;
            }
        }

        public void removeItem(Item i)
        {
            items.Remove(i);
            carryWeight -= i.Weight;
        }

        protected void equipItem(Item i)
        {
            switch (i.Slot)
            {
                case "hand":
                    if (Hand != null)
                    {
                        items.Add(Hand);
                        Hand = null;
                    }

                    Hand = i;
                    items.Remove(i);
                    break;

                case "head":
                    if (Head != null)
                    {
                        items.Add(Head);
                        Head = null;
                    }

                    Head = i;
                    items.Remove(i);
                    break;

                case "chest":
                    if (Chest != null)
                    {
                        items.Add(Chest);
                        Chest = null;
                    }

                    Chest = i;
                    items.Remove(i);
                    break;

                case "legs":
                    if (Legs != null)
                    {
                        items.Add(Legs);
                        Legs = null;
                    }

                    Legs = i;
                    items.Remove(i);
                    break;

                case "feet":
                    if (Feet != null)
                    {
                        items.Add(Feet);
                        Feet = null;
                    }

                    Feet = i;
                    items.Remove(i);
                    break;
            }
        }

        public override void tick()
        {

            //--------------DO MOVEMENT--------------
            float xMove = 0.0f, yMove = 0.0f;
            //HANDLE RUNNING
            if (Keyboard.GetState().IsKeyDown(Keys.LeftShift) && !tired)
            {
                currentSpeed = runSpeed;
                currentAnimation.FrameDelta = animationRunFrameDelta;
                stamina--;
            }
            else
            {
                currentSpeed = walkSpeed;
                currentAnimation.FrameDelta = animationWalkFrameDelta;
                if (stamina < 100)
                    stamina++;
            }

            if (stamina == 0 && !tired)
            {
                tired = true;
                cooldown.Restart();
            }
            if (tired && cooldown.Elapsed.TotalSeconds >= 5)
            {
                tired = false;
                cooldown.Stop();
            }
            //HANDLE INPUT
            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                yMove -= currentSpeed;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                xMove -= currentSpeed;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                yMove += currentSpeed;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                xMove += currentSpeed;
            }
            //LIMIT DIAGONAL MOVEMENT TO SAME SPEED
            if (xMove != 0 && yMove != 0)
            {
                float diagonalMoveCoefficient = (float)Math.Sqrt((currentSpeed * currentSpeed) / 2) / currentSpeed;
                xMove *= diagonalMoveCoefficient;
                yMove *= diagonalMoveCoefficient;
            }
            //FINALIZE MOVEMENT
            moveX(xMove);
            moveY(yMove);

            //--------------TICK ANIMATION--------------
            if (xMove < 0.0f) //if left or diagonal left
            {
                if (currentAnimation != walkingAnimations[2])
                {
                    walkingAnimations[2].reset();
                }
                currentAnimation = walkingAnimations[2];
            }
            else if (xMove > 0.0f) //if right or diagonal right
            {
                if (currentAnimation != walkingAnimations[3])
                {
                    walkingAnimations[3].reset();
                }
                currentAnimation = walkingAnimations[3];
            }
            else if (yMove < 0.0f) //if up
            {
                if (currentAnimation != walkingAnimations[0])
                {
                    walkingAnimations[0].reset();
                }
                currentAnimation = walkingAnimations[0];
            }
            else if (yMove > 0.0f) //if down
            {
                if (currentAnimation != walkingAnimations[1])
                {
                    walkingAnimations[1].reset();
                }
                currentAnimation = walkingAnimations[1];
            }
            if (xMove != 0 || yMove != 0)
            {
                moving = true;
                currentAnimation.tick();
            }
            else
            {
                moving = false;
            }
        }

        public override void render(SpriteBatch spriteBatch)
        {
            if (moving)
            {
                spriteBatch.Draw(Assets.characters, new Rectangle((int)X - GameState.gameCameraOffsetX, (int)Y - GameState.gameCameraOffsetY, 32, 32), currentAnimation.getCurrentFrame(), Color.White);
            }
            else
            {
                spriteBatch.Draw(Assets.characters, new Rectangle((int)X - GameState.gameCameraOffsetX, (int)Y - GameState.gameCameraOffsetY, 32, 32), idleFrame, Color.White);
            }
        }
    }
}
