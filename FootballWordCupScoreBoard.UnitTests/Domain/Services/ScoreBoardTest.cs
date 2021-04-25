using FootballWordCupScoreBoard.Domain.Models;
using FootballWordCupScoreBoard.Domain.Service;
using System;
using System.Collections.Generic;
using System.Linq;
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

            var exception = Assert.Throws<Exception>(() => this.scoreBoard.StartGame(homeTeamName, awayTeamName));
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

        [Fact]
        public void GetBoard_ShouldReturnsGamesInProperlyOrder()
        {
            List<Game> games = new List<Game>()
            {
                new Game(new Team("Mexico"), new Team("Canada"))
                {
                    Score = new Score(0, 5)
                },
                new Game(new Team("Spain"), new Team("Brazil"))
                {
                    Score = new Score(10, 2)
                },
                new Game(new Team("Germany"), new Team("France"))
                {
                    Score = new Score(2, 2)
                },
                new Game(new Team("Uruguay"), new Team("Italy"))
                {
                    Score = new Score(6, 6)
                },
                new Game(new Team("Argentina"), new Team("Australia"))
                {
                    Score = new Score(3, 1)
                }
            };
            this.gameRepositoryStub.Add(games);

            var result = this.scoreBoard.GetBoard();

            Assert.Equal(games.ElementAt(3), result.ElementAt(0));
            Assert.Equal(games.ElementAt(1), result.ElementAt(1));
            Assert.Equal(games.ElementAt(0), result.ElementAt(2));
            Assert.Equal(games.ElementAt(4), result.ElementAt(3));
            Assert.Equal(games.ElementAt(2), result.ElementAt(4));
        }

        [Fact]
        public void GetBoard_ShouldNotReturnFinishedGames()
        {
            string homeTeamName = "homeTeamName";
            string awayTeamName = "awayTeamName";

            Game game = new Game(new Team(homeTeamName), new Team(awayTeamName));
            game.Finish();

            this.gameRepositoryStub.Add(game);

            var result = this.scoreBoard.GetBoard();

            Assert.Empty(result);
        }
    }
}