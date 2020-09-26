using System;
using System.Collections.Generic;
using System.Text;

namespace Problem_5._Count_Symbols
{
    class Program
    {
        static void Main(string[] args)
        {
            string textInput = Console.ReadLine();

            var symbols = new SortedDictionary<char, int>();

            for (int i = 0; i < textInput.Length; i++)
            {
                char symbol = textInput[i];
                
                if (!symbols.ContainsKey(symbol))
                {
                    symbols.Add(symbol, 0);
                }

                symbols[symbol]++;
            }

            StringBuilder output = new StringBuilder();

            foreach (var symbol in symbols)
            {
                output.Append($"{symbol.Key}: {symbol.Value} time/s");
                output.Append(Environment.NewLine);
            }

            Console.WriteLine(output.ToString());

        }
    }
}
