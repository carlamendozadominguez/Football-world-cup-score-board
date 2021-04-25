using System;

namespace FootballWordCupScoreBoard.Domain.Models
{
    public class Game
    {
        public Team HomeTeam { get; }

        public Team AwayTeam { get; }

        public DateTime StartAt { get; }

        public DateTime? FinishAt { get; private set; }

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

        public void Finish()
        {
            this.FinishAt = DateTime.UtcNow;
        }

    }
}
