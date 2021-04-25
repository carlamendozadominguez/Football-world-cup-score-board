using FootballWordCupScoreBoard.Domain.Models;
using System.Collections.Generic;

namespace FootballWordCupScoreBoard.Domain.Service
{
    public interface IScoreBoard
    {
        Game StartGame(string homeTeamName, string awayTeamName);

        void FinishGame(string homeTeamName, string awayTeamName);

        Game UpdateScoreGame(string homeTeamName, string awayTeamName, int homeScore, int awayScore);

        List<Game> GetBoard();

    }
}
