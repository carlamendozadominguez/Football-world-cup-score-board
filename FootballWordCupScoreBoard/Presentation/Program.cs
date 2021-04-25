using FootballWordCupScoreBoard.Domain.Models;
using FootballWordCupScoreBoard.Domain.Service;
using FootballWordCupScoreBoard.Intrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using GameRepository = FootballWordCupScoreBoard.Intrastructure.GameRepository;
using ScoreBoard = FootballWordCupScoreBoard.Presentation.ScoreBoard;
using ScoreBoardService = FootballWordCupScoreBoard.Domain.Service.ScoreBoard;

namespace Presentation.FootballWordCupScoreBoard
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            ScoreBoard scoreBoard = SetUp(args);

            int option = 0;
            while (option != 5)
            {
                Console.WriteLine("\n----- FOOTBALL WORD CUP SCORE BOARD -----");
                Console.WriteLine("1. Start Game");
                Console.WriteLine("2. Update Game");
                Console.WriteLine("3. Finish Game");
                Console.WriteLine("4. Get Board");
                Console.WriteLine("5. Exit");
                Console.Write("Choose an option: ");

                try
                {
                    option = int.Parse(Console.ReadLine());

                    switch (option)
                    {
                        case 1:
                            StartGame(scoreBoard);
                            break;

                        case 2:
                            UpdateGame(scoreBoard);
                            break;

                        case 3:
                            FinishGame(scoreBoard);
                            break;

                        case 4:
                            GetBoard(scoreBoard);
                            break;

                        default:
                            Console.WriteLine("Please choose an option between 1 and 5");
                            break;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Option must be a number");
                }
            }
        }

        private static ScoreBoard SetUp(string[] args)
        {
            var host = Host.CreateDefaultBuilder(args)
                                        .ConfigureServices((_, services) =>
                                        services
                                            .AddScoped<IGameRepository, GameRepository>()
                                            .AddScoped<IScoreBoard, ScoreBoardService>()
                                        ).Build();

            var scoreBoard = ActivatorUtilities.CreateInstance<ScoreBoard>(host.Services);
            return scoreBoard;
        }

        private static void GetBoard(ScoreBoard scoreBoard)
        {
            List<Game> board = scoreBoard.GetBoard();
            board.ForEach(game =>
            {
                Console.WriteLine($"\n {game.HomeTeam.Name} - {game.AwayTeam.Name}: {game.Score.Home} - {game.Score.Away}");
            });
        }

        private static void FinishGame(ScoreBoard scoreBoard)
        {
            Console.Write("Home team name:");
            string homeTeamName = Console.ReadLine();
            Console.Write("Away team name:");
            string awayTeamName = Console.ReadLine();
            scoreBoard.FinishGame(homeTeamName, awayTeamName);
        }

        private static void UpdateGame(ScoreBoard scoreBoard)
        {
            Console.Write("Home team name:");
            string homeTeamName = Console.ReadLine();
            Console.Write("Away team name:");
            string awayTeamName = Console.ReadLine();
            Console.Write("Home score:");
            string homeScore = Console.ReadLine();
            Console.Write("Away score:");
            string awayScore = Console.ReadLine();
            scoreBoard.UpdateScoreGame(homeTeamName, awayTeamName, int.Parse(homeScore), int.Parse(awayScore));
        }

        private static void StartGame(ScoreBoard scoreBoard)
        {
            Console.Write("Home team name:");
            string homeTeamName = Console.ReadLine();
            Console.Write("Away team name:");
            string awayTeamName = Console.ReadLine();
            scoreBoard.StartGame(homeTeamName, awayTeamName);
        }
    }
}