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
    public partial class Grille : UserControl
    {

        private Cellule[,] _cellules;
        private int _size;
        private TableLayoutPanel tableLayoutPanel;

        public Cellule[,] Cellules
        {
            get { return _cellules; }
        }

        public int Length
        {
            get { return _size; }
        }

        public Grille()
        {
            InitializeComponent();
            drawGrille();
            InitializeCells();
        }

        private void InitializeCells()
        {
            int k = 0;
            for (int x = 0; x < Length; x++)
            {
                for (int y = 0; y < Length; y++)
                {
                    Cellules[x, y] = new Cellule(new MapCoordinates(x, y), k);
                    add(Cellules[x, y], x, y);
                    k++;
                }
            }
        }

        private void add(Cellule cell, int x, int y)
        {
            tableLayoutPanel.Controls.Add(cell, x, y);
        }

        private void drawGrille()
        {
            this.tableLayoutPanel.ColumnCount = Length;
            this.tableLayoutPanel.RowCount = Length;

            for (int i = 0; i < Length; i++)
            {
                this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
                this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            }

            this.tableLayoutPanel.Size = new System.Drawing.Size(430, 363);
        }

    }
}
