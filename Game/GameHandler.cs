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

        public void HandleGame()
        {
            var dice = new Dice();
            var result = HandleFight(dice.RollDice(), dice.RollDice());
            switch (result)
            {
                case Result.Win:
                    Console.WriteLine("You win !");
                    LootManager.LaunchRandomLoot(Player.LootList);
                    LootManager.CheckPlayerLootLife(Player);
                    break;
                case Result.Lose:
                    Console.WriteLine("You lose !");
                    break;
                case Result.Tie:
                    Console.WriteLine("That's a tie ! Let's fight again !");
                    break;
            }

            Console.WriteLine("Next Fight ! LifePoints : " + Player.LifePoints + "  Score : " + Player.Score);
        }

        public Result HandleFight(int playerDice, int enemyDice)
        {
            Console.WriteLine("Fighters prepare to attack !");
            Console.WriteLine("Checking your inventory for bonus !");
            if (playerDice != 6)
            { 
                 playerDice = LootManager.CheckPlayerLootDice(playerDice, Player); 
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

        public Result HandleTestGame(int playerDice, int enemyDice)
        {
            var result = HandleFight(playerDice, enemyDice);
            switch (result)
            {
                case Result.Win:
                    Console.WriteLine("You win !");
                    LootManager.LaunchRandomLoot(Player.LootList);
                    LootManager.CheckPlayerLootLife(Player);
                    break;
                case Result.Lose:
                    Console.WriteLine("You lose !");
                    break;
                case Result.Tie:
                    Console.WriteLine("That's a tie ! Let's fight again !");
                    break;
            }

            return result;
        }
    }
}
