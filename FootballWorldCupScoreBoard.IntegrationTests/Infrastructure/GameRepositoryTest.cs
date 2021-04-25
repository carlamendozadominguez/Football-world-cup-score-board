using FootballWordCupScoreBoard.Domain.Models;
using FootballWordCupScoreBoard.Infrastructure;
using System.Linq;
using Xunit;

namespace FootballWordCupScoreBoard.UnitTests.Repository
{
    public class GameRepositoryTest
    {

        private readonly IGameRepository gameRepository;

        public GameRepositoryTest()
        {
            this.gameRepository = new GameRepository();
        }

        [Fact]
        public void Add_ShouldNotReturnAnException()
        {
            var home = new Team("home");
            var away = new Team("away");
            var gameToAdd = new Game(home, away);

            this.gameRepository.Add(gameToAdd);
        }

        [Fact]
        public void FindByTeamNames_ShouldGetGameByTeamName()
        {
            var home = new Team("home");
            var away = new Team("away");
            var gameToAdd = new Game(home, away);

            this.gameRepository.Add(gameToAdd);

            var gameAdded = this.gameRepository.FindByTeamNames(home.Name, away.Name);

            Assert.Equal(gameAdded.HomeTeam.Name, home.Name);
            Assert.Equal(gameAdded.AwayTeam.Name, away.Name);
        }

        [Fact]
        public void FindByTeamNames_NotExistingGame_ShouldReturnNull()
        {
            var game = this.gameRepository.FindByTeamNames("home", "away");

            Assert.Null(game);
        }

        [Fact]
        public void Update_ShouldUpdateGame()
        {
            var home = new Team("home");
            var away = new Team("away");
            var gameToAdd = new Game(home, away);

            var gameAdded = this.gameRepository.Add(gameToAdd);

            gameAdded.Score = new Score(5, 2);

            var gameUpdated = this.gameRepository.Update(gameAdded);

            Assert.Equal(5, gameUpdated.Score.Home);
            Assert.Equal(2, gameUpdated.Score.Away);
        }

        [Fact]
        public void Update_NotExistingGame_ShouldReturnNull()
        {
            var home = new Team("home");
            var away = new Team("away");
            var gameToAdd = new Game(home, away);

            var gameUpdated = this.gameRepository.Update(gameToAdd);

            Assert.Null(gameUpdated);
        }

        [Fact]
        public void GetBoard_ShouldGetGames()
        {
            var home = new Team("home");
            var away = new Team("away");
            var gameToAdd = new Game(home, away);

            var gameAdded = this.gameRepository.Add(gameToAdd);

            var board = this.gameRepository.GetBoard();

            Assert.Equal(gameAdded, board.FirstOrDefault());
        }
    }
}
