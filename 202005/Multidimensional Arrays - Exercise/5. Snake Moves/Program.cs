using System;
using System.Collections.Generic;
using System.Linq;

namespace _5._Snake_Moves
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] size = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<char> snake = new Queue<char>(Console.ReadLine().ToCharArray());

            char[,] matrix = new char[size[0], size[1]];

            for (int r = 0; r < size[0]; r++)
            {
                if (r % 2 == 0)
                {
                    for (int c = 0; c < size[1]; c++)
                    {
                        char currentSymbol = snake.Dequeue();

                        snake.Enqueue(currentSymbol);

                        matrix[r, c] = currentSymbol;
                    }
                }
                else
                {
                    for (int c = size[1] - 1; c >= 0; c--)
                    {
                        char currentSymbol = snake.Dequeue();

                        snake.Enqueue(currentSymbol);

                        matrix[r, c] = currentSymbol;
                    }
                }
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write($"{matrix[i, j]}");
                }

                Console.WriteLine();
            }
        }
    }
}
