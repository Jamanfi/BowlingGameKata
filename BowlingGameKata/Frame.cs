using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingGameKata
{
    internal class Frame
    {


        public readonly List<int> Rolls;

        public Frame()
        {
            Rolls = new List<int>();
        }

        public void Roll(int pins)
        {
            if (Rolls.Count < 3)
            {
                Rolls.Add(pins);
            }
        }

        public bool Strike => Rolls.Count == 1 && PinsKnockedDown == 10;
        public bool Spare => Rolls.Count == 2 && PinsKnockedDown == 10;
        private int PinsKnockedDown => Rolls.Sum();

        public bool Complete => Rolls.Count >= 2 || Strike || Spare;

        public int Bonus { get; set; }

        public int Score => PinsKnockedDown + Bonus;


    }
}
