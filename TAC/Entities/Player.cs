using Microsoft.Xna.Framework.Input;
using System;
using System.Diagnostics;

namespace TAC
{
    class Player : Entity
    {

        float currentSpeed = 1.5f;
        float walkSpeed = 1.5f;
        float runSpeed = 2.5f;
        int stamina = 100;
        bool tired = false;
        Stopwatch cooldown = new Stopwatch();

        public Player() : base()
        {
            X = 10;
            Y = 10;
            MaxHealth = 10;
            Health = MaxHealth;
        }

        public override void tick()
        {
            float xMove = 0.0f, yMove = 0.0f;

            //HANDLE RUNNING

            if (Keyboard.GetState().IsKeyDown(Keys.LeftShift) && !tired)
            {
                currentSpeed = runSpeed;
                stamina--;
            }
            else
            {
                currentSpeed = walkSpeed;
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

            move(xMove, yMove);
        }
    }
}
