using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Course.Game
{
    public class WeatherStation : IWeatherStation
    {
        private readonly Random _random;

        public WeatherStation()
        {
            _random = new Random();
        }

        public Weather WhichWeather()
        {
            var randomWeather = _random.Next(0, 21);
            if (randomWeather > 9 && randomWeather < 16)
            {
                Console.WriteLine("The weather is Sunny !");
                return Weather.Sunny;
            }
            if (randomWeather > 0 && randomWeather  < 10)
            {
                Console.WriteLine("The weather is Rainy !");
                return Weather.Rainy;
            }
            else
            {
                Console.WriteLine("The weather is Stormy !");
                return Weather.Stormy;
            }
        }
            

    }
}
