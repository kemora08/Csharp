using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ticTacToe
{
    class Program
    {
        private static string[,] Board;

        public static void Main(string[] args)
        {
            InitializeBoard();
            bool isPlaying = true;
            string playerLetter = "X";

            while (isPlaying)
            {
                PrintBoard();
                Console.WriteLine($"\n\nPlayer {playerLetter}. Enter the number of the square");
                string answer = Console.ReadLine();
                if (!int.TryParse(answer, out int number) && number < 10)
                {
                    Console.WriteLine("You did enter a valid square. Press any key to try again.");
                    Console.ReadKey();
                    continue;
                }
                else
                {
                    if (PlaceMark(answer, playerLetter))
                    {
                        PrintBoard();
                        if (HasWon(playerLetter))
                        {
                            Console.WriteLine($"Player {playerLetter} wins!");
                            if (PlayAgain())
                            {
                                continue;
                            }
                            else break;
                        }
                        else if (IsTie())
                        {
                            Console.WriteLine("No winner.");
                            if (PlayAgain())
                            {
                                continue;
                            }
                            else break;
                        }
                        else
                        {
                            playerLetter = playerLetter == "X" ? "O" : "X";
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Player {playerLetter} cannot place a mark there. Press any key to contine.");
                    }
                }
            }
        }

        private static bool PlayAgain()
        {
            Console.WriteLine("\nWould you like to play again? Y/N?");
            string playAgain = Console.ReadLine().ToUpper();
            if (playAgain.Contains("Y"))
            {
                InitializeBoard();
                return true;
            }
            else
            {
                return false;
            }
        }

        private static bool IsTie()
        {
            // check for all squares have a mark
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (!Board[i, j].Equals("X") && !Board[i, j].Equals("0"))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private static bool HasWon(string playerLetter)
        {
            if (IsHorizontalWin(playerLetter) || IsVerticalWin(playerLetter) || IsDiagonalWin(playerLetter))
            {
                return true;
            }
            return false;
        }

        private static bool IsDiagonalWin(string playerLetter)
        {
            if (Board[0, 0].Equals(playerLetter) && Board[1, 1].Equals(playerLetter) && Board[2, 2].Equals(playerLetter) ||
                Board[2, 0].Equals(playerLetter) && Board[1, 1].Equals(playerLetter) && Board[0, 1].Equals(playerLetter))

            {
                return true;
            }

            return false;
        }

        private static bool IsVerticalWin(string playerLetter)
        {
            for (int i = 0; i < 3; i++)
            {
                // i represents the row
                if (Board[0, i].Contains(playerLetter) &&
                    Board[0, i].Equals(Board[1, i]) &&
                    Board[0, i].Equals(Board[2, i]))
                {
                    return true;
                }
            }
            return false;
        }

        private static bool IsHorizontalWin(string playerLetter)
        {
            for (int i = 0; i < 3; i++)
            {
                // i represents the column
                if (Board[i, 0].Contains(playerLetter) &&
                    Board[i, 0].Equals(Board[i, 1]) &&
                    Board[i, 0].Equals(Board[i, 2]))
                {
                    return true;
                }
            }
            return false;

        }

        private static bool PlaceMark(string square, string player)
        {
            string otherplayer = player == "X" ? "O" : "X";
            // find the selected square
            for (int row = 0; row <= 2; row++)
            {
                for (int column = 0; column <= 2; column++)
                {
                    object otherPlayer = null;
                    if (Board[row, column].Equals(square) && (!Board[row, column].Equals(otherPlayer) || !Board[row, column].Equals(player)))
                    {
                        Board[row, column] = player;
                        return true;
                    }
                }

            }
            return false;
        }

        private static void PrintBoard()
        {
            Console.Clear();
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("\t" + Board[i, 0] + " | " + Board[i, 1] + "|" + Board[i, 2]);
                if (i < 2)
                {
                    Console.WriteLine("\t---------");
                }
            }
        }

        private static void InitializeBoard()
        {
            Board = new string[3, 3]
            {
                // (0, 0), (0, 1), (0, 2)
                {"1", "2", "3" },

                // (1,0), (1,1), (1,2)
                {"4", "5", "6" },

                // (2,0), (2,1), (2,2)
                {"7", "8", "9" },
            };
        }
    }
}
