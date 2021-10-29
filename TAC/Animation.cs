using Microsoft.Xna.Framework;
using System.Diagnostics;

namespace TAC
{
    class Animation
    {
        public int FrameCount { get; set; }
        public Rectangle[] Frames { get; set; }
        public int CurrentFrame { get; set; }
        public int FrameDelta { get; set; }
        public Stopwatch FrameTimer { get; set; }

        public Animation()
        {
            FrameCount = 0;
            FrameDelta = 0;
            Frames = new Rectangle[0];
            CurrentFrame = 0;
            FrameTimer = new Stopwatch();
            FrameTimer.Start();
        }

        public Animation(int frameCount, int frameDelta, Rectangle[] frames)
        {
            FrameCount = frameCount;
            FrameDelta = frameDelta;
            Frames = frames;
            CurrentFrame = 0;
            FrameTimer = new Stopwatch();
            FrameTimer.Start();
        }

        public void reset()
        {
            CurrentFrame = 0;
            FrameTimer.Restart();
        }

        public void tick()
        {
            if (FrameTimer.Elapsed.TotalMilliseconds >= FrameDelta)
            {
                CurrentFrame++;
                FrameTimer.Restart();
            }

            if (CurrentFrame >= FrameCount)
            {
                CurrentFrame = 0;
            }
        }

        public Rectangle getCurrentFrame()
        {
            return Frames[CurrentFrame];
        }
    }
}
