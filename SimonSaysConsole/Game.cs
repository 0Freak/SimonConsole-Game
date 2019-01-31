using System;

namespace SimonSaysConsole
{
    internal class Game
    {
        Colors colors;
        Player player;
        ConsoleWindowSize windowSize;

        private readonly ConsoleKey startGameKey = ConsoleKey.F5;
        private int maxRounds = 1;

        public static string difficulty = "EASY";
        public int currentRound = 1;
        public int choseAmountOfColorsForRound = 1;

        public Game()
        {
            colors = new Colors();
            player = new Player();
            windowSize = new ConsoleWindowSize();
        }


        public void GameOpen()
        {
            windowSize.SetConsoleWindowSizeToScreenSize();
            Console.WriteLine($"Welcome to a game of Simon Says! Please Press the {startGameKey.ToString()} to start or H for help.");

            while (true)
            {
                var key = Console.ReadKey().Key;
                if (key == ConsoleKey.H)
                {
                    player.CallHelp();
                }
                else if (key == startGameKey)
                {
                    //TODO: Put the code into their own functions
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
                            /*******WARNING FOR DIFFICULTY*******/
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Difficulty setting isn't final. Anything other then Easy will work " +
                                "but will may be too difficult.");
                            Console.ResetColor();
                            /***********************************/
                            Console.Write("Difficulty([E]asy/[M]edium/[H]ard): ");
                            var userDifficulty = Console.ReadLine();
                            difficulty = userDifficulty.ToUpper();
                            if (difficulty == "EASY" || difficulty == "E")
                            {
                                Console.WriteLine("Easy difficulty was chosen");
                                break;
                            }
                            else if (difficulty == "MEDIUM" || difficulty == "M")
                            {
                                Console.WriteLine("Medium Difficulty was chosen");
                                break;
                            }
                            else if (difficulty == "HARD" || difficulty == "H")
                            {
                                Console.WriteLine("Hard Difficulty was chosen");
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Please input a difficulty\n");
                                continue;
                            }
                            //Console.ReadKey();
                            //break;
                        }
                        break;
                    }
                    break;
                }
                else
                {
                    Console.WriteLine($"\rWas the {startGameKey.ToString()} pressed?");
                }
            }
            StartGame();
        }

        public void StartGame()
        {
            Console.Clear();
            colors.GetColors(choseAmountOfColorsForRound);
            colors.ShowPickedColors();
            Console.ResetColor();
            Console.Clear();
            player.GetInputAndDisplay();
            CheckAnswers();
        }

        private void NextRound()
        {
            if (currentRound <= maxRounds)
            {
                currentRound++;
                StartGame();
            }
            else if (currentRound >= maxRounds)
            {
                WonRound();
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
            Console.WriteLine("Green = 0; Red = 1; Yellow = 2; Blue = 3\n");
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
            Console.WriteLine($"\nRound {currentRound} was won");
            Console.WriteLine("Press a key to go to the next round!");
            Console.ReadKey();
        }
    }
}