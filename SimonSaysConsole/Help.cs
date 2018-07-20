using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimonSaysConsole
{
    class Help
    {

        private enum HelpCommands
        {
        
        }

        public void GameDescription()
        {
            string description = "\rWelcome to the game of Simon Says! In this game, you must repeat the specific pattern of colors " +
                "that are shown.";
            Console.WriteLine(description);
        }
    }
}
