using System;

namespace SimonSaysConsole
{
    class Help
    {

        private readonly string description = "\rWelcome to the game of Simon Says! In this game, you must repeat the specific pattern of colors " +
                                            "that are shown.\n\nThe computer will show you a series of colours that must be repeated\n" +
                                            $"    The colours are mapped to the keyboard as such in Easy mode: {Game.keyColorRed} = Red; {Game.keyColorBlue} = Blue; " +
                                            $"{Game.keyColorYellow} = Yellow; {Game.keyColorGreen} = Green\n" +
                                            $"    The colours are mapped to the keyboard as such in Medium/Hard mode: {Game.keyColorBlue = ConsoleKey.A} = Blue; {Game.keyColorGreen = ConsoleKey.S} = Green; " +
                                            $"{Game.colorMagenta = ConsoleKey.V} = Magenta; {Game.keyColorRed = ConsoleKey.D} = Red; " +
                                            $"{Game.keyColorYellow = ConsoleKey.F} = Yellow; {Game.colorWhite = ConsoleKey.W} = White\n\n" +
                                            $"\nPressing {Game.startGameKey} will start the game!";       

        public void GameDescription()
        {
            Console.Clear();
            Console.Write(description);
        }
    }
}
