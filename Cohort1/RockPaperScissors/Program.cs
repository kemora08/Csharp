using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors
{
    class Program
    {
        public static int userHand = 0;
        public static int computerHand { get; private set; }

        public static string computerstring;

        public static bool isPlaying = true;

        public static void Main(string[] args)
        {
            do
            {
                Random random = new Random();
                int computerHand = random.Next(1, 3);


                Console.WriteLine("Enter rock, paper, scissors");
                string input = Console.ReadLine().ToLower();
                switch (input)
                {
                    case "rock":
                        userHand = 3;
                        break;
                    case "paper":
                        userHand = 2;
                        break;
                    case "scissors":
                        userHand = 1;
                        break;
                    default:
                        break;
                }

                switch (computerHand)
                {

                    case 1:
                        computerstring = "scissors";
                        break;
                    case 2:
                        computerstring = "paper";
                        break;
                    case 3:
                        computerstring = "rock";
                        break;
                }

                if (userHand != 0)
                {
                    CompareHands(userHand, computerHand);
                    Console.WriteLine();
                }
                Console.WriteLine("Do you want to play again. Y/N ");
                string answer = Console.ReadLine().ToLower();
                if (answer == "no")
                {
                    isPlaying = false;
                }
            } while (isPlaying);





        }

        public static void CompareHands(int userHand, int computerHand)
        {
            if (userHand == computerHand)
            {
                Console.WriteLine("computer chose" + computerstring);
                Console.WriteLine("It's a draw");
            }

            else if (userHand == 3 && computerHand == 1)
            {
                Console.WriteLine("Computer chose" + computerstring);
                Console.WriteLine("You won");
            }

            else if (userHand == 2 && computerHand == 3)
            {
                Console.WriteLine("You won");
                Console.WriteLine("computer chose" + computerstring);
            }

            else if (userHand == 1 && computerHand == 2)
            {
                Console.WriteLine("You won");
                Console.WriteLine("computer chose" + computerstring);
            }

            else if (userHand == 3 && computerHand == 2)
            {
                Console.WriteLine("I win");
                Console.WriteLine("computer chose" + computerstring);
            }

            else if (userHand == 2 && computerHand == 1)
            {
                Console.WriteLine("I win");
                Console.WriteLine("computer chose" + computerstring);
            }

            else if (userHand == 1 && computerHand == 3)
            {
                Console.WriteLine("I win");
                Console.WriteLine("computer chose" + computerstring);
            }

        }
    }
}
