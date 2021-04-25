using System;

namespace FootballWordCupScoreBoard.Domain.Models
{
    public class Team
    {
        public string Name { get; }

        public Team(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new Exception("Team name cannot be empty");
            }

            Name = name;
        }
    }
}
