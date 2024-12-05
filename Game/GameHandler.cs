using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Course.Game
{
    public class GameHandler
    {
        public Player Player { get; }
        public LootManager LootManager { get; }

        public GameHandler()
        {
            Player = new Player(15);
            LootManager = new LootManager();
        }

        public Result StartFight(int playerDice, int enemyDice)
        {
            Console.WriteLine("Fighters prepare to attack !");
            Console.WriteLine("Checking your inventory for bonus !");
            Console.WriteLine(playerDice);
            if (playerDice != 6)
            { 
                 playerDice = CheckPlayerLootDice(playerDice); 
            }
            
            Console.WriteLine("Your damage : " + playerDice + " Enemy damage : " + enemyDice);
            if (playerDice == enemyDice)
            {
                return Result.Tie;
            }
            if (WinFight(playerDice, enemyDice))
            {
                var winGap = playerDice - enemyDice;
                Player.WinFight(winGap);
                LootManager.LaunchRandomLoot(Player.LootList);
                CheckPlayerLootLife();
                return Result.Win;
            }
            else
            {
                var loseGap = enemyDice - playerDice;
                Player.LoseFight(loseGap);
                return Result.Lose;
            }
        }

        public bool WinFight(int dice1, int dice2)
        {
            return dice1 > dice2;
        }


        public void CheckPlayerLootLife()
        {
            for (int i = 0; i < Player.LootList.Count; i++)
            {
                if (Player.LootList[i].Name == "Life potion")
                {
                    Console.WriteLine("You drank a life potion ! Your life points increased by 2");
                    Player.DrinkLifePotion(Player.LootList[i].LifeBonus);
                    Player.LootList.RemoveAt(i);
                }
            }
        }
        public int CheckPlayerLootDice(int playerDice)
        {
            for (int i = 0; i < Player.LootList.Count; i++)
            {
                if (Player.LootList[i].Name == "Trick dice")
                {
                    Console.WriteLine("You used a trick dice ! Your dice's score increased by 1");
                    playerDice += Player.LootList[i].DiceBonus;
                    Player.LootList.RemoveAt(i);
                }
            }
            return playerDice;
        }
    }
}
