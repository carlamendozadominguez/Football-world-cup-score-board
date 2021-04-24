using FootballWordCupScoreBoard.Domain.Models;
using FootballWordCuScoreBoard.Intrastructure;
using System;

namespace FootballWordCuScoreBoard.Domain.Service
{
    public class ScoreBoard : IScoreBoard
    {
        public IGameRepository gameRepository;

        public ScoreBoard(IGameRepository gameRepository)
        {
            this.gameRepository = gameRepository;
        }

        public Game StartGame(string homeTeamName, string awayTeamName)
        {
            Game findGame = this.gameRepository.FindByTeamNames(homeTeamName, awayTeamName);

            if (findGame != null)
            {
                throw new Exception("Game is already started");
            }

            var homeTeam = new Team(homeTeamName);
            var awayTeam = new Team(awayTeamName);

            Game game = new Game(homeTeam, awayTeam);

            return this.gameRepository.Add(game);
        }

        public void FinishGame(string homeTeamName, string awayTeamName)
        {
            Game game = this.gameRepository.FindByTeamNames(homeTeamName, awayTeamName);
            if(game == null)
            {
                throw new Exception("Game not found");
            }

            if (game.FinishAt != null)
            {
                throw new Exception("Game is already finished");
            }

            game.Finish();

            Game updatedGame = this.gameRepository.Update(game);

        }
    }
}
