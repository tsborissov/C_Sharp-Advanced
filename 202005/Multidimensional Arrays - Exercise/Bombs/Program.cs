using System;
using System.Linq;

namespace Bombs
{
    class Program
    {
        static void Main(string[] args)
        {

            int size = int.Parse(Console.ReadLine());

            int[,] matrix = new int[size, size];

            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                int[] currentRow = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    matrix[r, c] = currentRow[c];
                }
            }

            string[] bombIndexes = Console.ReadLine().Split();

            for (int i = 0; i < bombIndexes.Length; i++)
            {
                int bombRow = bombIndexes[i].Split(',').Select(int.Parse).ToArray()[0];
                int bombCol = bombIndexes[i].Split(',').Select(int.Parse).ToArray()[1];

                if (matrix[bombRow, bombCol] > 0)
                {
                    int[,] targetCoordinates = new int[8, 2];

                    CalculateTargetCoordinates(targetCoordinates, bombRow, bombCol);

                    int bombPower = matrix[bombRow, bombCol];
                    matrix[bombRow, bombCol] = 0;

                    for (int r = 0; r < targetCoordinates.GetLength(0); r++)
                    {
                        int targetRow = targetCoordinates[r, 0];
                        int targetCol = targetCoordinates[r, 1];

                        if (IsInside(matrix, targetRow, targetCol) && matrix[targetRow, targetCol] > 0)
                        {
                            matrix[targetRow, targetCol] -= bombPower;
                        }
                    }
                }
            }

            int activeCellsCount = 0;
            int activeCellsSum = 0;

            foreach (var item in matrix)
            {
                if (item > 0)
                {
                    activeCellsCount++;
                    activeCellsSum += item;
                }
            }

            Console.WriteLine($"Alive cells: {activeCellsCount}");
            Console.WriteLine($"Sum: {activeCellsSum}");

            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    Console.Write($"{matrix[r, c]} ");
                }
                Console.WriteLine();
            }
        }

        private static void CalculateTargetCoordinates(int[,] targetCoordinates, int row, int col)
        {
            targetCoordinates[0, 0] = row - 1;
            targetCoordinates[1, 0] = row - 1;
            targetCoordinates[2, 0] = row - 1;
            targetCoordinates[3, 0] = row;
            targetCoordinates[4, 0] = row;
            targetCoordinates[5, 0] = row + 1;
            targetCoordinates[6, 0] = row + 1;
            targetCoordinates[7, 0] = row + 1;
            targetCoordinates[0, 1] = col - 1;
            targetCoordinates[1, 1] = col;
            targetCoordinates[2, 1] = col + 1;
            targetCoordinates[3, 1] = col - 1;
            targetCoordinates[4, 1] = col + 1;
            targetCoordinates[5, 1] = col - 1;
            targetCoordinates[6, 1] = col;
            targetCoordinates[7, 1] = col + 1;
        }

        private static bool IsInside(int[,] matrix, int row, int col)
        {
            return row > -1 && row < matrix.GetLength(0) &&
                col > -1 && col < matrix.GetLength(1);
        }
    }
}
