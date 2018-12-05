using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimonSaysConsole
{
    class ConsoleWindowSize
    {
        public void SetConsoleWindowSizeToScreenSize()
        {
            var largestWindowX = Console.LargestWindowWidth;
            var largestWindowY = Console.LargestWindowHeight;

            //Set Console window size to screen size
            if (largestWindowX >= 200 && largestWindowY >= 62)
            {
                Console.SetWindowSize(200, 50);
            }
            else if (largestWindowX >= 160 && largestWindowY >= 43)
            {
                Console.SetWindowSize(130, 40);
            }
            else if (largestWindowX >= 128 && largestWindowY >= 46)
            {
                Console.SetWindowSize(110, 10);
            }
            else
            {
                Console.SetWindowSize(80, 17);
            }
        }
    }
}
