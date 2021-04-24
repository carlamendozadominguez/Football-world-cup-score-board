using System;
using System.Collections.Generic;
using System.Text;

namespace FootballWordCupScoreBoard.Domain.Models
{
    public class Team
    {
        public string Name { get; set; }

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
