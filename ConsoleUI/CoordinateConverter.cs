using System;
using System.Collections;

using Isima.CSharp.StarSweeper.GameEngine;

namespace Isima.CSharp.StarSweeper.ConsoleUI
{
    /// <summary>
    /// Converts input strings to coordinates parts, and coordinates to their output representation. 
    /// </summary>
    public class CoordinateConverter
    {
        private static readonly string[] _xCoordinates = new string[] { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };
        private static readonly string[] _yCoordinates = new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26" };

        /// <summary>
        /// Converts an x-coordinate to its representation.
        /// </summary>
        /// <param name="x">Value to convert.</param>
        /// <returns>Converted value.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if value is not in the {0,25} range.</exception>.
        public static string XToString(int x)
        {
            if (x < 0 || x >= 26) { throw new ArgumentOutOfRangeException("x"); }

            return _xCoordinates[x];
        }

        /// <summary>
        /// Converts an y-coordinate to its representation.
        /// </summary>
        /// <param name="y">Value to convert.</param>
        /// <returns>Converted value.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if value is not in the {0,25} range.</exception>.
        public static string YToString(int y)
        {
            if (y < 0 || y >= 26) { throw new ArgumentOutOfRangeException("y"); }

            return _yCoordinates[y];
        }

        /// <summary>
        /// Converts input for an x-coordinate into its value.
        /// </summary>
        /// <param name="x">Input to be converted.</param>
        /// <returns>Converted value, -1 if the value couldn't be converted.</returns>
        /// <exception cref="ArgumentNullException">Thrown if the input value is empty.</exception>
        public static int StringToX(string x)
        {
            if (String.IsNullOrWhiteSpace(x)) { throw new ArgumentNullException("x"); }

            string xValue = x.ToLower();

            return Array.IndexOf(_xCoordinates, xValue);
        }

        /// <summary>
        /// Converts input for an y-coordinate into its value.
        /// </summary>
        /// <param name="x">Input to be converted.</param>
        /// <returns>Converted value, -1 if the value couldn't be converted.</returns>
        /// <exception cref="ArgumentNullException">Thrown if the input value is empty.</exception>
        public static int StringToY(string y)
        {
            if (String.IsNullOrWhiteSpace(y)) { throw new ArgumentNullException("y"); }

            string yValue = y.ToLower();

            return Array.IndexOf(_yCoordinates, yValue);
        }

        /// <summary>
        /// Converts user input into a set of map coordinates.
        /// </summary>
        /// <param name="input">User input. The first character should represent the x-coordinate.</param>
        /// <param name="coordinates">Converted input.</param>
        /// <returns>True if the conversion was successful, false otherwise.</returns>
        public static bool TryParse(string input, out MapCoordinates coordinates)
        {
            if (!String.IsNullOrWhiteSpace(input) && input.Length >= 2)
            {
                coordinates = new MapCoordinates(StringToX(input[0].ToString()), StringToY(input.Substring(1)));
            }
            else
            {
                coordinates = new MapCoordinates(-1, -1);
            }

            return coordinates.X >= 0 && coordinates.Y >= 0;
        }
    }
}
