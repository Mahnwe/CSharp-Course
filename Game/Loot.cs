using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Course.Game
{
    public class Loot
    {
        public String Name { get; private set; }
        public int DiceBonus { get; private set; }

        public int LifeBonus { get; private set; }

        public Loot(string name, int diceBonus, int lifeBonus)
        {
            Name = name;
            DiceBonus = diceBonus;
            LifeBonus = lifeBonus;
        }
    }
}
