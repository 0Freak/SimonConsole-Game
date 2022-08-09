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
                Console.Write($"Colour {index + 1}: ");
                StoreKeyInput(KeyPress());
                Console.Write($"\rColour {index + 1}: {colorPicked}\n");
            }
        }
        
        private void StoreKeyInput(int playerPickedNumber)
        {
            if (playerPickedNumber == 6 && (Game.difficulty == "EASY" || Game.difficulty == "E"))
            {
                Console.WriteLine($" is Not Valid Input. Keys are {Game.keyColorBlue} = Blue, {Game.keyColorGreen} = Green," +
                                  $" {Game.keyColorRed} = Red, {Game.keyColorYellow} = Yellow");
                StoreKeyInput(KeyPress());
            }
            else if (playerPickedNumber == 6 && (Game.difficulty == "MEDIUM" || Game.difficulty == "M"))
            {
                Console.WriteLine($" is Not Valid Input. Keys are {Game.keyColorBlue} = Blue, {Game.keyColorGreen} = Green," +
                                  $" {Game.colorMagenta} = Magenta, {Game.keyColorRed} = Red," +
                                  $" {Game.keyColorYellow} = Yellow");
                StoreKeyInput(KeyPress());
            }
            else if (playerPickedNumber == 6 && (Game.difficulty == "HARD" || Game.difficulty == "H"))
            {
                Console.WriteLine($" is Not Valid Input. Keys are {Game.keyColorBlue} = Blue, {Game.keyColorGreen} = Green," +
                                  $" {Game.colorMagenta} = Magenta, {Game.keyColorRed} = Red," +
                                  $" {Game.keyColorYellow} = Yellow , {Game.colorWhite} = White");
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

            if (Game.difficulty == "EASY" || Game.difficulty == "E")
            {
                switch (playerKeyInput.Key)
                {
                    case ConsoleKey.B:
                        {
                            colorPicked = "BLUE";
                            return 0;
                        }
                    case ConsoleKey.G:
                        {
                            colorPicked = "GREEN";
                            return 1;
                        }
                    case ConsoleKey.R:
                        {
                            colorPicked = "RED";
                            return 2;
                        }
                    case ConsoleKey.Y:
                        {
                            colorPicked = "YELLOW";
                            return 3;
                        }
                    default:
                        {
                            return 6;
                        }
                }
            }
            else if (Game.difficulty == "MEDIUM" || Game.difficulty == "M")
            {
                switch (playerKeyInput.Key)
                {
                    case ConsoleKey.A:
                        {
                            colorPicked = "BLUE";
                            return 0;
                        }
                    case ConsoleKey.S:
                        {
                            colorPicked = "GREEN";
                            return 1;
                        }
                    case ConsoleKey.D:
                        {
                            colorPicked = "RED";
                            return 2;
                        }
                    case ConsoleKey.F:
                        {
                            colorPicked = "YELLOW";
                            return 3;
                        }
                    case ConsoleKey.V:
                        {
                            colorPicked = "MAGENTA";
                            return 4;
                        }
                    default:
                        {
                            return 6;
                        }
                }
            }
            else
            {
                switch (playerKeyInput.Key)
                {
                    case ConsoleKey.A:
                        {
                            colorPicked = "BLUE";
                            return 0;
                        }
                    case ConsoleKey.S:
                        {
                            colorPicked = "GREEN";
                            return 1;
                        }
                    case ConsoleKey.D:
                        {
                            colorPicked = "RED";
                            return 2;
                        }
                    case ConsoleKey.F:
                        {
                            colorPicked = "YELLOW";
                            return 3;
                        }
                    case ConsoleKey.V:
                        {
                            colorPicked = "MAGENTA";
                            return 4;
                        }
                    case ConsoleKey.W:
                        {
                            colorPicked = "WHITE";
                            return 5;
                        }
                    default:
                        {
                            return 6;
                        }
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
