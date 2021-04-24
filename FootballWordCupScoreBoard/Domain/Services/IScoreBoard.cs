using FootballWordCupScoreBoard.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FootballWordCupScoreBoard.Domain.Service
{
    public interface IScoreBoard
    {
        Game StartGame(string homeTeamName, string awayTeamName);

        void FinishGame(string homeTeamName, string awayTeamName);
    }
}
