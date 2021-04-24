using FootballWordCupScoreBoard.Domain.Models;
using FootballWordCuScoreBoard.Intrastructure;
using System;

namespace FootballWordCuScoreBoard.Domain.Service
{
    public class ScoreBoard : IScoreBoard
    {
        public IGameRepository game;

        public ScoreBoard(IGameRepository gameRepository)
        {
            this.game = gameRepository;
        }

        public Game StartGame(string homeTeamName, string awayTeamName)
        {
            var homeTeam = new Team(homeTeamName);
            var awayTeam = new Team(awayTeamName);

            Game game = new Game(homeTeam, awayTeam);

            return this.game.Add(game);
        }
    }
}
