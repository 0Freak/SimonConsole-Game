using System;

namespace SimonSaysConsole
{
    internal class Game
    {
        Colors colors;
        Player player;

        private readonly ConsoleKey startGameKey = ConsoleKey.Enter;
        private const int maxRounds = 10;

        public int currentRound = 1;
        public int choseAmountOfColorsForRound = 1;

        public Game()
        {
            colors = new Colors();
            player = new Player();
        }
        

        public void GameOpen()
        {
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
            Console.WriteLine("Game Lost");
            Console.WriteLine("Press any button to play again...");
            Console.ReadKey();
            Console.Clear();
            player.ClearAnswers();
            colors.ClearColors();
            GameOpen();
        }

        public void WonRound()
        {
            Console.WriteLine($"\nRound {currentRound} was won");
            Console.WriteLine("Press a key to go to the next round!");
            Console.ReadKey();
        }
    }
}