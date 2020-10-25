using System;
using System.Text;

namespace ReVolt
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int commandsCount = int.Parse(Console.ReadLine());

            char[,] matrix = new char[size, size];

            Player player = null;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                char[] currentRow = Console.ReadLine().ToCharArray();

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = currentRow[j];

                    if (currentRow[j] == 'f')
                    {
                        player = new Player(i, j);
                    }
                }
            }

            for (int i = 0; i < commandsCount; i++)
            {
                string command = Console.ReadLine();

                if (command == "up")
                {
                    player.TargetRow = player.Row - 1;
                    player.TargetCol = player.Col;

                    player.Move(matrix);
                }
                else if (command == "down")
                {
                    player.TargetRow = player.Row + 1;
                    player.TargetCol = player.Col;

                    player.Move(matrix);
                }
                else if (command == "left")
                {
                    player.TargetRow = player.Row;
                    player.TargetCol = player.Col - 1;

                    player.Move(matrix);
                }
                else if (command == "right")
                {
                    player.TargetRow = player.Row;
                    player.TargetCol = player.Col + 1;

                    player.Move(matrix);
                }

                if (player.isFinishReached)
                {
                    break;
                }
            }

            StringBuilder sb = new StringBuilder();

            if (player.isFinishReached)
            {
                sb.AppendLine("Player won!");
            }
            else
            {
                sb.AppendLine("Player lost!");
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    sb.Append(matrix[i, j]);
                }

                sb.AppendLine();
            }

            Console.WriteLine(sb.ToString().TrimEnd());

        }
    }

    public class Player
    {
        public Player(int row, int col)
        {
            this.Row = row;
            this.Col = col;
            this.TargetRow = -1;
            this.TargetCol = -1;
            this.isFinishReached = false;
        }

        public int Row { get; set; }
        public int Col { get; set; }
        public int TargetRow { get; set; }
        public int TargetCol { get; set; }
        public bool isFinishReached { get; set; }


        public void CheckTarget(char[,] matrix)
        {
            bool isInside = this.TargetRow > -1 &&
               this.TargetRow < matrix.GetLength(0) &&
               this.TargetCol > -1 &&
               this.TargetCol < matrix.GetLength(1);

            if (!isInside)
            {

                if (this.TargetRow < 0)
                {
                    this.TargetRow = matrix.GetLength(0) - 1;
                }
                else if (this.TargetRow > matrix.GetLength(0) - 1)
                {
                    this.TargetRow = 0;
                }
                else if (this.TargetCol < 0)
                {
                    this.TargetCol = matrix.GetLength(1) - 1;
                }
                else if (this.TargetCol > matrix.GetLength(1) - 1)
                {
                    this.TargetCol = 0;
                }
            }
        }

        public void Move(char[,] matrix)
        {
            matrix[this.Row, this.Col] = '-';

            CheckTarget(matrix);

            if (matrix[this.TargetRow, this.TargetCol] == 'B')
            {
                int forwardRow = this.TargetRow - this.Row;
                int forwardCol = this.TargetCol - this.Col;
                
                this.TargetRow += forwardRow;
                this.TargetCol += forwardCol;
            }
            else if (matrix[this.TargetRow, this.TargetCol] == 'T')
            {
                this.TargetRow = this.Row;
                this.TargetCol = this.Col;
            }
            else if (matrix[this.TargetRow, this.TargetCol] == 'F')
            {
                this.isFinishReached = true;
            }

            CheckTarget(matrix);

            this.Row = this.TargetRow;
            this.Col = this.TargetCol;

            matrix[this.Row, this.Col] = 'f';
        }
    }
}
