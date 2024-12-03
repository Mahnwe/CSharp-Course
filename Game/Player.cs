using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Course.Game
{
    public class Player
    {
        public int LifePoints {  get; private set; }
        public int Score { get; private set; }
        public List<Loot> LootList { get; private set; }

        public Player(int initLifePoints)
        {
            LifePoints = initLifePoints;
            LootList = new List<Loot>();
        }

        public void WinFight(int winGap)
        {
            Score += winGap;
        }

        public void LoseFight(int loseGap)
        {
            LifePoints -= loseGap;
        }
    }
}
