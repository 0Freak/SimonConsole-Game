using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimonSaysConsole
{
    class Help
    {

        private readonly string description = "\rWelcome to the game of Simon Says! In this game, you must repeat the specific pattern of colors " +
                                            "that are shown.\n\nThe computer will show you a series of colours that must be repeated\n" +
                                            //$"    The colours are mapped to the keyboard as such: {Game.colorRed} = Red; {Game.colorBlue} = Blue; {Game.colorYellow} = Yellow; {Game.colorGreen} = Green\n\n" +
                                            $"\nPressing {Game.startGameKey} will start the game!";       

        public void GameDescription()
        {
            Console.Clear();
            Console.WriteLine(description);
        }
    }
}
