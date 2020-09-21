using System;
using System.Linq;

namespace _3._Maximal_Sum
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] size = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[,] matrix = new int[size[0], size[1]];

            for (int r = 0; r < size[0]; r++)
            {
                int[] row = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int c = 0; c < size[1]; c++)
                {
                    matrix[r, c] = row[c];
                }
            }

            int maxSum = int.MinValue;
            int maxRow = -1;
            int maxCol = -1;

            for (int r = 0; r < matrix.GetLength(0) - 2; r++)
            {
                for (int c = 0; c < matrix.GetLength(1) - 2; c++)
                {
                    int currentSum = 0;
                    
                    for (int i = r; i < r + 3; i++)
                    {
                        for (int j = c; j < c + 3; j++)
                        {
                            currentSum += matrix[i, j];
                        }
                        
                    }

                    if (currentSum > maxSum)
                    {
                        maxSum = currentSum;
                        maxRow = r;
                        maxCol = c;
                    }
                }
            }

            Console.WriteLine($"Sum = {maxSum}");

            for (int i = maxRow; i < maxRow + 3; i++)
            {
                for (int j = maxCol; j < maxCol + 3; j++)
                {
                    Console.Write($"{matrix[i, j]} ");
                }

                Console.WriteLine();
            }
        }
    }
}
