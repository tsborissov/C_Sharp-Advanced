using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Radioactive_Mutant_Vampire_Bunnies
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] size = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var lair = new char[size[0], size[1]];
            int playerRow = -1;
            int playerCol = -1;

            for (int r = 0; r < lair.GetLength(0); r++)
            {
                string input = Console.ReadLine();

                for (int c = 0; c < lair.GetLength(1); c++)
                {
                    lair[r, c] = input[c];

                    if (input[c] == 'P')
                    {
                        playerRow = r;
                        playerCol = c;
                    }
                }
            }

            var directions = new Queue<char> (Console.ReadLine().ToCharArray());

            bool isDead = false;
            bool isWon = false;
 
            while (directions.Count > 0)
            {
                char currentMove = directions.Dequeue();

                int targetRow = -1;
                int targetCol = -1;

                switch (currentMove)
                {
                    case 'L':

                        targetRow = playerRow;
                        targetCol = playerCol - 1;

                        if (IsInside(lair, targetRow, targetCol))
                        {
                            if (lair[targetRow, targetCol] == 'B')
                            {
                                isDead = true;
                            }
                            else
                            {
                                lair[targetRow, targetCol] = 'P';
                                lair[playerRow, playerCol] = '.';
                            }
                            playerRow = targetRow;
                            playerCol = targetCol;
                        }
                        else
                        {
                            isWon = true;
                        }

                        break;

                    case 'R':

                        if (IsInside(lair, targetRow, targetCol))
                        {
                            if (lair[targetRow, targetCol] == 'B')
                            {
                                isDead = true;
                            }
                            else
                            {
                                lair[targetRow, targetCol] = 'P';
                                lair[playerRow, playerCol] = '.';
                            }
                            playerRow = targetRow;
                            playerCol = targetCol;
                        }
                        else
                        {
                            isWon = true;
                        }

                        break;

                    case 'U':

                        if (IsInside(lair, targetRow, targetCol))
                        {
                            if (lair[targetRow, targetCol] == 'B')
                            {
                                isDead = true;
                            }
                            else
                            {
                                lair[targetRow, targetCol] = 'P';
                                lair[playerRow, playerCol] = '.';
                            }
                            playerRow = targetRow;
                            playerCol = targetCol;
                        }
                        else
                        {
                            isWon = true;
                        }

                        break;

                    case 'D':

                        if (IsInside(lair, targetRow, targetCol))
                        {
                            if (lair[targetRow, targetCol] == 'B')
                            {
                                isDead = true;
                            }
                            else
                            {
                                lair[targetRow, targetCol] = 'P';
                                lair[playerRow, playerCol] = '.';
                            }
                            playerRow = targetRow;
                            playerCol = targetCol;
                        }
                        else
                        {
                            isWon = true;
                        }

                        break;
                }

                for (int bunnyRow = 0; bunnyRow < lair.GetLength(0); bunnyRow++)
                {
                    for (int bunnyCol = 0; bunnyCol < lair.GetLength(1); bunnyCol++)
                    {
                        if (lair[bunnyRow, bunnyCol] == 'B')
                        {
                            var bunnyTargetCoordinates = new int[4, 2];

                            bunnyTargetCoordinates[0, 0] = bunnyRow; // left
                            bunnyTargetCoordinates[0, 1] = bunnyCol - 1;
                            bunnyTargetCoordinates[1, 0] = bunnyRow; // right
                            bunnyTargetCoordinates[1, 1] = bunnyCol + 1;
                            bunnyTargetCoordinates[2, 0] = bunnyRow - 1; // up
                            bunnyTargetCoordinates[2, 1] = bunnyCol;
                            bunnyTargetCoordinates[3, 0] = bunnyRow + 1; // down
                            bunnyTargetCoordinates[3, 1] = bunnyCol;

                            for (int r = 0; r < bunnyTargetCoordinates.GetLength(0); r++)
                            {
                                if (IsInside(lair, bunnyTargetCoordinates[r, 0], bunnyTargetCoordinates[r, 1]))
                                {
                                    if (lair[bunnyTargetCoordinates[r, 0], bunnyTargetCoordinates[r, 1]] == '.')
                                    {
                                        lair[bunnyTargetCoordinates[r, 0], bunnyTargetCoordinates[r, 1]] = 'B';
                                    }

                                    if (lair[bunnyTargetCoordinates[r, 0], bunnyTargetCoordinates[r, 1]] == 'P')
                                    {
                                        isDead = true;
                                        lair[bunnyTargetCoordinates[r, 0], bunnyTargetCoordinates[r, 1]] = 'B';
                                    }
                                }

                            }
                        }
                    }
                }

                if (isWon || isDead)
                {
                    break;
                }
            }

            for (int r = 0; r < lair.GetLength(0); r++)
            {
                var outputRow = new StringBuilder();

                for (int c = 0; c < lair.GetLength(1); c++)
                {
                    outputRow.Append(lair[r, c]); 
                }

                Console.WriteLine(outputRow);
            }

            string output = string.Empty;

            if (isWon)
            {
                output = $"won: {playerRow} {playerCol}";
            }

            if (isDead)
            {
                output = $"dead: {playerRow} {playerCol}";
            }

        }

        private static bool IsInside(char[,] lair, int row, int col)
        {
            return row > -1 && row < lair.GetLength(0) &&
                col > -1 && col <lair.GetLength(1);
        }
    }
}
