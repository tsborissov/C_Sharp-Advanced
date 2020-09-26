using System;
using System.IO;

namespace _2._Line_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            
            using (var reader = new StreamReader("input.txt"))
            {
                using (var writer = new StreamWriter("output.txt"))
                {
                    int rowNrs = 1;

                    while (true)
                    {
                        string line = reader.ReadLine();
                        if (line == null)
                        {
                            break;
                        }

                        writer.WriteLine($"{rowNrs}. {line}");

                        rowNrs++;
                    }
                }
            }
        }
    }
}
