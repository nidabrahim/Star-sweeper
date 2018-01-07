using System;

namespace Isima.CSharp.StarSweeper.GameEngine
{
    /// <summary>
    /// Parameters used to set up a game.
    /// </summary>
    public class GameParameters
    {
        /// <summary>
        /// Gets or sets the map size (size = length = width).
        /// </summary>
        public int MapSize { get; set; }

        /// <summary>
        /// Gets or sets the number of squares pawns can move with a single action.
        /// </summary>
        public int PawnMovementRange { get; set; }

        public int NumberPlayers { get; set; }

        public int NumberPawn { get; set; }

        public int NumberPawnMvt2 { get; set; }

        public int NumberPawnMvt3 { get; set; }

        public int NumberPawnMvt4 { get; set; }

        

        public static GameParameters Default { get; } = new GameParameters
                                                            {   MapSize = 10,
                                                                PawnMovementRange = 2,
                                                                NumberPlayers = 1,
                                                                NumberPawnMvt2 = 1,
                                                                NumberPawnMvt3 = 0,
                                                                NumberPawnMvt4 = 0,
                                                                NumberPawn = 1
                                                             };

        
    }
}
