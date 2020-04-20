using System;
using System.Linq;

namespace MasterMind
{
    class Program
    {
        // The Concepts for this assignment deal with collections learned so far.
        // This program does not use linq, although you can use it. If you do use it, be prepared to explain what it's doing under the mood.
        public static void Main(string[] args)
        {
            string[] userColors = new string[2];
            string[] computerColors = new string[2];
            Console.WriteLine("Please pick two colors. Red, Blue, or Yellow.");
            Console.WriteLine("Enter your guess separated by a space.");

            string answer = Console.ReadLine().ToLower();


            bool isPlaying = false;
            do
            {
                UserGuess(userColors);
                ComputerAnswer(computerColors);
                Compare(userColors, computerColors);

            } while (isPlaying);

        }

        public static void UserGuess(string[] userColors)
        {
            Console.WriteLine("What is your first color.");
            userColors[0] = Console.ReadLine().ToLower().Trim();
            Console.WriteLine("What is your second color");
            userColors[1] = Console.ReadLine().ToLower().Trim();
        }

        public static void ComputerAnswer(string[] computerColors)
        {
            Random random = new Random();
            int first = random.Next(1, 3);
            int second = random.Next(1, 3);


            switch (first)
            {
                case 1:
                    computerColors[0] = "red";
                    break;
                case 2:
                    computerColors[0] = "blue";
                    break;
                case 3:
                    computerColors[0] = "yellow";
                    break;

            }
            switch (second)
            {
                case 1:
                    computerColors[1] = "red";
                    break;
                case 2:
                    computerColors[1] = "blue";
                    break;
                case 3:
                    computerColors[1] = "yellow";
                    break;
            }

        }

        public static void Compare(string[] userColors, string[] computerColors)
        {
            // List are accessible by index but be mindful that Lists also allow for easy removal and addition of items,
            // so the value at a specific index may not be what you expect.

            // In this program, we are only adding to a List and clearing the List between plays, so we can be certain that
            // the item value at a specific index can be trusted\



            // Check for win
            if (userColors[0].Equals(computerColors[0]) && userColors[1].Equals(computerColors[1]))
            {
                Console.WriteLine("Correct! Good Job.");

            }
            // One color matches and is in the correct position
            else if (userColors[0].Equals(computerColors[0]) || userColors[1].Equals(computerColors[1]))
            {
                Console.WriteLine("\n0 - 1. You guessed one of the colors in the correct position.");
                Console.WriteLine();
            }
            // At least one color is correct
            else if (userColors.Contains(computerColors[0]) || userColors.Contains(computerColors[1]))
            {
                // Check if both colors are correct but in the wrong position
                if (userColors[0].Equals(computerColors[1]) && userColors[1].Equals(computerColors[0]))
                {
                    Console.WriteLine("\n2 - 0. You guess both of the colors but in the wrong positions");
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("\n1 - 0. You guessed one of the colors correctly but not in the correct position.");
                    Console.WriteLine();
                }
            }
            // No colors match
            else
            {
                Console.WriteLine("\n0 - 0. You did not guess either color.");
            }

            Console.WriteLine("\nWould you like to play again? Y/N");
            bool isPlaying = Console.ReadLine().ToUpper().Contains("Y") ? true : false;


            Console.WriteLine("\nGoodbye!");
            Console.ReadKey();
        }

    }

}
