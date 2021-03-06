using FootballWordCupScoreBoard.Domain.Models;
using System;
using Xunit;

namespace FootballWordCupScoreBoard.UnitTests.Domain.Models
{
    public class ScoreTest
    {
        [Theory]
        [InlineData(0,0)]
        [InlineData(2, 3)]
        public void Score_ScoreIsPropertlyInitialized(int home, int away)
        {
            Score score = new Score(home, away);

            Assert.Equal(home, score.Home);
            Assert.Equal(away, score.Away);
            Assert.Equal(home + away, score.Total);
        }

        [Theory]
        [InlineData(0, -1)]
        [InlineData(-1, 0)]
        public void Score_LessThanZeroScore_ShouldThrowException(int home, int away)
        {
            var exception = Assert.Throws<Exception>(() => new Score(home, away));
            Assert.Equal("Score can not be less than 0", exception.Message);
        }
    }
}
