using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _10._Radioactive_Mutant_Vampire_Bunnies_v2
{
    class Program
    {
        static char[,] matrix;
        static int playerRow;
        static int playerCol;
        static bool isDead;
        
        static void Main(string[] args)
        {
            isDead = false;
            
            int[] size = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int totalRows = size[0];
            int totalCols = size[1];

            matrix = new char[totalRows, totalCols];

            PopulateMatrix();

            string directions = Console.ReadLine();

            foreach (var currentDirection in directions)
            {
                switch (currentDirection)
                {
                    case 'U':
                        Move(-1, 0);
                        break;

                    case 'L':
                        Move(0, -1);
                        break;

                    case 'D':
                        Move(1, 0);
                        break;

                    case 'R':
                        Move(0, 1);
                        break;
                }

                Spread();

                if (isDead)
                {
                    PrintMatrix();
                    Console.WriteLine($"dead: {playerRow} {playerCol}");

                    Environment.Exit(0);
                }
            }
        }

        private static void Spread()
        {
            List<int> indexes = new List<int>();
            
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'B')
                    {
                        indexes.Add(row);
                        indexes.Add(col);
                    }
                }
            }

            for (int i = 0; i < indexes.Count; i += 2)
            {
                int bunnyRow = indexes[i];
                int bunnyCol = indexes[i + 1];

                //Right
                if (IsInside(bunnyRow, bunnyCol + 1))
                {
                    if (matrix[bunnyRow, bunnyCol + 1] == 'P')
                    {
                        isDead = true;
                    }

                    matrix[bunnyRow, bunnyCol + 1] = 'B';
                }

                //Left
                if (IsInside(bunnyRow, bunnyCol - 1))
                {
                    if (matrix[bunnyRow, bunnyCol - 1] == 'P')
                    {
                        isDead = true;
                    }

                    matrix[bunnyRow, bunnyCol - 1] = 'B';
                }

                //Down
                if (IsInside(bunnyRow + 1, bunnyCol))
                {
                    if (matrix[bunnyRow + 1, bunnyCol] == 'P')
                    {
                        isDead = true;
                    }

                    matrix[bunnyRow + 1, bunnyCol] = 'B';
                }

                //Up
                if (IsInside(bunnyRow - 1, bunnyCol))
                {
                    if (matrix[bunnyRow - 1, bunnyCol] == 'P')
                    {
                        isDead = true;
                    }

                    matrix[bunnyRow - 1, bunnyCol] = 'B';
                }
            }
        }

        private static void Move(int row, int col)
        {
            if (!IsInside(playerRow + row, playerCol + col))
            {
                matrix[playerRow, playerCol] = '.';
                Spread();
                PrintMatrix();
                Console.WriteLine($"won: {playerRow} {playerCol}");
                Environment.Exit(0);
            }

            if (matrix[playerRow + row, playerCol + col] == 'B')
            {
                Spread();
                PrintMatrix();
                Console.WriteLine($"dead: {playerRow + row} {playerCol + col}");
                Environment.Exit(0);
            }

            matrix[playerRow, playerCol] = '.';

            playerRow += row;
            playerCol += col;

            matrix[playerRow, playerCol] = 'P';
        }

        private static void PrintMatrix()
        {
            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                var outputRow = new StringBuilder();

                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    outputRow.Append(matrix[r, c]);
                }

                Console.WriteLine(outputRow);

            }
        }

        private static bool IsInside(int row, int col)
        {
            return row > -1 && row < matrix.GetLength(0) &&
                col > -1 && col < matrix.GetLength(1);
        }

        private static void PopulateMatrix()
        {
            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                char[] inputRow = Console.ReadLine().ToCharArray();

                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    matrix[r, c] = inputRow[c];

                    if (matrix[r,c] == 'P')
                    {
                        playerRow = r;
                        playerCol = c;
                    }
                }
            }
        }
    }
}
