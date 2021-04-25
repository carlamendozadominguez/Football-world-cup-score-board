using FootballWordCupScoreBoard.Domain.Models;
using FootballWordCupScoreBoard.Domain.Service;
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

        [Fact]
        public void StartGame_StartedGameAlreadyExists_ShouldThrowException()
        {
            string homeTeamName = "homeTeamName";
            string awayTeamName = "awayTeamName";

            this.gameRepositoryStub.Add(new Game(new Team(homeTeamName), new Team(awayTeamName)));

            var exception = Assert.Throws<Exception>(() => this.scoreBoard.StartGame(homeTeamName, awayTeamName));
            Assert.Equal("Game is already started", exception.Message);
        }

        [Fact]
        public void FinishGame_ShouldFinishAGame()
        {
            string homeTeamName = "homeTeamName";
            string awayTeamName = "awayTeamName";

            this.gameRepositoryStub.Add(new Game(new Team(homeTeamName), new Team(awayTeamName)));
            this.scoreBoard.FinishGame(homeTeamName, awayTeamName);

        }

        [Fact]
        public void FinishGame_NotExistingGame_ShouldThrowException()
        {
            string homeTeamName = "homeTeamName";
            string awayTeamName = "awayTeamName";

            var exception = Assert.Throws<Exception>(() => this.scoreBoard.FinishGame(homeTeamName, awayTeamName));
            Assert.Equal("Game not found", exception.Message);
        }

        [Fact]
        public void UpdateScoreGame_ShouldUpdateScore()
        {
            string homeTeamName = "homeTeamName";
            string awayTeamName = "awayTeamName";

            int homeScore = 1;
            int awayScore = 1;

            this.gameRepositoryStub.Add(new Game(new Team(homeTeamName), new Team(awayTeamName)));
            this.scoreBoard.UpdateScoreGame(homeTeamName, awayTeamName, homeScore, awayScore);
        }

        [Fact]
        public void UpdateScoreGame_NotExistingGame_ShouldThrowException()
        {
            string homeTeamName = "homeTeamName";
            string awayTeamName = "awayTeamName";

            int homeScore = 1;
            int awayScore = 1;

            var exception = Assert.Throws<Exception>(() => this.scoreBoard.UpdateScoreGame(homeTeamName, awayTeamName, homeScore, awayScore));
            Assert.Equal("Game not found", exception.Message);
        }
    }
}
