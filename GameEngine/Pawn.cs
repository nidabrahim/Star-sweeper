using System;
using System.Collections.Generic;

namespace Isima.CSharp.StarSweeper.GameEngine
{
    /// <summary>
    /// Basic playing piece.
    /// </summary>
    public class Pawn
    {
        private int _id;
        private Boolean _isVisited;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public Boolean IsVisited
        {
            get { return _isVisited; }
            set { _isVisited = value; }
        }

        private int _movement;

        /// <summary>
        /// Gets the number of squares the pawn can move by combining horizontal and vertical moves.
        /// </summary>
        public int Movement
        {
            get { return _movement; }
            set { _movement = value; }
        }

        /// <summary>
        /// Gets or sets the current location of the pawn on the map.
        /// </summary>
        public MapCoordinates Location { get; set; }

        /// <summary>
        /// Creates and initializes a new instance of type <see cref="Pawn">Pawn</see>.
        /// </summary>
        /// <param name="movement">Number of squares the pawn can move.</param>
        public Pawn(int movement)
        {
            _movement = movement;
            IsVisited = false;
        }

        /// <summary>
        /// Calculates the movement points necessary for this pawn to move from cellA to cellB.
        /// </summary>
        /// <param name="cellA">Point of origin.</param>
        /// <param name="cellB">Destination.</param>
        /// <returns>Movement points needed.</returns>
        public static int GetDistanceBetween(MapCoordinates cellA, MapCoordinates cellB)
        {
            int distance = cellA.X >= cellB.X ? cellA.X - cellB.X : cellB.X - cellA.X;
            distance += cellA.Y >= cellB.Y ? cellA.Y - cellB.Y : cellB.Y - cellA.Y;

            return distance;
        }

        /// <summary>
        /// Gets all the map coordinates reachable by a given pawn.
        /// Note that map bounds are NOT checked.
        /// </summary>
        /// <param name="piece">Pawn for which possible moves are calculated.</param>
        /// <returns>Reachable map coordinates. Empty if no result.</returns>
        /// <exception cref="ArgumentNullException">Thrown if parameter 'piece' is null.</exception>.
        public static List<MapCoordinates> GetReachableCoordinatesFor(Pawn piece)
        {
            if (piece == null) { throw new ArgumentNullException("piece"); }

            var results = new List<MapCoordinates>();

            for (int x = piece.Location.X - piece.Movement; x <= piece.Location.X + piece.Movement; x++)
            {
                for (int y = piece.Location.Y - piece.Movement; y <= piece.Location.Y + piece.Movement; y++)
                {
                    MapCoordinates target = new MapCoordinates(x, y);
                    if (GetDistanceBetween(piece.Location, target) <= piece.Movement)
                    {
                        results.Add(target);
                    }
                }
            }

            return results;
        }

        public Boolean equals(int x, int y)
        {

            return (this.Location.X == x) && (this.Location.Y == y);
        }
    }
}
