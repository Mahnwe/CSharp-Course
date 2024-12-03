using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Course.Game
{
    public class LootManager
    {
        private Random random;
        public List<Loot> ManagerLootList { get; private set; }

        public LootManager()
        {
            random = new Random();
            ManagerLootList = new List<Loot>();
            AddLootToList();
        }

        public void AddLootToList()
        {
            ManagerLootList.Add(new Loot("Life potion", 0, 2));
            ManagerLootList.Add(new Loot("Trick dice", 1, 0));
            ManagerLootList.Add(new Loot("Old paper", 0, 0));
        }
        public Loot LaunchRandomLoot()
        {
            var LootResult = random.Next(1, 10);
            switch(LootResult)
            {
                case 6:
                    Console.WriteLine("You have looted a life potion ! Your life points increase by 2");
                    return ManagerLootList[0];
                case 7:
                    Console.WriteLine("You have looted a life potion ! Your life points increase by 2");
                    return ManagerLootList[0];
                case 10:
                    Console.WriteLine("You have looted a trick dice ! Your dice score increase by 1");
                    return ManagerLootList[1];
                default:
                    Console.WriteLine("You have looted an useless old paper");
                    return ManagerLootList[2];
            }
        }
    }
}
