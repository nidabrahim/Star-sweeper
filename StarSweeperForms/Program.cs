using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Isima.CSharp.StarSweeper.GameEngine;
namespace StarSweeperForms
{
    public class Program : IGame
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
      
        [STAThread]
        public void start()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        public static void Main(string[] args)
        {
           
        }
    }
}
