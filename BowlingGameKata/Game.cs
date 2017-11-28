using System;
using System.Collections.Generic;

namespace BowlingGameKata
{
    public class Game
    {
        private readonly List<Frame> frames;
        private readonly int framesToPlay;
        private int currentFrame = 1;

        public int FramesPlayed => frames.Count;
        public int RollsInCurrentFrame => frames[currentFrame - 1].Rolls.Count;

        public Game(int framesToPlay = 10)
        {
            frames = new List<Frame> {new Frame()};
            this.framesToPlay = framesToPlay;
        }

        public void Roll(int pins)
        {
            CheckCurrentFrame();
            frames[currentFrame-1].Roll(pins);
        }

        public int GetScore()
        {
            ScoreCalculator calculator = new ScoreCalculator(frames);
            return calculator.CalculateScore();
        }

        private void CheckCurrentFrame()
        {
            if (frames[currentFrame - 1].Complete && currentFrame != framesToPlay)
            {
                frames.Add(new Frame());
                currentFrame++;
            }
        }

    }
}
