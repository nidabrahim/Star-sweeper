using System;
using System.Configuration;

using Isima.CSharp.StarSweeper.GameEngine;

namespace Isima.CSharp.StarSweeper.ConsoleUI
{
    public class Program
    {
        private static string _exitCode = "exit";

        public static void Main(string[] args)
        {
            GameParameters parameters = new GameParameters
            {
                MapSize = Convert.ToInt32(ConfigurationManager.AppSettings["MapSize"]),
                PawnMovementRange = Convert.ToInt32(ConfigurationManager.AppSettings["MovementRange"]),
                NumberPlayers = Convert.ToInt32(ConfigurationManager.AppSettings["NumberPlayers"]),
                NumberPawnMvt2 = Convert.ToInt32(ConfigurationManager.AppSettings["NumberPawnMvt2"]),
                NumberPawnMvt3 = Convert.ToInt32(ConfigurationManager.AppSettings["NumberPawnMvt3"]),
                NumberPawnMvt4 = Convert.ToInt32(ConfigurationManager.AppSettings["NumberPawnMvt4"]),
                NumberPawn = Convert.ToInt32(ConfigurationManager.AppSettings["NumberPawnMvt2"]) 
                            + Convert.ToInt32(ConfigurationManager.AppSettings["NumberPawnMvt3"]) 
                            + Convert.ToInt32(ConfigurationManager.AppSettings["NumberPawnMvt4"])
            };

            if (parameters.MapSize > 26 || parameters.PawnMovementRange < 1)
            {
                parameters = GameParameters.Default;
            }

            Game currentGame = new Game(parameters);
            GameGrid grid = new GameGrid { GameState = currentGame };

            bool shouldExit = false;
            int tourPlayer = 0;
            int[] tour = new int[2];
            tour[0] = 0;
            tour[1] = 0;
            do
            {
                Console.Clear();
                Console.WriteLine("(Type 'exit' to leave the game.)");
                Console.WriteLine();
                grid.Draw(tourPlayer, tour[tourPlayer]);
                Console.WriteLine();
                Console.WriteLine();

                Console.WriteLine("[PLAYER " + (tourPlayer+1) + "]");
                Console.Write("Enter coordinates to move Pawn"+ tour[tourPlayer] + " to: ");
                string input = Console.ReadLine();
                shouldExit = !String.IsNullOrWhiteSpace(input) && input.ToLower() == _exitCode;

                 if (!shouldExit && CoordinateConverter.TryParse(input, out MapCoordinates destination))
                {
              
                    MoveResult result = currentGame.MovePawnTo(destination, tourPlayer, tour[tourPlayer]);
                    switch (result)
                    {
                        case MoveResult.Illegal:
                            Console.WriteLine();
                            Console.WriteLine("Can't move there. Press any key to retry.");
                            Console.ReadKey();
                            break;
                        case MoveResult.OK:
                            tour[tourPlayer] = (tour[tourPlayer] + 1) % 5;
                            tourPlayer = (tourPlayer + 1) % 2;
                            continue;
                        default:
                            Console.WriteLine();
                            Console.WriteLine("Let's not do that again, ok ? Press any key to retry.");
                            Console.ReadKey();
                            break;
                    }
                }
                else
                {
                    if (!shouldExit)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Invalid Input. Press any key to retry.");
                        Console.ReadKey();
                    }
                }
            } 
            while (!shouldExit);
        }
    }
}
