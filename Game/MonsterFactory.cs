using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Course.Game
{
    internal class MonsterFactory : IMonsterFactory
    {
        private readonly Random _random;

        public MonsterFactory()
        {
            _random = new Random();
        }

        public MonsterType WhichMonsterType()
        {
            var monsterType = _random.Next(0, 15);
            if(monsterType >= 0 && monsterType < 5)
            {
                return MonsterType.Weak;
            }
            if(monsterType >= 5 && monsterType < 10) 
            { 
                return MonsterType.Average; 
            }
            else
            {
                return MonsterType.Strong;
            }
        }
    }
}
