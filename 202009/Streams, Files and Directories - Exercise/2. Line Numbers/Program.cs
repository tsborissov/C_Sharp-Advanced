using System;
using System.IO;

namespace _2._Line_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {

            string[] textLines = File.ReadAllLines(@"../../../text.txt");

            for (int i = 0; i < textLines.Length; i++)
            {
                int lettersCounter = 0;
                int punctuationMarksCounter = 0;

                string currentLine = textLines[i];

                for (int j = 0; j < currentLine.Length; j++)
                {
                    if (char.IsPunctuation(currentLine[j]))
                    {
                        punctuationMarksCounter++;
                    }
                    else if (char.IsLetterOrDigit(currentLine[j]))
                    {
                        lettersCounter++;
                    }
                }

                textLines[i] = $"Line {i + 1}: {currentLine} ({lettersCounter})({punctuationMarksCounter})";
            }

            File.WriteAllLines(@"../../../output.txt", textLines);

        }
    }
}
