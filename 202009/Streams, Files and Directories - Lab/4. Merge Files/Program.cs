using System;
using System.IO;

namespace _4._Merge_Files
{
    class Program
    {
        static void Main(string[] args)
        {
            using var firstReader = new StreamReader("Input1.txt");
            using var secondReader = new StreamReader("Input2.txt");
            using var outputWriter = new StreamWriter("Output.txt");

            while (true)
            {
                string firstInput = firstReader.ReadLine();
                string secondInput = secondReader.ReadLine();

                if (firstInput == null && secondInput == null)
                {
                    break;
                }

                if (firstInput != null)
                {
                    outputWriter.WriteLine(firstInput);
                }

                if (secondInput != null)
                {
                    outputWriter.WriteLine(secondInput);
                }
            }
        }
    }
}
