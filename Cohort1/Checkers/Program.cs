using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers
{
    public struct Position
    {
        public int Row { get; private set; }
        public int Col { get; private set; }
        public Position(int row, int col)
        {
            this.Row = row;
            this.Col = col;
        }
    }

    public enum Color { White, Black}

    public class Checker
    {
        public String Symbol { get; private set; } // open or a closed dot
        public Color Team { get; private set; } // team name (either "white or "black")
        public Position Position { get; set; } // coordinates of it's place on the grid
        
        //Costructor:

        public Checker(Color team, int row, int col)
        {
            if(team == Color.Black)
            {
                int symbol = int.Parse("25CB", System.Globalization.NumberStyles.HexNumber);
                Symbol = char.ConvertFromUtf32(symbol);
                Team = Color.Black;
            }
            else
            {
                int symbol = int.Parse("25CF", System.Globalization.NumberStyles.HexNumber);
                Symbol = char.ConvertFromUtf32(symbol);
                Team = Color.White;
            }
            Position = new Position(row, col);
        }
    }

    public class Board
    {
        public List<Checker> checkers;
        public Board()
        {
            checkers = new List<Checker>();
            for (int r = 0; r < 3; r++)
            {
                for (int i = 0; i < 8; i += 2)
                {
                    Checker c = new Checker(Color.White, r, (r + 1) % 2 + i);
                    checkers.Add(c);
                }
                for (int i = 0; i < 8; i += 2)
                {
                    // the first three rows are for White checkers (row = 0,1,2)
                    Checker c = new Checker(Color.White, r, (r + 1) % 2 + i);
                    checkers.Add(c);
                }
                for (int i = 0; i < 8; i += 2)
                {
                    // the last three rows are Black checkers (row=5,6,7)
                    Checker c = new Checker(Color.Black, (r + 5), r % 2 + i);
                    checkers.Add(c);
                }
            }
        }
        public Checker GetChecker(Position pos)
        {
            foreach (Checker c in checkers)
            {
                if (c.Position.Row == pos.Row && c.Position.Col == pos.Col)
                {
                    return c;
                }
            }
            return null;
        }

        public void RemoveChecker(Checker checker)
        {
            if (checker != null)
            {
                checkers.Remove(checker);
            }
        }

        public void MoveChecker(Checker checker, Position dest)
        {
            Checker c = new Checker(checker.Team, dest.Row, dest.Col);
            checkers.Add(c);
            checkers.Remove(checker);
        }

    }


    public class Game
    {
        private Board board;
        public Game()
        {
            this.board = new Board();
        }

        private bool CheckForWin()
        {
            return (board.checkers.All(x => x.Team == Color.White) || board.checkers.All(x => x.Team == Color.Black));
        }

        public void Start()
        {
            Drawboard();
            while (!CheckForWin()) 
            {
                ProcessInput();
            }

            Console.WriteLine("Congrats, you win!");
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }

        public bool IsLegalMove(Color player, Position src, Position dest)
        {
            if (src.Row < 0 || src.Row > 7 || src.Col < 0 || src.Col > 7
                || dest.Row < 0 || dest.Row > 7 || dest.Col < 0
                || dest.Col > 7) return false;

            int rowDistance = Math.Abs(dest.Row - src.Row);
            int colDistance = Math.Abs(dest.Col - src.Col);

            if (colDistance == 0 || rowDistance == 0) return false;

            if (rowDistance == 0 || colDistance != 1) return false;

            if (rowDistance > 2) return false;

            Checker c = board.GetChecker(src);
            if (c != null)
            {
                return false;
            }
            c = board.GetChecker(dest);

            if (c != null)
            {
                return false;
            }
            if (rowDistance == 2)
            {
                if (IsCapture(src, dest))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return true;
            }
        }

        public bool IsCapture(Position src, Position dest)
        {
            int rowDistance = Math.Abs(dest.Row - src.Row);
            int colDistance = Math.Abs(dest.Col - src.Row);
            if (rowDistance == 2 && colDistance == 2)
            {
                int row_mid = (dest.Row + src.Row) / 2;
                int col_mid = (dest.Col + src.Col) / 2;
                Position p = new Position(row_mid, col_mid);
                Checker c = board.GetChecker(p);
                Checker player = board.GetChecker(src);
                if (c == null)
                {
                    return false;
                }
                else
                {
                    if (c.Team == player.Team)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
            }
            else
            {
                return false;
            }
        }

        public Checker GetCaptureChecker(Position src, Position dest)
        {
            if (IsCapture(src, dest))
            {
                int row_mid = (dest.Row - src.Row) / 2;
                int col_mid = (dest.Col - src.Col) / 2;
                Position p = new Position(row_mid, col_mid);
                Checker c = board.GetChecker(p);
                return c;
            }
            return null;
        }

        public void ProcessInput()
        {
            Console.WriteLine("Select a checker to move (Row, Column):");
            String[] src = Console.ReadLine().Split(',');
            Console.WriteLine("Select a square to move to (Row, Column):");
            string[] dest = Console.ReadLine().Split(',');

            Position from = new Position(int.Parse(src[0]), int.Parse(src[1]));
            Position to = new Position(int.Parse(dest[0]), int.Parse(dest[1]));

            Checker PlayerChecker = board.GetChecker(from);

            if (PlayerChecker == null)
            {
                Console.WriteLine("There is no checker there, try again.");
                
            }
            else
            {
                if (this.IsLegalMove(PlayerChecker.Team, from, to))
                {
                    if (this.IsCapture(from, to)) 
                    {
                        Checker captureChecker = this.GetCaptureChecker(from, to);
                        board.RemoveChecker(captureChecker);
                    }

                    board.MoveChecker(PlayerChecker, to);
                }
                else
                {

                    Console.WriteLine("This move is not valid, please try again.");
                }
            }
            Drawboard();
        }

        public void Drawboard()
        {
            String[][] grid = new String[8][];
            for(int r = 0; r < 8; r++)
            {
                grid[r] = new String[8];
                for(int c = 0; c < 8; c++)
                {
                    grid[r][c] = " ";
                }
            }
            foreach(Checker c in board.checkers)
            {
                grid[c.Position.Row][c.Position.Col] = c.Symbol;
            }

            Console.WriteLine(" 0  1  2  3  4  5  6  7" );
            Console.Write(" ");
            for(int i = 0; i < 32; i++)
            {
                Console.Write(i);
                for (int c = 0; c < 8; c++)
                {
                    Console.Write("\u2501");
                }
                Console.WriteLine();

            }
            for (int c = 0; c < 8; c++)
            {
                Console.Write($"{c} ");
                for (int r = 0; r < 8; r++)
                {
                    Console.Write($" {grid[r][c]} \u2503");
                }
                Console.WriteLine();
                Console.Write(" ");
                for (int i = 0; i < 32; i++)
                {
                    Console.Write("\u2501");
                }
                Console.WriteLine();
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Game newgame = new Game();
            newgame.Start();
            Console.ReadKey();
        }
    }
}
