using FootballWordCupScoreBoard.Domain.Models;
using FootballWordCuScoreBoard.Intrastructure;
using System.Collections.Generic;


namespace FootballWordCupScoreBoard.UnitTests.Domain.Service
{
    class GameRepositoryStub : IGameRepository
    {
        List<Game> board = new List<Game>();

        public Game Add(Game game)
        {
            board.Add(game);

            return game;
        }
    }
}
