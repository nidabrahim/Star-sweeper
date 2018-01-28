using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Isima.CSharp.StarSweeper.GameEngine;


namespace StarSweeperForms
{
    public partial class Cellule : UserControl
    {
        private int _highlight;
        private MapCoordinates _coordinates;
        private int _color;
        private Boolean _selected;
        private int _pawn;
        private Label _label;


        public int Highlight
        {
            get { return _highlight; }
            set { _highlight = value; }
        }

        public MapCoordinates Coordinates
        {
            get { return _coordinates; }
            set { _coordinates = value; }
        }

        public int Color
        {
            get { return _color; }
            set { _color = value; }
        }

        public int Pawn
        {
            get { return _pawn; }
            set { _pawn = value; }
        }

        public Boolean Selected
        {
            get { return _selected; }
            set { _selected = value; }
        }


        public Label Label
        {
            get { return _label; }
            set { _label = value; }
        }


        public Cellule()
        {
            InitializeComponent();
        }

        public Cellule(MapCoordinates coordinates, int index)
        {
            _coordinates = coordinates;
            newLabel(index);
            InitializeComponent();
        }

        private void newLabel(int index)
        {
            _label = new Label();

            _label.AutoSize = true;
            _label.Size = new System.Drawing.Size(99, 89);
            _label.Text = "X";
            _label.TabIndex = index;

        }


    }
}
