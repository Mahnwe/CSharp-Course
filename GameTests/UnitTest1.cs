using CSharp_Course.Game;
using Xunit;

namespace CSharp_Course.GameTests
{
    public class UnitTest1
    {
        [Fact]
        public void TestFight_PlayerWinBy5_WinResultPlayerScoreGet5PointsAndLifePointsStayMax()
        {
            // Arrange
            // Initialize GameHandler
            var gameHandler = new GameHandler();

            // Act
            // Start fight with a dice result of 6 for player and 1 for enemy
            var result = gameHandler.StartFight(6, 1);

            // Assert
            // Check that player win, score increase by 5 and player's life points stay at 15
            if (result != Result.Win)
                Assert.Fail();
            if (gameHandler.Player.Score != 5)
                Assert.Fail();
            if (gameHandler.Player.LifePoints != 15)
                Assert.Fail();
        }

        [Fact]
        public void TestFight_PlayerAndEnemyTie_TieResultPlayerScoreStay0AndLifePointsStayMax()
        {
            // Arrange
            // Initialize GameHandler
            var gameHandler = new GameHandler();

            // Act
            // Start fight with a dice result of 5 for player and enemy
            var result = gameHandler.StartFight(5, 5);

            // Assert
            // Check that result is tie, score stay at 0 and player's life points stay at 15
            if (result != Result.Tie)
                Assert.Fail();
            if (gameHandler.Player.Score != 0)
                Assert.Fail();
            if (gameHandler.Player.LifePoints != 15)
                Assert.Fail();
        }

        [Fact]
        public void TestFight_PlayerLoseBy2_LoseResultPlayerScoreStay0AndLifePointsDecreaseBy2()
        {
            // Arrange
            // Initialize GameHandler
            var gameHandler = new GameHandler();

            // Act
            // Start fight with a dice result of 2 for player and 4 for enemy
            var result = gameHandler.StartFight(2, 4);

            // Assert
            // Check that result is lose, score stay at 0 and player's life points decrease by 2
            if (result != Result.Lose)
                Assert.Fail();
            if (gameHandler.Player.Score != 0)
                Assert.Fail();
            if (gameHandler.Player.LifePoints != 13)
                Assert.Fail();
        }
    }
}