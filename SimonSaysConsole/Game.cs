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

            Console.WriteLine();
            Console.WriteLine("\rEnter Key was pressed");
            StartGame();
        }

        public void StartGame()
        {
            Console.Clear();
            colors.GetColors(choseAmountOfColorsForRound);
            colors.ShowPickedColors();
            Console.ResetColor();
            Console.Clear();

            //Needs to be refactored for show that it is the checkanswer function that is being checked for a boolean value not the players input
            if (player.Input() == true)            {
                player.ClearAnswers();
                NextRound();
            }
            else
            {
                Lose();
            }
        }

        private void NextRound()
        {
            if (currentRound <= maxRounds)
            {
                currentRound++;
                StartGame();
            }
            else if (currentRound > maxRounds)
            {
                Win();
            }
        }

        public void Lose()
        {
            Console.WriteLine("Game Lost");
            Console.WriteLine("Press any button to play again...");
            Console.ReadKey();
            Console.Clear();
            GameOpen();
        }

        public void Win()
        {
            Console.WriteLine($"Round {currentRound} was won");
            Console.ReadKey();
            player.ClearAnswers();
            StartGame();
        }
    }
}