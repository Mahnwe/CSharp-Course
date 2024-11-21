using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Course.Game
{
    public class GameLauncher
    {
        public static void LaunchGame()
        {
            var dice = new Dice();
            var gameHandler = new GameHandler();
            Console.WriteLine("The Arena begin, prepare to fight ! LifePoints : " + gameHandler.Player.LifePoints + "  Score : " + gameHandler.Player.Score);
            while(gameHandler.Player.LifePoints > 0)
            {
                var result = gameHandler.StartFight(dice.RollDice(), dice.RollDice());
                switch (result)
                {
                    case Result.Win:
                        Console.WriteLine("You win !");
                        break;
                    case Result.Lose:
                        Console.WriteLine("You lose !");
                        break;
                }
                Console.WriteLine("Next Fight ! LifePoints : " + gameHandler.Player.LifePoints + "  Score : " + gameHandler.Player.Score);
            }
        }
    }
}
