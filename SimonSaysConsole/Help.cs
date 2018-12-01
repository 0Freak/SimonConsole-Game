using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimonSaysConsole
{
    class Help
    {

        private const string description = "\rWelcome to the game of Simon Says! In this game, you must repeat the specific pattern of colors " +
                                            "that are shown.\n\n The computer will show you a series of colours that must be repeated\n" +
                                            "    The colours are mapped to the keyboard as such: R = Red; B = Blue; Y = Yellow; G = Green\n\n" +
                                            "Pressing enter will start the game!";       

        public void GameDescription()
        {
            Console.Clear();
            Console.WriteLine(description);
        }
    }
}
