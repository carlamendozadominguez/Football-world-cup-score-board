using FootballWordCupScoreBoard.Domain.Models;
using System.Collections.Generic;

namespace FootballWordCupScoreBoard.Infrastructure
{
    public interface IGameRepository
    {
        Game Add(Game game);

        Game Update(Game game);

        Game FindByTeamNames(string homeTeamName, string awayTeamName);

        List<Game> GetBoard();

    }
}
