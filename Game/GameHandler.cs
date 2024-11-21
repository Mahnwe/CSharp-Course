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

        public GameHandler()
        {
            Player = new Player(15);
        }

        public Result StartFight(int playerDice, int enemyDice)
        {
            Console.WriteLine("Your damage : " + playerDice + " Enemy damage : " + enemyDice);
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
            return dice1 >= dice2;
        }
    }
}
