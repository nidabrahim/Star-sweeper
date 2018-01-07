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
        private Pawn[] _pieces;

        public String Pseudo
        {
            get { return _pseudo; }
        }

        public Pawn[] Piece
        {
            get { return _pieces; }
            set { _pieces = value; }
        }

        public Player(String psd)
        {
            _pseudo = psd;
        }
    }
}
