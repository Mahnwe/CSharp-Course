using System;
using System.Collections.Generic;
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
            Console.WriteLine("Your damage : " + playerDice + " Enemy damage : " + enemyDice);
            if (playerDice == enemyDice)
            {
                return Result.Tie;
            }
            if (WinFight(playerDice, enemyDice))
            {
                var winGap = playerDice - enemyDice;
                Player.WinFight(winGap);
                Player.LootList.Add(LootManager.LaunchRandomLoot());
                for (int i = 0; i < Player.LootList.Count; i++)
                {
                    Console.WriteLine(Player.LootList[i].Name);
                }
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
    }
}
