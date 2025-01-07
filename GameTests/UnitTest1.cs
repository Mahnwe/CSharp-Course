using CSharp_Course.Game;
using Xunit;
using FluentAssertions;
using Moq;

namespace CSharp_Course.GameTests
{
    public class UnitTest1
    {
        [Fact]
        public void TestFight_PlayerWinBy5_WinResultPlayerScoreGet5PointsAndLifePointsStayMax()
        {
            // Arrange
            // Initialize GameHandler and weather station and monster type
            var weatherStation = Mock.Of<IWeatherStation>();
            Mock.Get(weatherStation).Setup(m => m.WhichWeather()).Returns(Weather.Sunny);
            var monsterType = Mock.Of<IMonsterFactory>();
            Mock.Get(monsterType).Setup(m => m.WhichMonsterType()).Returns(MonsterType.Average);
            var gameHandler = new GameHandler(weatherStation, monsterType);

            // Act
            // Start fight with a dice result of 6 for player and 1 for enemy
            var result = gameHandler.HandleFight(6, 1);

            // Assert
            // Check that player win, monster type is average, weather is sunny, score increase by 5 and player's life points stay at 15
            result.Should().Be(Result.Win);
            gameHandler._monsterFactory.WhichMonsterType().Should().Be(MonsterType.Average);
            gameHandler._weatherStation.WhichWeather().Should().Be(Weather.Sunny);
            gameHandler.Player.Score.Should().Be(5);
            gameHandler.Player.LifePoints.Should().Be(15);
        }

        [Fact]
        public void TestFight_PlayerAndEnemyTie_TieResultPlayerScoreStay0AndLifePointsStayMax()
        {
            // Arrange
            // Initialize GameHandler and weather station and monster type
            var weatherStation = Mock.Of<IWeatherStation>();
            Mock.Get(weatherStation).Setup(m => m.WhichWeather()).Returns(Weather.Rainy);
            var monsterType = Mock.Of<IMonsterFactory>();
            Mock.Get(monsterType).Setup(m => m.WhichMonsterType()).Returns(MonsterType.Weak);
            var gameHandler = new GameHandler(weatherStation, monsterType);

            // Act
            // Start fight with a dice result of 5 for player and enemy
            var result = gameHandler.HandleFight(5, 5);

            // Assert
            // Check that result is tie, monster type is weak, weather is rainy, score stay at 0 and player's life points stay at 15
            result.Should().Be(Result.Tie);
            gameHandler._monsterFactory.WhichMonsterType().Should().Be(MonsterType.Weak);
            gameHandler._weatherStation.WhichWeather().Should().Be(Weather.Rainy);
            gameHandler.Player.Score.Should().Be(0);
            gameHandler.Player.LifePoints.Should().Be(15);
        }

        [Fact]
        public void TestFight_PlayerLoseBy2_LoseResultPlayerScoreStay0AndLifePointsDecreaseBy2()
        {
            // Arrange
            // Initialize GameHandler and weather station and monster type
            var weatherStation = Mock.Of<IWeatherStation>();
            Mock.Get(weatherStation).Setup(m => m.WhichWeather()).Returns(Weather.Sunny);
            var monsterType = Mock.Of<IMonsterFactory>();
            Mock.Get(monsterType).Setup(m => m.WhichMonsterType()).Returns(MonsterType.Average);
            var gameHandler = new GameHandler(weatherStation, monsterType);

            // Act
            // Start fight with a dice result of 2 for player and 4 for enemy
            var result = gameHandler.HandleFight(2, 4);

            // Assert
            // Check that result is lose, monster type is average, score stay at 0 and player's life points decrease by 2
            result.Should().Be(Result.Lose);
            gameHandler._monsterFactory.WhichMonsterType().Should().Be(MonsterType.Average);
            gameHandler._weatherStation.WhichWeather().Should().Be(Weather.Sunny);
            gameHandler.Player.Score.Should().Be(0);
            gameHandler.Player.LifePoints.Should().Be(13);
        }


