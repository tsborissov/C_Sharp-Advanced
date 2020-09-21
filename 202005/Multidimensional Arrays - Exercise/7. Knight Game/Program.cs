using System;

namespace _7._Knight_Game
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

                for (int row = 0; row < size; row++)
                {

                    for (int col = 0; col < size; col++)
                    {

                        int currentAttackCount = 0;

                        if (board[row, col] == 'K')
                        {
                            if (IsInside(board, row - 1, col - 2) && board[row - 1, col - 2] == 'K')
                            {
                                currentAttackCount++;
                            }

                            if (IsInside(board, row - 1, col + 2) && board[row - 1, col + 2] == 'K')
                            {
                                currentAttackCount++;
                            }

                            if (IsInside(board, row - 2, col - 1) && board[row - 2, col - 1] == 'K')
                            {
                                currentAttackCount++;
                            }

                            if (IsInside(board, row - 2, col + 1) && board[row - 2, col + 1] == 'K')
                            {
                                currentAttackCount++;
                            }

                            if (IsInside(board, row + 1, col - 2) && board[row + 1, col - 2] == 'K')
                            {
                                currentAttackCount++;
                            }

                            if (IsInside(board, row + 1, col + 2) && board[row + 1, col + 2] == 'K')
                            {
                                currentAttackCount++;
                            }

                            if (IsInside(board, row + 2, col - 1) && board[row + 2, col - 1] == 'K')
                            {
                                currentAttackCount++;
                            }

                            if (IsInside(board, row + 2, col + 1) && board[row + 2, col + 1] == 'K')
                            {
                                currentAttackCount++;
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
