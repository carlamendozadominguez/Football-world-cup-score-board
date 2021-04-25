using System;

namespace FootballWordCupScoreBoard.Domain.Models
{
    public class Score
    {
        public int Home { get; }

        public int Away { get; }

        public int Total { get; } 

        public Score(int home = 0, int away = 0)
        {
            if(home < 0 || away < 0)
            {
                throw new Exception("Score can not be less than 0");
            }

            Home = home;
            Away = away;
            Total = home + away;
        }
    }
}
