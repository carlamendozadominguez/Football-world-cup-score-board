using FootballWordCupScoreBoard.Domain.Models;
using FootballWordCupScoreBoard.Domain.Service;
using System;
using System.Collections.Generic;

namespace FootballWordCupScoreBoard.Presentation
{
    public class ScoreBoard
    {
        public IScoreBoard scoreBoard;

        public ScoreBoard(IScoreBoard scoreBoard)
        {
            this.scoreBoard = scoreBoard;
        }

        public void StartGame(string homeTeamName, string awayTeamName)
        {
            try
            {
                this.scoreBoard.StartGame(homeTeamName, awayTeamName);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void FinishGame(string homeTeamName, string awayTeamName)
        {
            try
            {
                this.scoreBoard.FinishGame(homeTeamName, awayTeamName);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void UpdateScoreGame(string homeTeamName, string awayTeamName, int homeScore, int awayScore)
        {
            try
            {
                this.scoreBoard.UpdateScoreGame(homeTeamName, awayTeamName, homeScore, awayScore);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public List<Game> GetBoard()
        {
            var board = new List<Game>();

            try
            {
                board = this.scoreBoard.GetBoard();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return board;
        }
    }
}
