using System;

namespace Isima.CSharp.StarSweeper.GameEngine
{
    /// <summary>
    /// Represents a set of cell coordinates on the game map.
    /// </summary>
    public struct MapCoordinates
    {
        private int _x;
        private int _y;

        /// <summary>
        /// Gets the coordinate value along the horizontal axis.
        /// </summary>
        public int X
        {
            get { return _x; }
        }

        /// <summary>
        /// Gets the coordinate value along the vertical axis.
        /// </summary>
        public int Y
        {
            get { return _y; }
        }

        /// <summary>
        /// Creates and initializes a new instance of type <see cref="MapCoordinates">MapCoordinates</see>.
        /// </summary>
        /// <param name="x">Horizontal coordinate.</param>
        /// <param name="y">Vertical coordinate.</param>
        public MapCoordinates(int x, int y)
        {
            _x = x;
            _y = y;
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer hash code.</returns>
        public override int GetHashCode()
        {
            // At this point, we may assume the map will never be 10,000 x 10,000, so this avoids collisions.
            return _x * 10000 + _y;
        }

        /// <summary>
        /// Returns a value indicating whether this instance is equal to the specified object.
        /// </summary>
        /// <param name="obj">Object this instance is compared to.</param>
        /// <returns>True is the specified object is an instance of <see cref="MapCoordinates">MapCoordinates</see> and equals the value of this instance. False otherwise.</returns>
        public override bool Equals(object obj)
        {
            if (obj is MapCoordinates)
            {
                MapCoordinates other = (MapCoordinates)obj;
                return other._x == _x && other._y == _y;
            }
            return false;
        }
    }
}
