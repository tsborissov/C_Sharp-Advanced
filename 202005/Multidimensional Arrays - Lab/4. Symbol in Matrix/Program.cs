using System;

namespace _4._Symbol_in_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n, n];

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();

                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = input[j];
                }
            }

            char symbol = char.Parse(Console.ReadLine());
            bool isFound = false;
            int row = -1;
            int col = -1;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == symbol)
                    {
                        isFound = true;
                        row = i;
                        col = j;
                        break;
                    }

                    if (isFound)
                    {
                        break;
                    }
                }
            }

            if (isFound)

            {
                Console.WriteLine($"({row}, {col})");
            }
            else
            {
                Console.WriteLine($"{symbol} does not occur in the matrix");
            }

        }
    }
}
