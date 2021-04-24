using FootballWordCupScoreBoard.Domain.Models;

namespace FootballWordCuScoreBoard.Intrastructure
{
    public interface IGameRepository
    {
        Game Add(Game game);

    }
}
