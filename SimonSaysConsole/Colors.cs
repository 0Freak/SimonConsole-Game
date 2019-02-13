using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;

namespace SimonSaysConsole
{
    class Colors
    {

        public static List<int> ColorSequence = new List<int>();

        private Random _colorPicker;

        public Colors()
        {
            _colorPicker = new Random();
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
            int pickedColor;
            if (Game.difficulty == "EASY" || Game.difficulty == "E")
            {
                pickedColor = _colorPicker.Next(0, 4);
                return pickedColor;
            }
            else if (Game.difficulty == "MEDIUM" || Game.difficulty == "M")
            {
                pickedColor = _colorPicker.Next(0, 5);
                return pickedColor;
            }
            else
            {
                pickedColor = _colorPicker.Next(0, 6);
                return pickedColor;
            }
        }

        public void SaveColor()
        {
            ColorSequence.Add(ChoseColor());
        }

        public void ShowPickedColors()
        {
            var sounds = new SoundFx();
            foreach (var color in ColorSequence)
            {
                PauseScreen();
                switch (color)
                {
                    case 0:
                        {
                            sounds.PlaySound("E5.wav");
                            ShowColor(ConsoleColor.Blue);
                            continue;
                        }
                    case 1:
                        {
                            sounds.PlaySound("C6.wav");
                            ShowColor(ConsoleColor.Green);
                            continue;
                        }
                    case 2:
                        {
                            sounds.PlaySound("A5.wav");
                            ShowColor(ConsoleColor.Red);
                            continue;
                        }
                    case 3:
                        {
                            sounds.PlaySound("G5.wav");
                            ShowColor(ConsoleColor.Yellow);
                            continue;
                        }
                    case 4:
                        {
                            sounds.PlaySound("D5.wav");
                            ShowColor(ConsoleColor.Magenta);
                            continue;
                        }
                    case 5:
                        {
                            sounds.PlaySound("C5.wav");
                            ShowColor(ConsoleColor.White);
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
            Thread.Sleep(1000);
        }
    }
}
