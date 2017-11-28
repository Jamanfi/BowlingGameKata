using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingGameKata
{
    internal class ScoreCalculator
    {
        private readonly List<Frame> frames;

        public ScoreCalculator(List<Frame> frames)
        {
            this.frames = frames;
        }

        public int CalculateScore()
        {
            CalculateBonuses();
            return frames.Sum(frame => frame.Score);
        }

        private void CalculateBonuses()
        {
            for (int i = 0; i < frames.Count; i++)
            {
                if (frames[i].Spare)
                {
                    CalculateSpareBonus(i);
                }
                else if (frames[i].Strike)
                {
                    CalculateStrikeBonus(i);
                }
            }
        }

        private void CalculateStrikeBonus(int index)
        {
            int rolls = 0;
            frames[index].Bonus = 0;
            for (int i = index + 1; i < frames.Count && rolls < 2; i++)
            {
                for (int j = 0; j < frames[i].Rolls.Count && rolls < 2; j++)
                {
                    frames[index].Bonus += frames[i].Rolls[j];
                    rolls++;
                }
            }
        }

        private void CalculateSpareBonus(int index)
        {
            if (index + 1 < frames.Count)
            {
                if (frames[index + 1].Rolls.Count > 0)
                {
                    frames[index].Bonus = frames[index + 1].Rolls[0];
                }
            }
        }

    }
}
