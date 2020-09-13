using System;
using System.Linq;

namespace _6._Jagged_Array_Modification
{
    class Program
    {
        static void Main(string[] args)
        {

            int rows = int.Parse(Console.ReadLine());

            int[][] jaggedArr = new int[rows][];

            for (int i = 0; i < jaggedArr.Length; i++)
            {
                int[] currentRow = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                jaggedArr[i] = new int[currentRow.Length];

                for (int j = 0; j < jaggedArr[i].Length; j++)
                {
                    jaggedArr[i][j] = currentRow[j];
                }
            }

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "END")
            {
                string[] tokens = input.Split()
                    .ToArray();

                string command = tokens[0];
                int row = int.Parse(tokens[1]);
                int col = int.Parse(tokens[2]);
                int value = int.Parse(tokens[3]);

                bool isValidCoord = row >= 0 && row < jaggedArr.Length && col >= 0 && col < jaggedArr[row].Length;

                if (isValidCoord)
                {
                    switch (command)
                    {
                        case "Add":

                            jaggedArr[row][col] += value;

                            break;

                        case "Subtract":

                            jaggedArr[row][col] -= value;

                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid coordinates");
                }

            }

            for (int i = 0; i < jaggedArr.Length; i++)
            {
                Console.WriteLine(string.Join(' ', jaggedArr[i]));
            }
        }
    }
}
