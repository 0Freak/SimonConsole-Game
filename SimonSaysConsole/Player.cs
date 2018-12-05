using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimonSaysConsole
{
    class Player
    {

        public static List<int> playerColors;
        private string colorPicked;

        public Player()
        {
            playerColors = new List<int>();
        }

        public void GetInputAndDisplay()
        {
            Console.WriteLine("Input the colours that were seen:\n");
            for (var index = 0; index < Colors.ColorSequence.Count; index++)
            {
                Console.Write("Colour {0}: ", index + 1);
                StoreKeyInput(KeyPress());
                Console.Write($"\rColour {index + 1}: {colorPicked}\n");
            }
        }

        private void StoreKeyInput(int playerPickedNumber)
        {
            if (playerPickedNumber == 4)
            {
                Console.WriteLine(" is Not Valid Input. Keys are G = Green, R = Red, Y = Yellow, B = Blue");
                StoreKeyInput(KeyPress());
            }
            else
            {
                playerColors.Add(playerPickedNumber);
            }
        }

        private int KeyPress()
        {
            var playerKeyInput = Console.ReadKey();

            switch (playerKeyInput.Key)
            {
                case ConsoleKey.G:
                    {
                        colorPicked = "GREEN";
                        return 0;
                    }
                case ConsoleKey.R:
                    {
                        colorPicked = "RED";
                        return 1;
                    }
                case ConsoleKey.Y:
                    {
                        colorPicked = "YELLOW";
                        return 2;
                    }
                case ConsoleKey.B:
                    {
                        colorPicked = "BLUE";
                        return 3;
                    }
                default:
                    {
                        return 4;
                    }
            }
        }

        public bool CheckAnswer() //True if user answer is correct to generated pattern otherwise returns false and goto a gameover screen
        {
            for (int colorIndex = 0; colorIndex < Colors.ColorSequence.Count; colorIndex++)
            {
                //Check answers is looking for the computer colors to match the players colors. If they match return true otherwise false.
                if (Colors.ColorSequence[colorIndex] != playerColors[colorIndex])
                {
                    return false;
                }
            }
            return true;
        }

        public void ClearAnswers()
        {
            playerColors.Clear();
        }

        public void CallHelp()
        {
            Help helpMe = new Help();
            helpMe.GameDescription();
        }
    }
}
