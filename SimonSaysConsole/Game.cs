using System;

namespace SimonSaysConsole
{
    internal class Game
    {
        Colors colors;
        Player player;
        ConsoleWindowSize windowSize;

        private readonly ConsoleKey startGameKey = ConsoleKey.Enter;
        private const int maxRounds = 10;

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
            Console.WriteLine("Welcome to a game of Simon Says! Please Press the Enter Key to start or H for help.");
            
            while (true)
            {
                var key = Console.ReadKey().Key;
                if (key == ConsoleKey.H)
                {
                    player.CallHelp();
                }
                else if (key == startGameKey)
                {
                    break;
                }
                else
                {
                    Console.Write("\rWas the Enter key pressed?");
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