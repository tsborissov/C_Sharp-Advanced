using System;
using System.Linq;

namespace _4._Matrix_Shuffling
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] size = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            string[,] matrix = new string[size[0], size[1]];

            for (int r = 0; r < size[0]; r++)
            {
                string[] row = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                for (int c = 0; c < size[1]; c++)
                {
                    matrix[r, c] = row[c];
                }
            }

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "END")
            {
                string[] tokens = input.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

                if (tokens.Length == 5 && tokens[0] == "swap")
                {
                    int row1 = int.Parse(tokens[1]);
                    int col1 = int.Parse(tokens[2]);
                    int row2 = int.Parse(tokens[3]);
                    int col2 = int.Parse(tokens[4]);

                    bool isValidCoordinate =
                        row1 > -1 && row1 < matrix.GetLength(0) &&
                        row2 > -1 && row2 < matrix.GetLength(0) &&
                        col1 > -1 && col1 < matrix.GetLength(1) &&
                        col2 > -1 && col2 < matrix.GetLength(1);

                    if (!isValidCoordinate)
                    {
                        Console.WriteLine("Invalid input!");
                        continue;
                    }

                    string temp = matrix[row1, col1];
                    matrix[row1, col1] = matrix[row2, col2];
                    matrix[row2, col2] = temp;

                    for (int i = 0; i < matrix.GetLength(0); i++)
                    {
                        for (int j = 0; j < matrix.GetLength(1); j++)
                        {
                            Console.Write($"{matrix[i, j]} ");
                        }

                        Console.WriteLine();
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }
            }
        }
    }
}
