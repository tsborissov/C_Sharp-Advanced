using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _3._Word_Count
{
    class Program
    {
        static void Main(string[] args)
        {
            var words = new Dictionary<string, int>(StringComparer.InvariantCultureIgnoreCase);

            using (var wordsReader = new StreamReader("words.txt"))
            {
                while (true)
                {
                    string wordsLine = wordsReader.ReadLine();
                    if (wordsLine == null)
                    {
                        break;
                    }

                    string[] wordsArr = wordsLine
                        .Split()
                        .ToArray();

                    foreach (var item in wordsArr)
                    {
                        if (!words.ContainsKey(item))
                        {
                            words.Add(item, 0);
                        }
                    }
                }
            }

            char[] delimiters = new char[] { ' ', ',', '.', '!', '-', '?' , ':' , };

            using (var textReader = new StreamReader("input.txt"))
            {
                while (true)
                {
                    string textLine = textReader.ReadLine();
                    if (textLine == null)
                    {
                        break;
                    }

                    string[] textArr = textLine
                        .Split(delimiters, StringSplitOptions.RemoveEmptyEntries)
                        .ToArray();

                    foreach (var item in textArr)
                    {
                        if (words.ContainsKey(item))
                        {
                            words[item]++;
                        }
                    }
                }
            }

            using (var outputWriter = new StreamWriter("Output.txt"))
            {
                foreach (var item in words.OrderByDescending(x => x.Value))
                {
                    outputWriter.WriteLine($"{item.Key} - {item.Value}");
                }
            }
        }
    }
}
