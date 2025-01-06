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
        public IWeatherStation _weatherStation;
        public IMonsterFactory _monsterFactory;

        public GameHandler(IWeatherStation weatherStation, IMonsterFactory monsterFactory)
        {
            Player = new Player(15);
            LootManager = new LootManager();
            _weatherStation = weatherStation;
            _monsterFactory = monsterFactory;
        }

        public Result HandleGame()
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
                    HandleGame();
                    break;
            }
            Console.WriteLine("Next Fight ! LifePoints : " + Player.LifePoints + "  Score : " + Player.Score);
            return result;
        }

        public Result HandleFight(int playerDice, int enemyDice)
        {
            var weatherResult =_weatherStation.WhichWeather();
            var monsterType = _monsterFactory.WhichMonsterType();
            Console.WriteLine("Fighters prepare to attack !");
            Console.WriteLine("Checking your inventory for bonus !");
            if (playerDice != 6)
            { 
                 playerDice = LootManager.CheckPlayerLootDice(playerDice, Player); 
            }
            if(enemyDice != 6 && monsterType == MonsterType.Strong)
            {
                enemyDice += 1;
            }
            Console.WriteLine("Your damage : " + playerDice + " Enemy damage : " + enemyDice);
            if (playerDice == enemyDice)
            {
                return Result.Tie;
            }
            if (WinFight(playerDice, enemyDice))
            {
                if (monsterType == MonsterType.Weak)
                {
                    var winGap = playerDice - enemyDice;
                    winGap *= 2;
                    Player.WinFight(winGap);
                    return Result.Win;
                }
                else
                {
                    var winGap = playerDice - enemyDice;
                    Player.WinFight(winGap);
                    return Result.Win;
                }
            }
            else
            {
                if (weatherResult == Weather.Stormy)
                {
                    var loseGap = enemyDice - playerDice;
                    loseGap *= 2;
                    Player.LoseFight(loseGap);
                }
                else
                {
                    var loseGap = enemyDice - playerDice;
                    Player.LoseFight(loseGap);
                }
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
