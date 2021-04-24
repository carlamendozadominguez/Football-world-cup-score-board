using FootballWordCupScoreBoard.Domain.Models;
using System.Collections.Generic;

namespace FootballWordCuScoreBoard.Intrastructure
{
    public class GameRepository : IGameRepository
    {
        List<Game> board = new List<Game>();

        public Game Add(Game game)
        {
            board.Add(game);

            return game;
        }
    }
}
