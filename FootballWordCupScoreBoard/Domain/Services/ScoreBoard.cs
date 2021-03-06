using FootballWordCupScoreBoard.Domain.Models;
using FootballWordCupScoreBoard.Infrastructure;
using System;
using System.Collections.Generic;

namespace FootballWordCupScoreBoard.Domain.Service
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
            Game game = this.GetGameByTeamNamesOrFail(homeTeamName, awayTeamName);

            game.Finish();

            Game updatedGame = this.gameRepository.Update(game);
        }

        public Game UpdateScoreGame(string homeTeamName, string awayTeamName, int homeScore, int awayScore)
        {
            Game game = this.GetGameByTeamNamesOrFail(homeTeamName, awayTeamName);

            game.Score = new Score(homeScore, awayScore);

            return this.gameRepository.Update(game);
        }

        public List<Game> GetBoard()
        {
            return this.gameRepository.GetBoard();
        }

        private Game GetGameByTeamNamesOrFail(string homeTeamName, string awayTeamName)
        {
            Game game = this.gameRepository.FindByTeamNames(homeTeamName, awayTeamName);
            if (game == null)
            {
                throw new Exception("Game not found");
            }

            return game;
        }
    }
}
