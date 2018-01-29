using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Isima.CSharp.StarSweeper.GameEngine;
using Isima.CSharp.StarSweeper.ConsoleUI;
using StarSweeperForms;
namespace Game
{
    class GameProgram
    {
        public static void Main(string[] args)
        {
            IGame game = new Program();
            game.start();
        }
    }
}
