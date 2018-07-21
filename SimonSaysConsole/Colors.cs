using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimonSaysConsole
{
    class Colors
    {

        public static List<int> ColorSequence = new List<int>();
        Random colorPicker;

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
                //Allow a black screen in between each color
                for (int j = 0; j < 100; j++)
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.Clear();
                }

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
                            ShowColor(ConsoleColor.DarkYellow);
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

        private void ShowColor(ConsoleColor color)
        {
            int length = 200;

            for (int i = 0; i < length; i++)
            {
                Console.BackgroundColor = color;
                Console.Clear();
            }
        }

    }
}
