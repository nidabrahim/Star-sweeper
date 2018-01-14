using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Isima.CSharp.StarSweeper.GameEngine
{
    public class Player
    {
        private String _pseudo;
        private List<Pawn> _pieces;
        private int _indice;

        public String Pseudo
        {
            get { return _pseudo; }
        }

        public List<Pawn> Piece
        {
            get { return _pieces; }
            set { _pieces = value; }
        }

        public int Indice
        {
            get { return _indice; }
            set { _indice = value; }
        }

        public Player(String psd)
        {
            _pseudo = psd;
            _indice = 0;
        }

        public void removePawn(Pawn pawn)
        {
            if (Indice < Piece.IndexOf(pawn))
            {
                Indice = (Indice + 1) % (Piece.Count - 1);
            }
            else
            {
                if(Piece.Count > 1) 
                    Indice = Indice % (Piece.Count - 1);
            }
            Piece.Remove(pawn);
            
        }

        public void updateIndice()
        {
            Indice = (Indice + 1) % Piece.Count;
        }

        public Pawn getCurrentPawn()
        {
            return Piece[Indice];
        }

        public void resetVisitedToFalse()
        {
            foreach(Pawn p in Piece){
                p.IsVisited = false;
            }
        }

        public Pawn isAdjacent(Pawn piece, int iPlayer)
        {
            Pawn adPawn = null;
            if (iPlayer == 0)
            {
                foreach (Pawn p in Piece)
                {
                    if (p.equals(piece.Location.X, piece.Location.Y+1)) return p;
                }
                foreach (Pawn p in Piece)
                {
                    if (p.equals(piece.Location.X - 1, piece.Location.Y+1)) return p;
                }
                foreach (Pawn p in Piece)
                {
                    if (p.equals(piece.Location.X + 1, piece.Location.Y + 1)) return p;
                }
            } else
            {
                foreach (Pawn p in Piece)
                {
                    if (p.equals(piece.Location.X, piece.Location.Y - 1)) return p;
                }
                foreach (Pawn p in Piece)
                {
                    if (p.equals(piece.Location.X - 1, piece.Location.Y - 1)) return p;
                }
                foreach (Pawn p in Piece)
                {
                    if (p.equals(piece.Location.X + 1, piece.Location.Y - 1)) return p;
                }
            }
            return adPawn;
        }

        public Boolean isFailed()
        {
            return Piece.Count == 0;
        }
    }
}
