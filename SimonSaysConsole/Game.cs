using System;

namespace SimonSaysConsole
{
    internal class Game
    {
        Colors colors;
        Player player;

        private readonly ConsoleKey StartGameKey = ConsoleKey.Enter;
        private const int MaxRounds = 10;

        public int Round = 1;
        public int ChoseAmountOfColorsForRound = 1;

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
                else if (key == StartGameKey)
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
            colors.GetColors(ChoseAmountOfColorsForRound); //Start game with two colors and then add one color each round/level 
            colors.ShowPickedColors();
            Console.ResetColor();
            Console.Clear();

            if (player.Input() == true)
            {
                NextRound();
            }
            else
            {
                Console.ReadKey();
            }
        }

        private void NextRound()
        {
            if (Round <= MaxRounds)
            {
                Round++;
                StartGame();
            }
            else if (Round > MaxRounds)
            {
                Win();
            }
        }

        public void Lose()
        {
            Console.WriteLine("Game Lost");
            throw new NotImplementedException();
        }

        public void Win()
        {
            Console.WriteLine("Round {0} was won", Round);
            Console.ReadKey();
            player.ClearAnswers();
            StartGame();
        }
    }
}