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
    public partial class Config : UserControl
    {
        public Config()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            (this.Parent as Form1).DisplayPreviousScreen();
        }
    }
}
