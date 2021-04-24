using FootballWordCuScoreBoard.Domain;
using FootballWordCupScoreBoard.Domain;
using FootballWordCuScoreBoard.Intrastructure;
using FootballWordCuScoreBoard.Presentation;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using GameRepository = FootballWordCuScoreBoard.Intrastructure.GameRepository;
using FootballWordCuScoreBoard.Domain.Service;
using ScoreBoardService = FootballWordCuScoreBoard.Domain.Service.ScoreBoard;
using ScoreBoard = FootballWordCuScoreBoard.Presentation.ScoreBoard;

namespace Presentation.FootballWordCupScoreBoard
{
    class Program
    {
        static void Main(string[] args)
        {
            ScoreBoard scoreBoard = SetUp(args);

            int option = 0;
            while (option != 5)
            {
                Console.WriteLine("----- FOOTBALL WORD CUP SCORE BOARD");
                Console.WriteLine("1. Start Game");
                Console.WriteLine("2. Upload Game");
                Console.WriteLine("3. Finish Game");
                Console.WriteLine("4. Get Board");
                Console.WriteLine("5. Exit");
                Console.WriteLine("Choose an option: ");

                try
                {
                    option = int.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("Option must be a number");
                }

                switch (option)
                {
                    case 1:
                        Console.WriteLine("Home team name:");
                        string homeTeamName = Console.ReadLine();
                        Console.WriteLine("Away team name:");
                        string awayTeamName = Console.ReadLine();
                        scoreBoard.StartGame(homeTeamName, awayTeamName);
                        break;
                    default:
                        Console.WriteLine("Please choose an option between 1 and 5");
                        break;
                }
            }
        }

        private static ScoreBoard SetUp(string[] args)
        {
            var host = Host.CreateDefaultBuilder(args)
                                        .ConfigureServices((_, services) =>
                                        services.AddScoped<IGameRepository, GameRepository>()

                                            .AddScoped<IScoreBoard, ScoreBoardService>()
                                        ).Build();

            var scoreBoard = ActivatorUtilities.CreateInstance<ScoreBoard>(host.Services);
            return scoreBoard;
        }
    }
}
