using FootballWordCupScoreBoard.Domain.Models;

namespace FootballWordCuScoreBoard.Intrastructure
{
    public interface IGameRepository
    {
        Game Add(Game game);

        Game Update(Game game);

        Game FindByTeamNames(string homeTeamName, string awayTeamName);
    }
}
