using FootballWordCupScoreBoard.Domain.Models;
using FootballWordCuScoreBoard.Intrastructure;
using System.Collections.Generic;
using System.Linq;

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

        public Game Update(Game game)
        {
            Game gameToUpdate = this.board.FirstOrDefault(boardGame => boardGame == game && boardGame.FinishAt != null);
            if (gameToUpdate != null)
            {
                gameToUpdate = game;
            }

            return gameToUpdate;
        }

        public Game FindByTeamNames(string homeTeamName, string awayTeamName)
        {
            return board
                .FirstOrDefault(boardGame =>
                   boardGame.HomeTeam.Name == homeTeamName
                   && boardGame.AwayTeam.Name == awayTeamName);
        }



    }
}
