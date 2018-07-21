using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimonSaysConsole
{
    class Player
    {

        public static List<int> PlayerColors;

        public Player()
        {
            PlayerColors = new List<int>();
        }

        public bool Input()
        {
            for (var index = 0; index < Colors.ColorSequence.Count; index++)
            {
                Console.Write("Color {0}: ", index + 1);
                StoreKeyInput(KeyPress());
            }

            //Debugging Info
            foreach (var color in Colors.ColorSequence)
            {
                Console.Write(" CC {0}", color); //CC = Computers Colors
            }
            Console.WriteLine();
            foreach (var number in PlayerColors)
            {
                Console.Write(" PC {0}", number); //PC = Players Colors
            }

            Console.WriteLine();
            Console.WriteLine("Press a key to continue...");
            Console.ReadKey();
            return CheckAnswer();
        }

        private int KeyPress()
        {
            var playerKeyInput = Console.ReadKey();

            switch (playerKeyInput.Key)
            {
                case ConsoleKey.G:
                    {
                        Console.WriteLine("\rYou Picked GREEN");
                        return 0;
                    }
                case ConsoleKey.R:
                    {
                        Console.WriteLine("\rYou Picked RED");
                        return 1;
                    }
                case ConsoleKey.Y:
                    {
                        Console.WriteLine("\rYou Picked YELLOW");
                        return 2;
                    }
                case ConsoleKey.B:
                    {
                        Console.WriteLine("\rYou Picked BLUE");
                        return 3;
                    }
                default:
                    {
                        return 4;
                    }
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
                PlayerColors.Add(playerPickedNumber);
            }
        }

        public bool CheckAnswer() //True if user answer is correct to generated pattern otherwise returns false and goto a gameover screen
        {

            for (int colorIndex = 0; colorIndex < Colors.ColorSequence.Count; colorIndex++)
            {
                //Check answers is looking for any Color number in the players colors
                //In theory the Player can input the correct color numbers without having to 
                //get the pattern right.
                if (!Colors.ColorSequence.Contains(PlayerColors[colorIndex]))
                {
                    Console.WriteLine("You picked {0}", PlayerColors[colorIndex]);
                    Console.WriteLine("Computer picked color {0}", Colors.ColorSequence[colorIndex]);
                    return false;
                }
                else
                {
                    Console.WriteLine("You picked {0}", PlayerColors[colorIndex]);
                    Console.WriteLine("Computer picked color {0}", Colors.ColorSequence[colorIndex]);
                    continue;
                }
            }
            return true;
        }

        public void ClearAnswers() //Remove all user answers from the list
        {
            for (int i = 0; i <= PlayerColors.Count; i++)
            {
                PlayerColors.Remove(i);
            }
        }

        public void CallHelp()
        {
            Help helpMe = new Help();
            helpMe.GameDescription();
        }
    }
}
