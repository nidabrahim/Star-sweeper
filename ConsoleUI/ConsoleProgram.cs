using System;
using System.Configuration;

using Isima.CSharp.StarSweeper.GameEngine;

namespace Isima.CSharp.StarSweeper.ConsoleUI
{
    public class ConsoleProgram : IGame
    {
        private static string _exitCode = "exit";
        public static void Main(string[] args)
        {

        }
        public void start()
        {
            GameParameters parameters = new GameParameters();
            
                parameters.MapSize = Convert.ToInt32(ConfigurationManager.AppSettings["MapSize"]);
                parameters.PawnMovementRange = Convert.ToInt32(ConfigurationManager.AppSettings["MovementRange"]);
                parameters.NumberPlayers = Convert.ToInt32(ConfigurationManager.AppSettings["NumberPlayers"]);
                parameters.NumberPawnMvt2 = Convert.ToInt32(ConfigurationManager.AppSettings["NumberPawnMvt2"]);
                parameters.NumberPawnMvt3 = Convert.ToInt32(ConfigurationManager.AppSettings["NumberPawnMvt3"]);
                parameters.NumberPawnMvt4 = Convert.ToInt32(ConfigurationManager.AppSettings["NumberPawnMvt4"]);
                parameters.NumberPawn = Convert.ToInt32(ConfigurationManager.AppSettings["NumberPawnMvt2"])
                            + Convert.ToInt32(ConfigurationManager.AppSettings["NumberPawnMvt3"])
                            + Convert.ToInt32(ConfigurationManager.AppSettings["NumberPawnMvt4"]);
            

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
                //Console.Clear();
                Console.WriteLine("(Type 'exit' to leave the game.)");
                Console.WriteLine();
                currentGame.updatePlayerTour(tourPlayer);
                grid.Draw(tourPlayer);
                Console.WriteLine();
                Console.WriteLine();

                Console.WriteLine("[PLAYER " + (tourPlayer + 1) + "]");
                Console.Write("Enter coordinates to move Pawn" + tour[tourPlayer] + " to: ");
                string input = Console.ReadLine();
                shouldExit = !String.IsNullOrWhiteSpace(input) && input.ToLower() == _exitCode;
                MapCoordinates destination;
                if (!shouldExit && CoordinateConverter.TryParse(input, out destination))
                {

                    MoveResult result = currentGame.MovePawnTo(destination);
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
            while (!shouldExit && !currentGame.CurrentPlayer.isFailed());

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("BRAVO Player " + tourPlayer);
            Console.ReadKey();

        }


    }
}
