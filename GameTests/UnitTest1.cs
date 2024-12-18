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
            // Initialize GameHandler and weather station
            var weatherStation = Mock.Of<IWeatherStation>();
            var gameHandler = new GameHandler(weatherStation);

            // Act
            // Start fight with a dice result of 6 for player and 1 for enemy
            var result = gameHandler.HandleFight(6, 1);

            // Assert
            // Check that player win, score increase by 5 and player's life points stay at 15
            result.Should().Be(Result.Win);
            gameHandler.Player.Score.Should().Be(5);
            gameHandler.Player.LifePoints.Should().Be(15);
        }

        [Fact]
        public void TestFight_PlayerAndEnemyTie_TieResultPlayerScoreStay0AndLifePointsStayMax()
        {
            // Arrange
            // Initialize GameHandler and weather station
            var weatherStation = Mock.Of<IWeatherStation>();
            var gameHandler = new GameHandler(weatherStation);

            // Act
            // Start fight with a dice result of 5 for player and enemy
            var result = gameHandler.HandleFight(5, 5);

            // Assert
            // Check that result is tie, score stay at 0 and player's life points stay at 15
            result.Should().Be(Result.Tie);
            gameHandler.Player.Score.Should().Be(0);
            gameHandler.Player.LifePoints.Should().Be(15);
        }

        [Fact]
        public void TestFight_PlayerLoseBy2_LoseResultPlayerScoreStay0AndLifePointsDecreaseBy2()
        {
            // Arrange
            // Initialize GameHandler and weather station
            var weatherStation = Mock.Of<IWeatherStation>();
            var gameHandler = new GameHandler(weatherStation);

            // Act
            // Start fight with a dice result of 2 for player and 4 for enemy
            var result = gameHandler.HandleFight(2, 4);

            // Assert
            // Check that result is lose, score stay at 0 and player's life points decrease by 2
            result.Should().Be(Result.Lose);
            gameHandler.Player.Score.Should().Be(0);
            gameHandler.Player.LifePoints.Should().Be(13);
        }


        [Fact]
        public void TestPlayerLoot_PlayerUseLifePotionAndTrickDice_PlayerLifeIncreaseBy2PlayerDiceBy1AndWinResult()
        {
            // Arrange
            // Initialize GameHandler and weather station
            var weatherStation = Mock.Of<IWeatherStation>();
            var gameHandler = new GameHandler(weatherStation);

            // Act
            // Start fight with a dice result of 2 for player and 3 for enemy
            gameHandler.LootManager.LaunchTestLoot(gameHandler.Player.LootList);
            var result = gameHandler.HandleTestGame(3, 3);

            // Assert
            // Check that result is tie because of the trick dice, score stay at 0 and player's life points stay at 15
            result.Should().Be(Result.Win);
            gameHandler.Player.Score.Should().Be(1);
            gameHandler.Player.LifePoints.Should().Be(17);
        }
    }
}