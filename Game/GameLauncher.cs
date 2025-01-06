using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Course.Game
{
    public class GameLauncher
    {
        public static void LaunchGame()
        {
            Result fightResult;
            var fightWonNumber = 0;
            var weatherStation = new WeatherStation();
            var monsterFactory = new MonsterFactory();
            var gameHandler = new GameHandler(weatherStation, monsterFactory);

            Console.WriteLine("The Arena begin, prepare to fight ! LifePoints : " + gameHandler.Player.LifePoints + "  Score : " + gameHandler.Player.Score);

            while(gameHandler.Player.LifePoints > 0)
            {
                fightResult = gameHandler.HandleGame();
                if(fightResult == Result.Win)
                {
                    fightWonNumber++;
                }
                Console.WriteLine("Fight won : " + fightWonNumber);
            }
            Console.WriteLine("The Arena is finished ! You have won " + fightWonNumber + " fights with a score of " + gameHandler.Player.Score + " !");
        }
    }
}
