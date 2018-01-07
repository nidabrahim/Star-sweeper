using System;

namespace Isima.CSharp.StarSweeper.GameEngine
{
    /// <summary>
    /// Represents a "square".
    /// </summary>
    public class MapSector
    {
        private MapCoordinates _coordinates;

        /// <summary>
        /// Gets the coordinates of the sector on the map.
        /// </summary>
        public MapCoordinates Coordinates
        {
            get { return _coordinates; }
        }

        public Pawn GamePiece { get; set; }

        /// <summary>
        /// Creates and initializes a new instance of type <see cref="MapSector">MapSector</see>.
        /// </summary>
        /// <param name="coordinates">Coordinates of the sector on the map.</param>
        public MapSector(MapCoordinates coordinates)
        {
            _coordinates = coordinates;
        }
    }
}
