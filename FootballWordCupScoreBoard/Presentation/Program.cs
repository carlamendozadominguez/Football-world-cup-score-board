using FootballWordCupScoreBoard.Intrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using GameRepository = FootballWordCupScoreBoard.Intrastructure.GameRepository;
using FootballWordCupScoreBoard.Domain.Service;
using ScoreBoardService = FootballWordCupScoreBoard.Domain.Service.ScoreBoard;
using ScoreBoard = FootballWordCupScoreBoard.Presentation.ScoreBoard;

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
                Console.WriteLine("\n----- FOOTBALL WORD CUP SCORE BOARD -----");
                Console.WriteLine("1. Start Game");
                Console.WriteLine("2. Upload Game");
                Console.WriteLine("3. Finish Game");
                Console.WriteLine("4. Get Board");
                Console.WriteLine("5. Exit");
                Console.Write("Choose an option: ");

                try
                {
                    option = int.Parse(Console.ReadLine());

                    string homeTeamName;
                    string awayTeamName;

                    switch (option)
                    {
                        case 1:
                            Console.Write("Home team name:");
                            homeTeamName = Console.ReadLine();
                            Console.Write("Away team name:");
                            awayTeamName = Console.ReadLine();
                            scoreBoard.StartGame(homeTeamName, awayTeamName);
                            break;
                        case 3:
                            Console.Write("Home team name:");
                            homeTeamName = Console.ReadLine();
                            Console.Write("Away team name:");
                            awayTeamName = Console.ReadLine();
                            scoreBoard.FinishGame(homeTeamName, awayTeamName);
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
    }
}
