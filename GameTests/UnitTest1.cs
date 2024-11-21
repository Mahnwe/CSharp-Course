using CSharp_Course.Game;
using Xunit;

namespace CSharp_Course.GameTests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            // Arrange
            var gameHandler = new GameHandler();

            // Act
            var result = gameHandler.StartFight(6, 1);

            // Assert
            if (result != Result.Win)
                Assert.Fail();
            if (gameHandler.Player.Score != 5)
                Assert.Fail();
            if (gameHandler.Player.LifePoints != 15)
                Assert.Fail();
        }
    }
}