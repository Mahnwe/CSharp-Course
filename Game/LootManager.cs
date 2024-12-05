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
        }
        public void LaunchRandomLoot(List<Loot> playerList)
        {
            var LootResult = random.Next(1, 11);
            Console.WriteLine(LootResult);
            switch(LootResult)
            {
                case 6:
                    Console.WriteLine("You have looted a life potion !");
                    playerList.Add(ManagerLootList[0]);
                    break;
                case 7:
                    Console.WriteLine("You have looted a life potion !");
                    playerList.Add(ManagerLootList[0]);
                    break;
                case 9:
                    Console.WriteLine("You have looted a trick dice !");
                    playerList.Add(ManagerLootList[1]);
                    break;
                case 10:
                    Console.WriteLine("You have looted a trick dice !");
                    playerList.Add(ManagerLootList[1]);
                    break;
                default:
                    Console.WriteLine("You haven't looted anything");
                    break;
            }
        }
    }
}
