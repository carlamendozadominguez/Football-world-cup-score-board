using FootballWordCuScoreBoard.Domain.Service;
using System;
using Xunit;

namespace FootballWordCupScoreBoard.UnitTests.Domain.Service
{
    public class ScoreBoardTest
    {
        private readonly GameRepositoryStub gameRepositoryStub;

        private readonly IScoreBoard scoreBoard;

        public ScoreBoardTest()
        {
            this.gameRepositoryStub = new GameRepositoryStub();

            this.scoreBoard = new ScoreBoard(gameRepositoryStub);
        }

        [Fact]
        public void StartGame_ShouldReturnGameAdded()
        {
            string homeTeamName = "homeTeamName";
            string awayTeamName = "awayTeamName";

            var result = this.scoreBoard.StartGame(homeTeamName, awayTeamName);

            Assert.Equal(0, result.Score.Away);
            Assert.Equal(0, result.Score.Home);
            Assert.Equal(homeTeamName, result.HomeTeam.Name);
            Assert.Equal(awayTeamName, result.AwayTeam.Name);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void StartGame_EmptyTeamName_ShouldThrowException(string awayTeamName)
        {
            string homeTeamName = "homeTeamName";

            var exception = Assert.Throws<Exception>(()=> this.scoreBoard.StartGame(homeTeamName, awayTeamName));
            Assert.Equal("Team name cannot be empty", exception.Message);
        }
    }
}
