using System;

namespace SimonSaysConsole
{
    class Help
    {

        private readonly string description = "\rWelcome to the game of Simon Says! In this game, you must repeat the specific pattern of colors " +
                                            "that are shown.\n\nThe computer will show you a series of colours that must be repeated\n" +
                                            $"    The colours are mapped to the keyboard as such in Easy mode: {Game.colorRed} = Red; {Game.colorBlue} = Blue; " +
                                            $"{Game.colorYellow} = Yellow; {Game.colorGreen} = Green\n" +
                                            $"    The colours are mapped to the keyboard as such in Medium/Hard mode: {Game.colorBlue = ConsoleKey.A} = Blue; {Game.colorGreen = ConsoleKey.S} = Green; " +
                                            $"{Game.colorMagenta = ConsoleKey.V} = Magenta; {Game.colorRed = ConsoleKey.D} = Red; " +
                                            $"{Game.colorYellow = ConsoleKey.F} = Yellow; {Game.colorWhite = ConsoleKey.W} = White\n\n" +
                                            $"\nPressing {Game.startGameKey} will start the game!";       

        public void GameDescription()
        {
            Console.Clear();
            Console.Write(description);
        }
    }
}
