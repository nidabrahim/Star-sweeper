using System;
using System.Collections.Generic;
using System.Text;

using Isima.CSharp.StarSweeper.GameEngine;

namespace Isima.CSharp.StarSweeper.ConsoleUI
{
    /// <summary>
    /// Text representation of the game map.
    /// </summary>
    public class GameGrid
    {
        public static readonly string PawnToken = "O";
        public static readonly string EmptyCellToken = ".";
        public static readonly string ReachableCellToken = "x";

        private string _headerRow;
        private Game _gameState;

        /// <summary>
        /// Gets the map to be represented.
        /// </summary>
        public Game GameState
        {
            get { return _gameState; }
            set
            {
                _gameState = value;
                SetHeaderRow();
            }
        }

        /// <summary>
        /// Draws the map to the console.
        /// </summary>
        /// <exception cref="InvalidOperationException">Thrown if the map wasn't initialized.</exception>
        public void Draw(int iPlayer)
        {
            if (_gameState.Map == null) { throw new InvalidOperationException("Map needs to be initialized."); }

            Pawn p = _gameState.CurrentPlayer.getCurrentPawn();
            Console.WriteLine("Location : " + CoordinateConverter.XToString(p.Location.X) + CoordinateConverter.YToString(p.Location.Y));


            Console.WriteLine(_headerRow);

            List<MapCoordinates> reachableSectors = Pawn.GetReachableCoordinatesFor(p);

            for (int y = 0; y < _gameState.Map.Size; y++)
                {
                    string row = CoordinateConverter.YToString(y).PadRight(3, ' ');
                    row += GetGridRowRepresentation(_gameState.Map, y, reachableSectors);
                    row += CoordinateConverter.YToString(y).PadLeft(3, ' ');
                    Console.WriteLine(row);
                }
           
            Console.WriteLine(_headerRow);
        }

        /*public void Draw()
         {
             if (_gameState?.Map == null) { throw new InvalidOperationException("Map needs to be initialized."); }

             Console.WriteLine(_headerRow);
             foreach (Pawn p in _gameState.Piece)
             {
                 List<MapCoordinates> reachableSectors = Pawn.GetReachableCoordinatesFor(p);          

                 for (int y = 0; y < _gameState.Map.Size; y++)
                     {
                         string row = CoordinateConverter.YToString(y).PadRight(3, ' ');
                         row += GetGridRowRepresentation(_gameState.Map, y, reachableSectors);
                         row += CoordinateConverter.YToString(y).PadLeft(3, ' ');
                         Console.WriteLine(row);
                     }
             }
             Console.WriteLine(_headerRow);
         }*/


        /*private string GetGridRowRepresentation(GameMap map, int rowIndex)
        {
            if (map == null) { throw new ArgumentNullException("map"); }

            StringBuilder builder = new StringBuilder();
            for (int x = 0; x < map.Size; x++)
            {
                builder.Append(GetSectorRepresentation(map.Sectors[x, rowIndex]));
                builder.Append(" ");
            }

            return builder.ToString();
        }*/

        private string GetGridRowRepresentation(GameMap map, int rowIndex, List<MapCoordinates> reachableSectors)
        {
            if (map == null) { throw new ArgumentNullException("map"); }

            StringBuilder builder = new StringBuilder();
            for (int x = 0; x < map.Size; x++)
            {
                builder.Append(GetSectorRepresentation(map.Sectors[x, rowIndex], reachableSectors));
                builder.Append(" ");
            }

            return builder.ToString();
        }


        /*private string GetSectorRepresentation(MapSector sector)
        {
            if (sector == null) { throw new ArgumentNullException("sector"); }

            if (sector.GamePiece != null)
            {
                return PawnToken;
            }
            else
            {
                return EmptyCellToken;
            }
        }*/

        private string GetSectorRepresentation(MapSector sector, List<MapCoordinates> reachableSectors)
        {
            if (sector == null) { throw new ArgumentNullException("sector"); }

            if (sector.GamePiece != null)
            {
                return ""+sector.GamePiece.Id;
            }
            else if (reachableSectors != null && reachableSectors.Contains(sector.Coordinates))
            {
                return ReachableCellToken;
            }
            else
            {
                return EmptyCellToken;
            }
        }

        private void SetHeaderRow()
        {
            if (_gameState.Map == null) { throw new InvalidOperationException("Map needs to be initialized."); }

            StringBuilder builder = new StringBuilder();
            builder.Append("   ");
            for (int i = 0; i < _gameState.Map.Size; i++)
            {
                builder.Append(CoordinateConverter.XToString(i));
                builder.Append(" ");
            }

            _headerRow = builder.ToString();
        }
    }
}
