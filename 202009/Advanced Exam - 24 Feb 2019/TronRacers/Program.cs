using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TronRacers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Player firstPlayer = new Player(-1, -1, 'f');
            Player secondPlayer = new Player(-1, -1, 's');

            char[,] matrix = new char[n, n];

            for (int row = 0; row < n; row++)
            {
                string rowInput = Console.ReadLine();

                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = rowInput[col];

                    if (rowInput[col] == 'f')
                    {
                        firstPlayer.Row = row;
                        firstPlayer.Col = col;
                    }
                    else if(rowInput[col] == 's')
                    {
                        secondPlayer.Row = row;
                        secondPlayer.Col = col;
                    }
                }
            }

            List<Player> players = new List<Player>();

            players.Add(firstPlayer);
            players.Add(secondPlayer);

            while (firstPlayer.IsAlive && secondPlayer.IsAlive)
            {
                string[] commands = Console.ReadLine().Split().ToArray();

                for (int i = 0; i < commands.Length; i++)
                {
                    string command = commands[i];

                    Player currentPlayer = players[i];

                    if (command == "up")
                    {
                        currentPlayer.Row--;

                        if (currentPlayer.Row < 0)
                        {
                            currentPlayer.Row = matrix.GetLength(0) - 1;
                        }
                    }
                    else if (command == "down")
                    {
                        currentPlayer.Row++;

                        if (currentPlayer.Row > matrix.GetLength(0) - 1)
                        {
                            currentPlayer.Row = 0;
                        }
                    }
                    else if (command == "left")
                    {
                        currentPlayer.Col--;

                        if (currentPlayer.Col < 0)
                        {
                            currentPlayer.Col = matrix.GetLength(1) - 1;
                        }
                    }
                    else if (command == "right")
                    {
                        currentPlayer.Col++;

                        if (currentPlayer.Col > matrix.GetLength(1) - 1)
                        {
                            currentPlayer.Col = 0;
                        }
                    }

                    if (matrix[currentPlayer.Row, currentPlayer.Col] == '*')
                    {
                        matrix[currentPlayer.Row, currentPlayer.Col] = currentPlayer.Mark;
                    }
                    else
                    {
                        matrix[currentPlayer.Row, currentPlayer.Col] = 'x';
                        currentPlayer.IsAlive = false;
                        break;
                    }
                }
            }

            PrintMatrix(matrix);
        }

        private static void PrintMatrix(char[,] matrix)
        {
            StringBuilder sb = new StringBuilder();

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    sb.Append(matrix[row, col]);
                }

                sb.AppendLine();
            }

            Console.WriteLine(sb.ToString().TrimEnd());
        }
    }

    public class Player
    {
        public Player(int row, int col, char mark)
        {
            this.Row = row;
            this.Col = col;
            this.Mark = mark;
            this.IsAlive = true;
        }

        public int Row { get; set; }
        public int Col { get; set; }
        public bool IsAlive { get; set; }
        public char Mark { get; set; }
    }
}
