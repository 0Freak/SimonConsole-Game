﻿using System;
using System.Threading;

namespace SimonSaysConsole
{
    internal class Game
    {
        readonly Colors colors;
        readonly Player player;
        readonly Sounds sounds;
        readonly ConsoleWindowSize windowSize;

        private int maxRounds = 1;

        public static readonly ConsoleKey startGameKey = ConsoleKey.F5;
        public static ConsoleKey keyColorBlue = ConsoleKey.B;
        public static ConsoleKey keyColorGreen = ConsoleKey.G;
        public static ConsoleKey colorMagenta = ConsoleKey.M;
        public static ConsoleKey keyColorRed = ConsoleKey.R;
        public static ConsoleKey keyColorYellow = ConsoleKey.Y;
        public static ConsoleKey colorWhite = ConsoleKey.W;

        public static string difficulty = "EASY";
        public int currentRound = 1;
        public int getNextColor = 1;

        public Game()
        {
            colors = new Colors();
            player = new Player();
            sounds = new Sounds();
            windowSize = new ConsoleWindowSize();
        }


        public void GameOpen()
        {
            windowSize.SetConsoleWindowSizeToScreenSize();
            sounds.PlaySong("play");
            Console.WriteLine($"Welcome to a game of Simon Says! Please Press the {startGameKey} to start or H for help.");

            while (true)
            {
                var key = Console.ReadKey().Key;
                if (key == ConsoleKey.H)
                {
                    player.CallHelp();
                }
                else if (key == startGameKey)
                {
                    while (true)
                    {
                        Console.Write("\rHow many rounds would you like to play(Minium 10 Rounds): ");
                        try
                        {
                            var maxiumPlayerRounds = Convert.ToInt32(Console.ReadLine());
                            if (maxiumPlayerRounds < 10)
                            {
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine("It seems that you are below the minimum rounds allowed. Try again!");
                                Console.WriteLine();
                                Console.ResetColor();
                                continue;
                            }
                            else
                            {
                                maxRounds = maxiumPlayerRounds;
                            }
                        }
                        catch (Exception)
                        {

                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("Whoops that wasn't a number...\n");
                            Console.ResetColor();
                            continue;
                        }
                        while (true)
                        {
                            Console.Write("Difficulty([E]asy/[M]edium/[H]ard): ");
                            var userDifficulty = Console.ReadLine();
                            difficulty = userDifficulty.ToUpper();
                            if (difficulty == "EASY" || difficulty == "E")
                            {
                                keyColorBlue = ConsoleKey.B;
                                keyColorGreen = ConsoleKey.G;
                                keyColorRed = ConsoleKey.R;
                                keyColorYellow = ConsoleKey.Y;
                                Console.WriteLine("Easy difficulty was chosen");
                                break;
                            }
                            else if (difficulty == "MEDIUM" || difficulty == "M")
                            {
                                keyColorBlue = ConsoleKey.A;
                                keyColorGreen = ConsoleKey.S;
                                colorMagenta = ConsoleKey.V;
                                keyColorRed = ConsoleKey.D;
                                keyColorYellow = ConsoleKey.F;
                                Console.WriteLine("Medium Difficulty was chosen");
                                break;
                            }
                            else if (difficulty == "HARD" || difficulty == "H")
                            {
                                keyColorBlue = ConsoleKey.A;
                                keyColorGreen = ConsoleKey.S;
                                colorMagenta = ConsoleKey.V;
                                keyColorRed = ConsoleKey.D;
                                keyColorYellow = ConsoleKey.F;
                                colorWhite = ConsoleKey.W;
                                Console.WriteLine("Hard Difficulty was chosen");
                                break;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine("Please input a difficulty\n");
                                Console.ResetColor();
                                continue;
                            }
                        }
                        sounds.PlaySong("stop");
                        break;
                    }
                    break;
                }
                else
                {
                    Console.Write($"\rWas the {startGameKey} pressed?");
                }
            }
            StartGame();
        }

        public void StartGame()
        {
            Console.Clear();
            colors.GetColors(getNextColor);
            colors.ShowPickedColors();
            Console.ResetColor();
            Console.Clear();

            //Ignore any key input until color are done showing.
            while (Console.KeyAvailable)
            {
                Console.ReadKey(true);
            }

            player.GetInputAndDisplay();
            CheckAnswers();
        }

        private void NextRound()
        {
            if (currentRound < maxRounds)
            {
                currentRound++;
                StartGame();
            }
            else if (currentRound >= maxRounds)
            {
                WonGame();
            }
        }

        private void CheckAnswers()
        {
            if (player.CheckAnswer() == true)
            {
                player.ClearAnswers();
                WonRound();
                NextRound();
            }
            else
            {
                Lose();
            }
        }

        public void Lose()
        {
            Console.WriteLine("\nGame Lost\n");
            ShowResults();
            Console.WriteLine("\nPress any button to play again...");
            Console.ReadKey();
            Console.Clear();
            player.ClearAnswers();
            colors.ClearColors();
            currentRound = 1;
            GameOpen();
        }

        public void ShowResults()
        {
            Console.WriteLine("Legend:");
            if (difficulty == "EASY" || difficulty == "E")
            {
                Console.WriteLine("Blue = 0; Green = 1; Red = 2 Yellow = 3;\n");
            }
            else if (difficulty == "MEDIUM" || difficulty == "M")
            {
                Console.WriteLine("Blue = 0; Green = 1; Red = 2; Yellow = 3; Magenta = 4;\n");
            }
            else
            {
                Console.WriteLine("Blue = 0; Green = 1; Red = 2; Yellow = 3; Magenta = 4; White = 5\n");
            }
            Console.WriteLine("Actual Answers | Your Answers");
            for (int i = 0; i < Colors.ColorSequence.Count; i++)
            {
                if (Colors.ColorSequence[i] != Player.playerColors[i])
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine($"Color {i + 1}: {Colors.ColorSequence[i]}     | Color {i + 1}: {Player.playerColors[i]} ");
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine($"Color {i + 1}: {Colors.ColorSequence[i]}     | Color {i + 1}: {Player.playerColors[i]} ");
                }
            }
        }

        public void WonRound()
        {
            Console.WriteLine($"\nRound {currentRound} was won.");
            if (currentRound == maxRounds)
            {
                WonGame();
            }
            else
            {
                Console.WriteLine("Press a key to go to the next round!");
                Console.ReadKey();
            }
        }

        public void WonGame()
        {
            Console.Clear();
            Console.WriteLine("Congratulations you have won the game!");
            Console.WriteLine();
            Console.WriteLine($"Press the {ConsoleKey.Enter} key to go back to the main window.");
            while (true)
            {
                var winnersKey = Console.ReadKey().Key;
                if (winnersKey == ConsoleKey.Enter)
                {
                    Console.Clear();
                    player.ClearAnswers();
                    colors.ClearColors();
                    currentRound = 1;
                    GameOpen();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("\rPlease press the Enter key. ");
                    Console.ResetColor();
                }
            }
        }
    }
}