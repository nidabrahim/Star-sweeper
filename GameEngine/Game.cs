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
        private Player _currentPlayer;
        private Player _opponentPlayer;
        private Pawn _xPawn;
        private int _indicePlayer;

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
        /*   public Pawn[] Piece
           {
               get { return _pieces; }
           }

           public Pawn[] PieceAdverce
           {
               get { return _piecesAdverce; }
           }*/

        public Player CurrentPlayer
        {
            get { return _currentPlayer; }
            set { _currentPlayer = value; }
        }

        public Pawn XPawn
        {
            get { return _xPawn; }
            set { _xPawn = value; }
        }

        public int IndicePlayer
        {
            get { return _indicePlayer; }
            set { _indicePlayer = value; }
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

        public void updatePlayerTour(int iplayer)
        {
            IndicePlayer = iplayer;
            if (iplayer == 0)
            {
                _currentPlayer = _player1;
                _opponentPlayer = _player2;
            }
            else
            {
                _currentPlayer = _player2;
                _opponentPlayer = _player1;
            }
        }

        public MoveResult MovePawnTo(MapCoordinates destination)
        {

            Pawn _piece = _currentPlayer.getCurrentPawn();


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


            /*if (!isAvailable(destination))
                return MoveResult.Illegal;*/


            // Perform move
            _map.Sectors[_piece.Location.X, _piece.Location.Y].GamePiece = null;
            _piece.Location = destination;
            _map.Sectors[_piece.Location.X, _piece.Location.Y].GamePiece = _piece;


            capturerPiece(_piece);

            return MoveResult.OK;
        }

        private void capturerPiece(Pawn currentPiece)
        {
            int nbO = countNeighbor(CurrentPlayer,CurrentPlayer.getCurrentPawn());
            int nbX = countNeighborOp(CurrentPlayer.getCurrentPawn(), IndicePlayer);

            CurrentPlayer.resetVisitedToFalse();
            _opponentPlayer.resetVisitedToFalse();

            Console.WriteLine(nbO);
            Console.WriteLine(nbX);
            if (nbX != 0)
            {
                if (nbO < nbX)
                {
                    _map.Sectors[currentPiece.Location.X, currentPiece.Location.Y].GamePiece = null;
                    _currentPlayer.removePawn(currentPiece);
                }else if (nbX < nbO)
                {
                    _map.Sectors[XPawn.Location.X, XPawn.Location.Y].GamePiece = null;
                    _opponentPlayer.removePawn(XPawn);//probleme
                    _currentPlayer.updateIndice();
                }
                else if (nbX == nbO)
                {
                    _map.Sectors[currentPiece.Location.X, currentPiece.Location.Y].GamePiece = null;
                    _currentPlayer.removePawn(currentPiece);

                    _map.Sectors[XPawn.Location.X, XPawn.Location.Y].GamePiece = null;
                    _opponentPlayer.removePawn(XPawn);//probleme
                }
                
            }
            else
            {
                _currentPlayer.updateIndice();
            }

            Console.WriteLine("player 1 : "+Player1.Piece.Count);
            Console.WriteLine("player 2 : " + Player2.Piece.Count);
        }

        private int countNeighbor(Player player, Pawn initPiece)
        {

           Boolean continu = false;
           int nbrO = 0;
            int k = 1;

            for (int i = 0; i < player.Piece.Count; i++)
           {

               if (!player.Piece[i].IsVisited && player.Piece[i] != initPiece && isVoisin(initPiece, player.Piece[i]))
               {

                   nbrO++;
                   player.Piece[i].IsVisited = true;

               }
           }

           do
           {
               continu = false;
               for (int j = 0; j < player.Piece.Count; j++)
                   if (player.Piece[j].IsVisited)
                   {
                       k = 0;
                       for (int i = 0; i < player.Piece.Count; i++)
                       {

                           if (!player.Piece[i].IsVisited && player.Piece[i] != player.Piece[j] && isVoisin(player.Piece[j], player.Piece[i]))
                           {

                               nbrO++;
                                player.Piece[i].IsVisited = true;
                               continu = true;
                           }
                       }
                   }

           } while (continu);


          
            foreach (Pawn p in player.Piece)
            {
                if (p.IsVisited) k++;
            }

            return k;
        }

        private int countNeighborOp(Pawn piece, int iPlayer)
        {
            int nbrX = 0;
            XPawn = _opponentPlayer.isAdjacent(piece, iPlayer);

            if (XPawn != null) nbrX = countNeighbor(_opponentPlayer, XPawn);

            return nbrX;
        }

        private Boolean isVoisin(Pawn currentPiece, Pawn piece)
        {

            return (piece.equals(currentPiece.Location.X - 1, currentPiece.Location.Y - 1)
                        || piece.equals(currentPiece.Location.X + 1, currentPiece.Location.Y + 1)
                    || piece.equals(currentPiece.Location.X - 1, currentPiece.Location.Y)
                    || piece.equals(currentPiece.Location.X - 1, currentPiece.Location.Y + 1)
                    || piece.equals(currentPiece.Location.X + 1, currentPiece.Location.Y)
                    || piece.equals(currentPiece.Location.X + 1, currentPiece.Location.Y - 1)
                    || piece.equals(currentPiece.Location.X, currentPiece.Location.Y - 1)
                    || piece.equals(currentPiece.Location.X, currentPiece.Location.Y + 1)
                    );


        }



        private Boolean isAvailable(MapCoordinates destination)
        {
            int j = 0;
            while (j < _currentPlayer.Piece.Count
                   && (_currentPlayer.Piece[j].Location.X != destination.X
                   || _currentPlayer.Piece[j].Location.Y != destination.Y)) j++;

            if (j != _parameters.NumberPawn)
                return false;
            else return true;
        }

        private void SetUp()
        {
            _map = new GameMap(_parameters.MapSize);
            _player1 = new Player("Youssef");

            //_pieces = new Pawn[_parameters.NumberPawn];
            _player1.Piece = new List<Pawn>();

            int i = 0;
            for (int j = 0; i < _parameters.NumberPawnMvt2; i++, j++)
            {
                //_player1.Piece[i] = new Pawn(2);
                _player1.Piece.Add(new Pawn(2));
                MapCoordinates initialLocation = new MapCoordinates(i, 0);
                _player1.Piece[i].Location = initialLocation;
                _map.Sectors[initialLocation.X, initialLocation.Y].GamePiece = _player1.Piece[i];
                _map.Sectors[initialLocation.X, initialLocation.Y].GamePiece.Id = i;
            }
            for (int j = 0; j < _parameters.NumberPawnMvt3; i++, j++)
            {
                //_player1.Piece[i] = new Pawn(3);
                _player1.Piece.Add(new Pawn(3));
                MapCoordinates initialLocation = new MapCoordinates(i, 0);
                _player1.Piece[i].Location = initialLocation;
                _map.Sectors[initialLocation.X, initialLocation.Y].GamePiece = _player1.Piece[i];
                _map.Sectors[initialLocation.X, initialLocation.Y].GamePiece.Id = i;
            }
            for (int j = 0; j < _parameters.NumberPawnMvt4; i++, j++)
            {
                //_player1.Piece[i] = new Pawn(4);
                _player1.Piece.Add(new Pawn(4));
                MapCoordinates initialLocation = new MapCoordinates(i, 0);
                _player1.Piece[i].Location = initialLocation;
                _map.Sectors[initialLocation.X, initialLocation.Y].GamePiece = _player1.Piece[i];
                _map.Sectors[initialLocation.X, initialLocation.Y].GamePiece.Id = i;
            }

            //_player1.Piece = _pieces;

            _player2 = new Player("Nida");

            //_player2.Piece = new Pawn[_parameters.NumberPawn];
            _player2.Piece = new List<Pawn>();

            i = 0;
            for (int j = 0; i < _parameters.NumberPawnMvt2; i++, j++)
            {
                //_player2.Piece[i] = new Pawn(2);
                _player2.Piece.Add( new Pawn(2));
                MapCoordinates initialLocation = new MapCoordinates(i, _parameters.MapSize - 1);
                _player2.Piece[i].Location = initialLocation;
                _map.Sectors[initialLocation.X, initialLocation.Y].GamePiece = _player2.Piece[i];
                _map.Sectors[initialLocation.X, initialLocation.Y].GamePiece.Id = i;
            }
            for (int j = 0; j < _parameters.NumberPawnMvt3; i++, j++)
            {
                //_player2.Piece[i] = new Pawn(3);
                _player2.Piece.Add(new Pawn(3));
                MapCoordinates initialLocation = new MapCoordinates(i, _parameters.MapSize - 1);
                _player2.Piece[i].Location = initialLocation;
                _map.Sectors[initialLocation.X, initialLocation.Y].GamePiece = _player2.Piece[i];
                _map.Sectors[initialLocation.X, initialLocation.Y].GamePiece.Id = i;
            }
            for (int j = 0; j < _parameters.NumberPawnMvt4; i++, j++)
            {
                //_player2.Piece[i] = new Pawn(4);
                _player2.Piece.Add(new Pawn(4));
                MapCoordinates initialLocation = new MapCoordinates(i, _parameters.MapSize - 1);
                _player2.Piece[i].Location = initialLocation;
                _map.Sectors[initialLocation.X, initialLocation.Y].GamePiece = _player2.Piece[i];
                _map.Sectors[initialLocation.X, initialLocation.Y].GamePiece.Id = i;
            }


        }
    }
}
