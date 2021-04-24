using FootballWordCupScoreBoard.Domain.Service;
using System;

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
    }
}
