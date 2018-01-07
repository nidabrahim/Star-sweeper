using System;

namespace Isima.CSharp.StarSweeper.GameEngine
{
    /// <summary>
    /// Represents the game 'board'.
    /// </summary>
    public class GameMap
    {
        private readonly MapSector[,] _sectors;
        private readonly int _size;

        /// <summary>
        /// Gets the collection of squares of the map, as a two-dimensional array.
        /// </summary>
        public MapSector[,] Sectors
        {
            get { return _sectors; }
        }

        /// <summary>
        /// Gets the size (length = width) of the map.
        /// </summary>
        public int Size
        {
            get { return _size; }
        }

        /// <summary>
        /// Creates and initializes a new instance of type <see cref="GameMap">GameMap</see>.
        /// </summary>
        /// <param name="size">Length and width of the map.</param>
        public GameMap(int size)
        {
            _size = size;
            _sectors = new MapSector[size, size];

            InitializeSectors();
        }

        private void InitializeSectors()
        {
            for (int x = 0; x < _size; x++)
            {
                for (int y = 0; y < _size; y++)
                {
                    _sectors[x, y] = new MapSector(new MapCoordinates(x, y));
                }
            }
        }
    }
}
