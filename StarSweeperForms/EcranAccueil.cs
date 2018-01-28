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
    public partial class EcranAccueil : UserControl
    {
        public EcranAccueil()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EcranNouvellePartie newGame = new EcranNouvellePartie();
            newGame.Dock = DockStyle.Fill;
            (this.Parent as Form1).DisplayScreen(newGame);


        }

        private void button2_Click(object sender, EventArgs e)
        {
            Config newGame = new Config();
            newGame.Dock = DockStyle.Fill;
            (this.Parent as Form1).DisplayScreen(newGame);
        }
    }
}
