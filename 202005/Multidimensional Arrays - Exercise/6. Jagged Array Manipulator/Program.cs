using System;
using System.Linq;

namespace Jagged_Array_Manipulator
{
    class Program
    {
        static void Main(string[] args)
        {

            int numberOfRows = int.Parse(Console.ReadLine());

            double[][] jaggedArr = new double[numberOfRows][];

            for (int r = 0; r < numberOfRows; r++)
            {
                jaggedArr[r] = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(double.Parse)
                    .ToArray();

            }

            Analyze(jaggedArr);


            string input = string.Empty;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] tokens = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string command = tokens[0];
                int targetRow = int.Parse(tokens[1]);
                int targetColumn = int.Parse(tokens[2]);
                int value = int.Parse(tokens[3]);

                bool isValidCoordinate =
                    targetRow > -1 &&
                    targetRow < jaggedArr.Length &&
                    targetColumn > -1 &&
                    targetColumn < jaggedArr[targetRow].Length;

                if (isValidCoordinate)
                {
                    switch (command)
                    {
                        case "Add":

                            jaggedArr[targetRow][targetColumn] += value;

                            break;

                        case "Subtract":

                            jaggedArr[targetRow][targetColumn] -= value;

                            break;
                    }
                }
            }

            for (int i = 0; i < jaggedArr.Length; i++)
            {
                Console.WriteLine(string.Join(' ', jaggedArr[i]));
            }

        }

        private static void Analyze(double[][] jaggedArr)
        {
            for (int i = 0; i < jaggedArr.Length - 1; i++)
            {
                if (jaggedArr[i].Length == jaggedArr[i + 1].Length)
                {
                    for (int j = 0; j < jaggedArr[i].Length; j++)
                    {
                        jaggedArr[i][j] *= 2;
                        jaggedArr[i + 1][j] *= 2;
                    }
                }
                else
                {
                    for (int k = 0; k < jaggedArr[i].Length; k++)
                    {
                        jaggedArr[i][k] /= 2;
                    }

                    for (int l = 0; l < jaggedArr[i + 1].Length; l++)
                    {
                        jaggedArr[i + 1][l] /= 2;
                    }
                }
            }
        }
    }
}