using System;
using System.Text;

namespace Bee
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] beeTerritory = new char[n, n];

            int initialBeeRow = -1;
            int initialBeeCol = -1;

            for (int i = 0; i < beeTerritory.GetLength(0); i++)
            {
                char[] currentRow = Console.ReadLine().ToCharArray();

                for (int j = 0; j < beeTerritory.GetLength(1); j++)
                {
                    beeTerritory[i, j] = currentRow[j];

                    if (currentRow[j] == 'B')
                    {
                        initialBeeRow = i;
                        initialBeeCol = j;
                    }
                }
            }

            Bee bee = new Bee(initialBeeRow, initialBeeCol);

            int polinatedFlowersNeeded = 5;
            bool isInside = true;

            while (true)
            {
                string command = Console.ReadLine(); // "up", "down", "left", "right", "End"

                if (command == "End" || !isInside)
                {
                    break;
                }

                int targetRow = -1;
                int targetCol = -1;
                

                if (command == "up")
                {
                    targetRow = bee.Row - 1;
                    targetCol = bee.Col;

                    isInside = CheckTarget(beeTerritory, bee, targetRow, targetCol);

                    if (isInside)
                    {
                        Move(beeTerritory, bee, targetRow, targetCol);
                    }

                }
                else if (command == "down")
                {
                    targetRow = bee.Row + 1;
                    targetCol = bee.Col;

                    isInside = CheckTarget(beeTerritory, bee, targetRow, targetCol);

                    if (isInside)
                    {
                        Move(beeTerritory, bee, targetRow, targetCol);
                    }

                }
                else if (command == "left")
                {
                    targetRow = bee.Row;
                    targetCol = bee.Col - 1;

                    isInside = CheckTarget(beeTerritory, bee, targetRow, targetCol);

                    if (isInside)
                    {
                        Move(beeTerritory, bee, targetRow, targetCol);
                    }
                }
                else if (command == "right")
                {
                    targetRow = bee.Row;
                    targetCol = bee.Col + 1;

                    isInside = CheckTarget(beeTerritory, bee, targetRow, targetCol);

                    if (isInside)
                    {
                        Move(beeTerritory, bee, targetRow, targetCol);
                    }
                }
            }

            StringBuilder result = new StringBuilder();

            if (!isInside)
            {
                result.AppendLine("The bee got lost!");
            }
            
            if (bee.PolinatedFlowersCounter < polinatedFlowersNeeded)
            {
                result.AppendLine($"The bee couldn't pollinate the flowers, she needed {polinatedFlowersNeeded - bee.PolinatedFlowersCounter} flowers more");
            }
            else
            {
                result.AppendLine($"Great job, the bee managed to pollinate {bee.PolinatedFlowersCounter} flowers!");
            }

            for (int i = 0; i < beeTerritory.GetLength(0); i++)
            {
                for (int j = 0; j < beeTerritory.GetLength(1); j++)
                {
                    result.Append(beeTerritory[i, j]);
                }

                result.AppendLine();
            }

            Console.WriteLine(result.ToString().TrimEnd());
        }

        private static void Move(char[,] beeTerritory, Bee bee, int targetRow, int targetCol)
        {
            beeTerritory[bee.Row, bee.Col] = '.';

            if (beeTerritory[targetRow, targetCol] == 'f')
            {
                bee.PolinatedFlowersCounter++;
                bee.Row = targetRow;
                bee.Col = targetCol;
            }
            else if (beeTerritory[targetRow, targetCol] == 'O')
            {
                beeTerritory[targetRow, targetCol] = '.';

                int forwardRow = targetRow - bee.Row;
                int forwardCol = targetCol - bee.Col;

                bee.Row = targetRow + forwardRow;
                bee.Col = targetCol + forwardCol;

                if (beeTerritory[bee.Row, bee.Col] == 'f')
                {
                    bee.PolinatedFlowersCounter++;
                }
            }
            else
            {
                bee.Row = targetRow;
                bee.Col = targetCol;
            }

            beeTerritory[bee.Row, bee.Col] = 'B';
        }

        public static bool CheckTarget(char[,] beeTerritory, Bee bee, int targetRow, int targetCol)
        {
            bool isInside = targetRow > -1 && targetRow < beeTerritory.GetLength(0) &&
                targetCol > -1 && targetCol < beeTerritory.GetLength(1);

            if (!isInside)
            {
                beeTerritory[bee.Row, bee.Col] = '.';
            }

            return isInside;
        }
    }

    public class Bee
    {
        public Bee(int beeRow, int beeCol)
        {
            Row = beeRow;
            Col = beeCol;
            this.PolinatedFlowersCounter = 0;
        }

        public int Row { get; set; }
        public int Col { get; set; }
        public int PolinatedFlowersCounter { get; set; }
    }
}
