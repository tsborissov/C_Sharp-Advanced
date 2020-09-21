using System;

namespace _7._Knight_Game_v2
{
    class Program
    {
        static void Main(string[] args)
        {

            int size = int.Parse(Console.ReadLine());

            char[,] board = new char[size, size];

            for (int i = 0; i < size; i++)
            {
                string boardRow = Console.ReadLine();

                for (int j = 0; j < size; j++)
                {
                    board[i, j] = boardRow[j];
                }
            }


            int knightRemoveCounter = 0;


            while (true)
            {
                int maxAttacksCount = 0;
                int killerRow = -1;
                int killerCol = -1;

                int[,] coordinates = new int[8, 2];



                for (int row = 0; row < board.GetLength(0); row++)
                {

                    for (int col = 0; col < board.GetLength(1); col++)
                    {

                        coordinates[0, 0] = coordinates[1, 0] = row - 2;
                        coordinates[2, 0] = coordinates[3, 0] = row - 1;
                        coordinates[4, 0] = coordinates[5, 0] = row + 1;
                        coordinates[6, 0] = coordinates[7, 0] = row + 2;
                        coordinates[2, 1] = coordinates[4, 1] = col - 2;
                        coordinates[0, 1] = coordinates[6, 1] = col - 1;
                        coordinates[1, 1] = coordinates[7, 1] = col + 1;
                        coordinates[3, 1] = coordinates[5, 1] = col + 2;

                         
                        int currentAttackCount = 0;

                        if (board[row, col] == 'K')
                        {
                            for (int r = 0; r < coordinates.GetLength(0); r++)
                            {
                                int targetRow = coordinates[r, 0];
                                int targetCol = coordinates[r, 1];

                                if (IsInside(board, targetRow, targetCol) && board[targetRow, targetCol] == 'K')
                                {
                                    currentAttackCount++;
                                }

                            }
                            
                        }

                        if (currentAttackCount > maxAttacksCount)
                        {
                            maxAttacksCount = currentAttackCount;
                            killerRow = row;
                            killerCol = col;
                        }
                    }
                }

                if (maxAttacksCount > 0)
                {
                    board[killerRow, killerCol] = '0';
                    knightRemoveCounter++;
                }
                else
                {
                    Console.WriteLine(knightRemoveCounter);
                    break;
                }
            }
        }

        private static bool IsInside(char[,] board, int row, int col)
        {
            return row >= 0 && row < board.GetLength(0) &&
            col >= 0 && col < board.GetLength(1);
        }
    }
}
