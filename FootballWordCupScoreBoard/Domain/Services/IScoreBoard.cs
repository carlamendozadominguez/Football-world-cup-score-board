using FootballWordCupScoreBoard.Domain.Models;

namespace FootballWordCupScoreBoard.Domain.Service
{
    public interface IScoreBoard
    {
        Game StartGame(string homeTeamName, string awayTeamName);

        void FinishGame(string homeTeamName, string awayTeamName);

        Game UpdateScoreGame(string homeTeamName, string awayTeamName, int homeScore, int awayScore);

    }
}
