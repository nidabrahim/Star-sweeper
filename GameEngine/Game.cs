using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Isima.CSharp.StarSweeper.GameEngine
{
    /// <summary>
    /// Controls the flow of a 'StarSweeper' game.
    /// </summary>
    public class Game
    {
        private readonly GameParameters _parameters;
        private GameMap _map;
        private Pawn[] _pieces;
        private Player _player1;
        private Player _player2;

        /// <summary>
        /// Gets the game map.
        /// </summary>
        public GameMap Map
        {
            get { return _map; }
        }

        /// <summary>
        /// Gets the pawn in play.
        /// </summary>
        public Pawn[] Piece
        {
            get { return _pieces; }
        }

        public Player Player1
        {
            get { return _player1; }
            set { _player1 = value; }
        }

        public Player Player2
        {
            get { return _player2; }
            set { _player2 = value; }
        }


        /// <summary>
        /// Creates and initializes a new instance of type <see cref="Game">Game</see>.
        /// </summary>
        /// <param name="parameters">Game set up parameters. If not provided, GameParameters.Default are used instead.</param>
        public Game(GameParameters parameters)
        {
            _parameters = parameters ?? GameParameters.Default;
            SetUp();
        }

        public MoveResult MovePawnTo(MapCoordinates destination, int iplayer, int indice)
        {
            if(iplayer == 0) { _pieces = _player1.Piece; }
            else { _pieces = _player2.Piece; }

            Pawn _piece = _pieces[indice];
            

            // Checking map bounds
            if (destination.X < 0 || destination.X > _parameters.MapSize || destination.Y < 0 || destination.Y > _parameters.MapSize)
            {
                return MoveResult.Illegal;
            }

            // Checking range
            if (Pawn.GetDistanceBetween(_piece.Location, destination) > _piece.Movement)
            {
                return MoveResult.Illegal;
            }

            
            if (!isAvailable(destination))
                return MoveResult.Illegal;


            // Perform move
            _map.Sectors[_piece.Location.X, _piece.Location.Y].GamePiece = null;
            _piece.Location = destination;
            _map.Sectors[_piece.Location.X, _piece.Location.Y].GamePiece = _piece;

            return MoveResult.OK;
        }

        private Boolean isAvailable(MapCoordinates destination)
        {
            int j = 0;
            while (j < _parameters.NumberPawn
                   && (_pieces[j].Location.X != destination.X
                   || _pieces[j].Location.Y != destination.Y)) j++;

            if (j != _parameters.NumberPawn)
                return false;
            else return true;
        }

        private void SetUp()
        {
            _map = new GameMap(_parameters.MapSize);
            _player1 = new Player("Youssef");

            _pieces = new Pawn[_parameters.NumberPawn];
 
            int i = 0;
            for (int j = 0; i < _parameters.NumberPawnMvt2; i++,j++)
            {
                _pieces[i] = new Pawn(2);
                MapCoordinates initialLocation = new MapCoordinates(i,0);
                _pieces[i].Location = initialLocation;
                _map.Sectors[initialLocation.X, initialLocation.Y].GamePiece = _pieces[i];
                _map.Sectors[initialLocation.X, initialLocation.Y].GamePiece.Id = i;
            }
            for (int j = 0; j < _parameters.NumberPawnMvt3; i++,j++)
            {
                _pieces[i] = new Pawn(3);
                MapCoordinates initialLocation = new MapCoordinates(i, 0);
                _pieces[i].Location = initialLocation;
                _map.Sectors[initialLocation.X, initialLocation.Y].GamePiece = _pieces[i];
                _map.Sectors[initialLocation.X, initialLocation.Y].GamePiece.Id = i;
            }
            for (int j = 0; j < _parameters.NumberPawnMvt4; i++,j++)
            {
                _pieces[i] = new Pawn(4);
                MapCoordinates initialLocation = new MapCoordinates(i, 0);
                _pieces[i].Location = initialLocation;
                _map.Sectors[initialLocation.X, initialLocation.Y].GamePiece = _pieces[i];
                _map.Sectors[initialLocation.X, initialLocation.Y].GamePiece.Id = i;
            }

            _player1.Piece = _pieces;

            _player2 = new Player("Nida");

            _player2.Piece = new Pawn[_parameters.NumberPawn];

            i = 0;
            for (int j = 0; i < _parameters.NumberPawnMvt2; i++, j++)
            {
                _player2.Piece[i] = new Pawn(2);
                MapCoordinates initialLocation = new MapCoordinates(i, _parameters.MapSize - 1);
                _player2.Piece[i].Location = initialLocation;
                _map.Sectors[initialLocation.X, initialLocation.Y].GamePiece = _player2.Piece[i];
                _map.Sectors[initialLocation.X, initialLocation.Y].GamePiece.Id = i;
            }
            for (int j = 0; j < _parameters.NumberPawnMvt3; i++, j++)
            {
                _player2.Piece[i] = new Pawn(3);
                MapCoordinates initialLocation = new MapCoordinates(i, _parameters.MapSize - 1);
                _player2.Piece[i].Location = initialLocation;
                _map.Sectors[initialLocation.X, initialLocation.Y].GamePiece = _player2.Piece[i];
                _map.Sectors[initialLocation.X, initialLocation.Y].GamePiece.Id = i;
            }
            for (int j = 0; j < _parameters.NumberPawnMvt4; i++, j++)
            {
                _player2.Piece[i] = new Pawn(4);
                MapCoordinates initialLocation = new MapCoordinates(i, _parameters.MapSize - 1);
                _player2.Piece[i].Location = initialLocation;
                _map.Sectors[initialLocation.X, initialLocation.Y].GamePiece = _player2.Piece[i];
                _map.Sectors[initialLocation.X, initialLocation.Y].GamePiece.Id = i;
            }

           
        }
    }
}
