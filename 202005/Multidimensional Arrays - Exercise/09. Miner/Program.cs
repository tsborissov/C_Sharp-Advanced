using System;
using System.Collections.Generic;
using System.Linq;

namespace _09._Miner
{
    class Program
    {
        static void Main(string[] args)
        {

            int size = int.Parse(Console.ReadLine());
            var commands = new Queue<string> (Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries));

            var field = new char[size, size];
            int[] allCoalCounter = new int[1] { 0 };
            int currentRow = -1;
            int currentCol = -1;

            for (int r = 0; r < field.GetLength(0); r++)
            {
                string input = Console.ReadLine();
                char[] inputRow = input.Split().Select(char.Parse).ToArray();

                for (int c = 0; c < field.GetLength(1); c++)
                {
                    field[r, c] = inputRow[c];

                    if (inputRow[c] == 'c')
                    {
                        allCoalCounter[0]++;
                    }

                    if (inputRow[c] == 's')
                    {
                        currentRow = r;
                        currentCol = c;
                    }
                }
            }

            int[] collectedCoalCounter = new int[1] { 0 };
            bool isRouteEnd = false;


            while (commands.Count > 0)
            {
                string currentCommand = commands.Dequeue();

                int targetRow = -1;
                int targetCol = -1;

                switch (currentCommand)
                {
                    case "up":

                        targetRow = currentRow - 1;
                        targetCol = currentCol;

                        if (IsInside(field, targetRow, targetCol))
                        {
                            currentRow = targetRow;
                            currentCol = targetCol;

                            isRouteEnd = TargetAction(field, currentRow, currentCol, collectedCoalCounter, allCoalCounter);

                        }

                        break;

                    case "down":

                        targetRow = currentRow + 1;
                        targetCol = currentCol;

                        if (IsInside(field, targetRow, targetCol))
                        {
                            currentRow = targetRow;
                            currentCol = targetCol;

                            isRouteEnd = TargetAction(field, currentRow, currentCol, collectedCoalCounter, allCoalCounter);

                        }

                        break;

                    case "left":

                        targetRow = currentRow;
                        targetCol = currentCol - 1;

                        if (IsInside(field, targetRow, targetCol))
                        {
                            currentRow = targetRow;
                            currentCol = targetCol;

                            isRouteEnd = TargetAction(field, currentRow, currentCol, collectedCoalCounter, allCoalCounter);
                        }

                        break;

                    case "right":

                        targetRow = currentRow;
                        targetCol = currentCol + 1;

                        if (IsInside(field, targetRow, targetCol))
                        {
                            currentRow = targetRow;
                            currentCol = targetCol;

                            isRouteEnd = TargetAction(field, currentRow, currentCol, collectedCoalCounter, allCoalCounter);
                        }

                        break;
                }

                if (allCoalCounter[0] == 0)
                {
                    break;
                }

                if (isRouteEnd)
                {
                    break;
                }
            }

            string output = $"{allCoalCounter[0]} coals left. ({currentRow}, {currentCol})";

            if (allCoalCounter[0] == 0)
            {
                output = $"You collected all coals! ({currentRow}, {currentCol})";
            }

            if (isRouteEnd)
            {
                output = $"Game over! ({currentRow}, {currentCol})";
            }

            Console.WriteLine(output);

        }

        private static bool TargetAction(char[,] field, int currentRow, int currentCol, int[] collectedCoalCounter, int[] allCoalCounter)
        {
            bool isRouteEnd = false;
            
            if (field[currentRow, currentCol] == 'c')
            {
                field[currentRow, currentCol] = '*';
                collectedCoalCounter[0]++;
                allCoalCounter[0]--;
            }
            else if (field[currentRow, currentCol] == 'e')
            {
                isRouteEnd = true;
            }

            return isRouteEnd;
        }

        private static bool IsInside(char[,] field, int row, int col)
        {
            return row > -1 && row < field.GetLength(0) && col > -1 && col < field.GetLength(1);
        }
    }
}
