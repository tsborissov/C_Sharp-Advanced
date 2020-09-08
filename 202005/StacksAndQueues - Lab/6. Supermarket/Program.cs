using System;
using System.Collections.Generic;

namespace _6._Supermarket
{
    class Program
    {
        static void Main(string[] args)
        {

            var supermarketQueue = new Queue<string>();

            string output = string.Empty;

            while (true)
            {
                string input = Console.ReadLine();
                if (input.ToLower() == "end")
                {
                    break;
                }
                else if (input.ToLower() == "paid")
                {
                    output = string.Join(Environment.NewLine, supermarketQueue.ToArray());
                    supermarketQueue.Clear();
                }
                else
                {
                    supermarketQueue.Enqueue(input);
                }
            }

            if (output.Length > 0)
            {
                Console.WriteLine(output);
            }

            Console.WriteLine($"{supermarketQueue.Count} people remaining.");

        }
    }
}
