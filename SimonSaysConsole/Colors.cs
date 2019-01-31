using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace SimonSaysConsole
{
    class Colors
    {

        public static List<int> ColorSequence = new List<int>();

        private Random colorPicker;

        public Colors()
        {
            colorPicker = new Random();
        }

        public void GetColors(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                SaveColor();
            }
        }

        public int ChoseColor()
        {

            int pickedColor = colorPicker.Next(0, 4);

            return pickedColor;
        }

        public void SaveColor()
        {
            ColorSequence.Add(ChoseColor());
        }

        public void ShowPickedColors()
        {
            foreach (var color in ColorSequence)
            {
                PauseScreen();
                switch (color)
                {
                    case 0:
                        {
                            ShowColor(ConsoleColor.Green);
                            continue;
                        }
                    case 1:
                        {
                            ShowColor(ConsoleColor.Red);
                            continue;
                        }
                    case 2:
                        {
                            ShowColor(ConsoleColor.Yellow);
                            continue;
                        }
                    case 3:
                        {
                            ShowColor(ConsoleColor.Blue);
                            continue;
                        }
                    default:
                        break;
                }
            }
        }

        public void ClearColors()
        {
            ColorSequence.Clear();
        }

        private void PauseScreen()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            Thread.Sleep(750);
        }

        private void ShowColor(ConsoleColor color)
        {
            Console.BackgroundColor = color;
            Console.Clear();
            SleepTime(Game.difficulty, 1000);
        }

        private void SleepTime(string gameDifficulty, int timeInMiliseconds)
        {
            if (gameDifficulty == "EASY" || gameDifficulty == "E")
            {
                Thread.Sleep(timeInMiliseconds);
            }
            else if (gameDifficulty == "MEDIUM" || gameDifficulty == "M")
            {
                Thread.Sleep(timeInMiliseconds / 2);
            }
            else if (gameDifficulty == "HARD" || gameDifficulty == "H")
            {
                Thread.Sleep(timeInMiliseconds / 3);
            }
        }
    }
}
