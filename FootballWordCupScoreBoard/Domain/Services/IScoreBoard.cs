using FootballWordCupScoreBoard.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FootballWordCuScoreBoard.Domain.Service
{
    public interface IScoreBoard
    {
        Game StartGame(string homeTeamName, string awayTeamName);
    }
}
