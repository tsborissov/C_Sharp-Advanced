using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Garden
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int[,] matrix = new int[dimensions[0], dimensions[1]];

            Queue<string> positions = new Queue<string>();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "Bloom Bloom Plow")
            {
                int[] target = input.Split().Select(int.Parse).ToArray();

                bool isInside = target[0] > -1 && target[0] < matrix.GetLength(0) &&
                    target[1] > -1 && target[1] < matrix.GetLength(1);

                if (isInside)
                {
                    positions.Enqueue(input);
                }
                else
                {
                    Console.WriteLine("Invalid coordinates.");
                }
            }

            while (positions.Any())
            {
                int[] coordinates = positions.Dequeue().Split().Select(int.Parse).ToArray();

                int row = coordinates[0];
                int col = coordinates[1];

                matrix[row, col] -= 1;

                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    matrix[row, i] += 1;
                }

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[j, col] += 1;
                }
            }

            PrintMatrix(matrix);
        }

        private static void PrintMatrix(int[,] matrix)
        {
            StringBuilder sb = new StringBuilder();
            
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    sb.Append(matrix[row, col].ToString() + " ");
                }

                sb.AppendLine();
            }

            Console.WriteLine(sb.ToString().TrimEnd());

        }
    }
}
