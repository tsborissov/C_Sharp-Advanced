using System;
using System.Collections.Generic;
using System.Text;

namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            char[,] territory = new char[size, size];

            Snake snake = new Snake();
            snake.BurrowRow = new List<int>();
            snake.BurrowCol = new List<int>();

            for (int i = 0; i < territory.GetLength(0); i++)
            {
                char[] currentRow = Console.ReadLine().ToCharArray();

                for (int j = 0; j < territory.GetLength(1); j++)
                {
                    territory[i, j] = currentRow[j];
                    if (currentRow[j] == 'S')
                    {
                        snake.SnakeRow = i;
                        snake.SnakeCol = j;
                    }
                    else if (currentRow[j] == 'B')
                    {
                        snake.BurrowRow.Add(i);
                        snake.BurrowCol.Add(j);
                    }
                }
            }

            bool isInside = true;
            snake.FoodQuantity = 0;

            while (true)
            {
                if (snake.FoodQuantity >= 10 || !isInside)
                {
                    break;
                }

                string command = Console.ReadLine();

                int targetRow = -1;
                int targetCol = -1;

                if (command == "up")
                {
                    targetRow = snake.SnakeRow - 1;
                    targetCol = snake.SnakeCol;

                    isInside = CheckTarget(territory, targetRow, targetCol, snake);

                    if (isInside)
                    {
                        Move(territory, targetRow, targetCol, snake);
                    }
                }
                else if (command == "down")
                {
                    targetRow = snake.SnakeRow + 1;
                    targetCol = snake.SnakeCol;

                    isInside = CheckTarget(territory, targetRow, targetCol, snake);

                    if (isInside)
                    {
                        Move(territory, targetRow, targetCol, snake);
                    }
                }
                else if (command == "left")
                {
                    targetRow = snake.SnakeRow;
                    targetCol = snake.SnakeCol - 1;

                    isInside = CheckTarget(territory, targetRow, targetCol, snake);

                    if (isInside)
                    {
                        Move(territory, targetRow, targetCol, snake);
                    }
                }
                else if (command == "right")
                {
                    targetRow = snake.SnakeRow;
                    targetCol = snake.SnakeCol + 1;

                    isInside = CheckTarget(territory, targetRow, targetCol, snake);

                    if (isInside)
                    {
                        Move(territory, targetRow, targetCol, snake);
                    }
                }
            }

            StringBuilder sb = new StringBuilder();

            if (!isInside)
            {
                sb.AppendLine("Game over!");
            }
            else
            {
                sb.AppendLine("You won! You fed the snake.");
            }

            sb.AppendLine($"Food eaten: {snake.FoodQuantity}");

            for (int i = 0; i < territory.GetLength(0); i++)
            {
                for (int j = 0; j < territory.GetLength(1); j++)
                {
                    sb.Append(territory[i, j]);
                }

                sb.AppendLine();
            }

            Console.WriteLine(sb.ToString().TrimEnd());
        }

        private static void Move(char[,] territory, int targetRow, int targetCol, Snake snake)
        {
            territory[snake.SnakeRow, snake.SnakeCol] = '.';

            snake.SnakeRow = targetRow;
            snake.SnakeCol = targetCol;

            if (territory[snake.SnakeRow, snake.SnakeCol] == '*')
            {
                snake.FoodQuantity++;
            }
            else if (territory[snake.SnakeRow, snake.SnakeCol] == 'B')
            {
                territory[snake.SnakeRow, snake.SnakeCol] = '.';

                if (snake.SnakeRow == snake.BurrowRow[0] && snake.SnakeCol == snake.BurrowCol[0])
                {
                    snake.SnakeRow = snake.BurrowRow[1];
                    snake.SnakeCol = snake.BurrowCol[1];
                }
                else
                {
                    snake.SnakeRow = snake.BurrowRow[0];
                    snake.SnakeCol = snake.BurrowCol[0];
                }
            }

            territory[snake.SnakeRow, snake.SnakeCol] = 'S';
        }

        public static bool CheckTarget(char[,] territory, int targetRow, int targetCol, Snake snake)
        {
            bool isInside = targetRow > -1 &&
                targetRow < territory.GetLength(0) &&
                targetCol > -1 &&
                targetCol < territory.GetLength(1);

            if (!isInside)
            {
                territory[snake.SnakeRow, snake.SnakeCol] = '.';
            }

            return isInside;
        }
    }

    public class Snake
    {
        public int SnakeRow { get; set; }
        public int SnakeCol { get; set; }
        public int FoodQuantity { get; set; }
        public List<int> BurrowRow { get; set; }
        public List<int> BurrowCol { get; set; }
    }
}
