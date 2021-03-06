using FootballWordCupScoreBoard.Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace FootballWordCupScoreBoard.Infrastructure
{
    public class GameRepository : IGameRepository
    {
        List<Game> board = new List<Game>();

        public Game Add(Game game)
        {
            board.Add(game);

            return game;
        }

        public Game Update(Game game)
        {
            Game gameToUpdate = this.board.FirstOrDefault(boardGame => boardGame == game);
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
                   && boardGame.AwayTeam.Name == awayTeamName && boardGame.FinishAt == null);
        }

        public List<Game> GetBoard()
        {
            return board
                .Where(boardGame => boardGame.FinishAt == null)
                .OrderByDescending(boardGame => boardGame.Score.Total)
                .ThenByDescending(boardGame => boardGame.StartAt)
                .ToList();
        }
    }
}
