using System;
using System.IO;

namespace _1._Odd_Lines
{
    class Program
    {
        static void Main(string[] args)
        {

            using (var reader = new StreamReader("input.txt"))
            {
                var line = reader.ReadLine();

                int counter = 0;

                using (var writer = new StreamWriter("output.txt"))
                {
                    while (line != null)
                    {

                        if (counter % 2 == 1)
                        {
                            writer.WriteLine(line);
                        }

                        counter++;

                        line = reader.ReadLine();
                    }
                }
            }
        }
    }
}
