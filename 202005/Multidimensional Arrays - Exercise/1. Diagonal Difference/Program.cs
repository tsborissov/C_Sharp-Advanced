using System;
using System.Linq;

namespace _1._Diagonal_Difference
{
    class Program
    {
        static void Main(string[] args)
        {

            int size = int.Parse(Console.ReadLine());

            int[,] matrix = new int[size, size];

            for (int i = 0; i < size; i++)
            {
                int[] row = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                for (int j = 0; j < size; j++)
                {
                    matrix[i, j] = row[j];
                }
            }

            int primaryDiagonalSum = 0;
            int secondaryDiagonalSum = 0;
            int counter = size - 1;

            for (int k = 0; k < size; k++)
            {
                primaryDiagonalSum += matrix[k, k];

                secondaryDiagonalSum += matrix[k, counter];

                counter--;
            }

           
            int difference = Math.Abs(primaryDiagonalSum - secondaryDiagonalSum);

            Console.WriteLine(difference);

        }
    }
}
