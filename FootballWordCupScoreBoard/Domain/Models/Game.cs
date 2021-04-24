using FootballWordCupScoreBoard.Domain;
using System;

namespace FootballWordCupScoreBoard.Domain.Models
{
    public class Game
    {
        public Team HomeTeam { get; set; }

        public Team AwayTeam { get; set; }

        public DateTime StartAt { get; set; }

        public DateTime? FinishAt { get; set; }

        public Score Score { get; set; }

        public Game(Team homeTeam, Team awayTeam)
        {
            if(homeTeam == null || awayTeam == null)
            {
                throw new Exception("A game must have two teams to start");
            }

            Score = new Score();
            StartAt = DateTime.UtcNow;
            HomeTeam = homeTeam;
            AwayTeam = awayTeam;
        }
    }
}
