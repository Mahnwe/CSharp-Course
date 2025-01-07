using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Course.Game
{
    public class LootManager
    {
        private Dice dice;
        public List<Loot> ManagerLootList { get; private set; }

        public LootManager()
        {
            dice = new Dice();
            ManagerLootList = new List<Loot>();
            AddLootToList();
        }

        public void AddLootToList()
        {
            ManagerLootList.Add(new Loot("Life potion", 0, 2));
            ManagerLootList.Add(new Loot("Trick dice", 1, 0));
        }
        public void LaunchRandomLoot(List<Loot> playerList, int lootDice)
        {
            var LootResult = lootDice;
            switch(LootResult)
            {
                case 6:
                    Console.WriteLine("You have looted a life potion !");
                    playerList.Add(ManagerLootList[0]);
                    break;
                case 1:
                    Console.WriteLine("You have looted a trick dice !");
                    playerList.Add(ManagerLootList[1]);
                    break;
                case 4:
                    Console.WriteLine("You have looted a trick dice !");
                    playerList.Add(ManagerLootList[1]);
                    break;
                default:
                    Console.WriteLine("You haven't looted anything");
                    break;
            }
        }

        public void CheckPlayerLootLife(Player player)
        {
            for (int i = 0; i < player.LootList.Count; i++)
            {
                if (player.LootList[i].Name == "Life potion")
                {
                    Console.WriteLine("You drank a life potion ! Your life points increased by 2");
                    player.DrinkLifePotion(player.LootList[i].LifeBonus);
                    player.LootList.RemoveAt(i);
                }
            }
        }
        public int CheckPlayerLootDice(int playerDice, Player player)
        {
            for (int i = 0; i < player.LootList.Count; i++)
            {
                if (player.LootList[i].Name == "Trick dice")
                {
                    Console.WriteLine("You used a trick dice ! Your dice's score increased by 1");
                    playerDice += player.LootList[i].DiceBonus;
                    player.LootList.RemoveAt(i);
                }
            }
            return playerDice;
        }

        public void LaunchTestLoot(List<Loot> playerList)
        {
            playerList.Add(ManagerLootList[0]);
            playerList.Add(ManagerLootList[1]);
        }
    }
}
