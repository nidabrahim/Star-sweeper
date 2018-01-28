using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StarSweeperForms
{
    public partial class EcranNouvellePartie : UserControl
    {
        public EcranNouvellePartie()
        {
            InitializeComponent();
        }

        private void CellClick(object sender, EventArgs e)
        {

            Label clickedCell = sender as Label;

            clickedCell.Text = this.tableLayoutPanel1.GetRow(clickedCell) + " " + this.tableLayoutPanel1.GetColumn(clickedCell);

            return;

        }
    }
}
