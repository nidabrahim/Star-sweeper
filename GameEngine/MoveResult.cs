using System;

namespace Isima.CSharp.StarSweeper.GameEngine
{
    /// <summary>
    /// Qualification of a move attempt.
    /// </summary>
    public enum MoveResult
    {
        /// <summary>Cannot be determined.</summary>
        Unknown = 0,

        /// <summary>The move may proceed.</summary>
        OK = 1,

        /// <summary>The move is cancelled.</summary>
        Illegal = 2
    }
}
