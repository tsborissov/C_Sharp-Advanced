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

            var wordsToCount = File.ReadAllLines(@"../../../Resources/words.txt")
                .ToDictionary(k => k, v => 0, StringComparer.InvariantCultureIgnoreCase);

            var textLines = File.ReadAllLines(@"../../../Resources/text.txt");

            var delimiters = new char[] { ' ', '-', ',', '.', '!', '?' };

            foreach (var line in textLines)
            {
                var lineWords = line
                    .Split(delimiters, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                foreach (var word in lineWords)
                {
                    if (wordsToCount.ContainsKey(word))
                    {
                        wordsToCount[word]++;
                    }
                }
            }

            var result = new List<string>();

            foreach (var pair in wordsToCount)
            {
                result.Add($"{pair.Key} - {pair.Value}");
            }

            File.WriteAllLines(@"../../../Resources/actualResult.txt", result);

            bool isExpectedResult = true;

            var expectedLines = File.ReadAllLines(@"../../../Resources/expectedResult.txt");

            var lineCounter = 0;

            foreach (var pair in wordsToCount.OrderByDescending(x => x.Value))
            {
                if (expectedLines[lineCounter] != $"{pair.Key} - {pair.Value}")
                {
                    isExpectedResult = false;
                    break;
                }

                lineCounter++;
            }
            
            Console.WriteLine(isExpectedResult);
        }
    }
}
