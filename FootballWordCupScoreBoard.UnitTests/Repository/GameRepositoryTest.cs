using FootballWordCupScoreBoard.Domain.Models;
using FootballWordCupScoreBoard.Intrastructure;
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
        public void Add_ShouldAddNewGame()
        {
            var home = new Team("home");
            var away = new Team("away");
            var gameToAdd = new Game(home, away);

            var result = this.gameRepository.Add(gameToAdd);

            Assert.Equal(gameToAdd, result);
        }
    }
}
