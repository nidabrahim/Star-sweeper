using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StarSweeperForms
{
    public partial class Form1 : Form
    {
        private Control _currentScreen;
        private Control _previousScreen;

        public Form1()
        {
            InitializeComponent();

            EcranAccueil newGame = new EcranAccueil();
            newGame.Dock = DockStyle.Fill;

            this.Controls.Add(newGame);
            _currentScreen = newGame;

        }

        public void DisplayScreen(Control screen)
        {
            if (_currentScreen != null)
            {
                this.Controls.Remove(_currentScreen);
                _previousScreen = _currentScreen;
                this.Controls.Remove(_currentScreen);
            }
            this.Controls.Add(screen);
            _currentScreen = screen;
        }

        public void DisplayPreviousScreen()
        {
            if (_previousScreen != null)
            {
                _currentScreen = _previousScreen;
                this.Controls.Add(_currentScreen);

                _previousScreen = null;
            }
        }
    }
}
