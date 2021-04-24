using FootballWordCupScoreBoard.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace FootballWordCupScoreBoard.UnitTests.Domain.Models
{
    public class GameTest
    {
        [Fact]
        public void Game_GameIsPropertlyInitialized()
        {
            Game game = new Game(new Team("home"), new Team("away"));

            Assert.NotNull(game.StartAt);
            Assert.Null(game.FinishAt);
            Assert.Equal("home", game.HomeTeam.Name);
            Assert.Equal("away", game.AwayTeam.Name);
            Assert.Equal(0, game.Score.Total);
        }

        [Fact]
        public void Game_NullTeam_ShouldThrowException()
        {
            var exception = Assert.Throws<Exception>(() => new Game(null, new Team("away")));
            Assert.Equal("A game must have two teams to start", exception.Message);
        }

        [Fact]
        public void Finish_ShouldSetGameFinishDate()
        {
            Game game = new Game(new Team("home"), new Team("away"));
            game.Finish();

            Assert.NotNull(game.FinishAt);
        }
    }
}
