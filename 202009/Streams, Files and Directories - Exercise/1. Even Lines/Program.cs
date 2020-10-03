using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _1._Even_Lines
{
    class Program
    {
        static void Main(string[] args)
        {

            using var reader = new StreamReader("../../../text.txt");

            int rowNr = 0;
            var output = new StringBuilder();

            while (!reader.EndOfStream)
            {
                string input = reader.ReadLine();
                
                string[] currentRow = input
                    .Split()
                    .ToArray();

                if (rowNr % 2 == 0)
                {
                    currentRow = currentRow.Reverse().ToArray();

                    output.AppendLine(string.Join(' ', currentRow));
                }

                rowNr++;
            }

            string pattern = @"[-,.?!]";
            Regex regex = new Regex(pattern);
            string result = output.ToString();

            result = regex.Replace(result, "@");

            //char[] charsToReplace = new char[] { '-', ',', '.', '!', '?' };

            //foreach (var currentChar in charsToReplace)
            //{
            //    output.Replace(currentChar, '@');
            //}

            Console.WriteLine(result);
        }
    }
}