        [Fact]
        public void TestPlayerLoot_PlayerUseLifePotionAndTrickDice_PlayerLifeIncreaseBy2PlayerDiceBy1AndWinResult()
        {
            // Arrange
            // Initialize GameHandler and weather station and monster type
            var weatherStation = Mock.Of<IWeatherStation>();
            Mock.Get(weatherStation).Setup(m => m.WhichWeather()).Returns(Weather.Sunny);
            var monsterType = Mock.Of<IMonsterFactory>();
            Mock.Get(monsterType).Setup(m => m.WhichMonsterType()).Returns(MonsterType.Average);
            var gameHandler = new GameHandler(weatherStation, monsterType);

            // Act
            // Start fight with a dice result of 2 for player and 3 for enemy
            gameHandler.LootManager.LaunchTestLoot(gameHandler.Player.LootList);
            var result = gameHandler.HandleTestGame(3, 3);

            // Assert
            // Check that result is tie because of the trick dice, monster type is average, score stay at 0 and player's life points stay at 15
            result.Should().Be(Result.Win);
            gameHandler._monsterFactory.WhichMonsterType().Should().Be(MonsterType.Average);
            gameHandler._weatherStation.WhichWeather().Should().Be(Weather.Sunny);
            gameHandler.Player.Score.Should().Be(1);
            gameHandler.Player.LifePoints.Should().Be(17);
        }

        [Fact]
        public void TestWeather_PlayerLoseBy2WithStormyWeather_LoseResultPlayerScoreStay0AndLifePointsDecreaseBy4()
        {
            // Arrange
            // Initialize GameHandler and weather station and monster type
            var weatherStation = Mock.Of<IWeatherStation>();
            Mock.Get(weatherStation).Setup(m => m.WhichWeather()).Returns(Weather.Stormy);
            var monsterType = Mock.Of<IMonsterFactory>();
            Mock.Get(monsterType).Setup(m => m.WhichMonsterType()).Returns(MonsterType.Average);
            var gameHandler = new GameHandler(weatherStation, monsterType);

            // Act
            // Start fight with a dice result of 2 for player and 4 for enemy
            var result = gameHandler.HandleFight(2, 4);

            // Assert
            // Check that result is lose, monster type is average, weather is stormy, score stay at 0 and player's life points decrease by 4 because of stormy weather
            result.Should().Be(Result.Lose);
            gameHandler._monsterFactory.WhichMonsterType().Should().Be(MonsterType.Average);
            gameHandler._weatherStation.WhichWeather().Should().Be(Weather.Stormy);
            gameHandler.Player.Score.Should().Be(0);
            gameHandler.Player.LifePoints.Should().Be(11);
        }

        [Fact]
        public void TestMonsterType_PlayerTieWithStrongMonster_TieResultPlayerScoreStay0AndLifePointsStay15()
        {
            // Arrange
            // Initialize GameHandler and weather station and monster type
            var weatherStation = Mock.Of<IWeatherStation>();
            Mock.Get(weatherStation).Setup(m => m.WhichWeather()).Returns(Weather.Sunny);
            var monsterType = Mock.Of<IMonsterFactory>();
            Mock.Get(monsterType).Setup(m => m.WhichMonsterType()).Returns(MonsterType.Strong);
            var gameHandler = new GameHandler(weatherStation, monsterType);

            // Act
            // Start fight with a dice result of 3 for player and 2 for enemy but tie result because enemy is strong
            var result = gameHandler.HandleFight(3, 2);

            // Assert
            // Check that result is tie, monster type is strong, score stay at 0 and player's life points stay at 15
            result.Should().Be(Result.Tie);
            gameHandler._monsterFactory.WhichMonsterType().Should().Be(MonsterType.Strong);
            gameHandler._weatherStation.WhichWeather().Should().Be(Weather.Sunny);
            gameHandler.Player.Score.Should().Be(0);
            gameHandler.Player.LifePoints.Should().Be(15);
        }

        [Fact]
        public void TestMonsterType_PlayerWinby2WithWeakMonster_WinResultPlayerScoreIncreaseby4AndLifePointsStay15()
        {
            // Arrange
            // Initialize GameHandler and weather station and monster type
            var weatherStation = Mock.Of<IWeatherStation>();
            Mock.Get(weatherStation).Setup(m => m.WhichWeather()).Returns(Weather.Sunny);
            var monsterType = Mock.Of<IMonsterFactory>();
            Mock.Get(monsterType).Setup(m => m.WhichMonsterType()).Returns(MonsterType.Weak);
            var gameHandler = new GameHandler(weatherStation, monsterType);

            // Act
            // Start fight with a dice result of 4 for player and 2 for enemy but enemy is weak
            var result = gameHandler.HandleFight(4, 2);

            // Assert
            // Check that result is win, monster type is weak, score increase by 4 because enemy is weak and player's life points stay at 15
            result.Should().Be(Result.Win);
            gameHandler._monsterFactory.WhichMonsterType().Should().Be(MonsterType.Weak);
            gameHandler._weatherStation.WhichWeather().Should().Be(Weather.Sunny);
            gameHandler.Player.Score.Should().Be(4);
            gameHandler.Player.LifePoints.Should().Be(15);
        }
    }
}