using System;
using System.IO;

namespace StreamsDemo
{
    class Program
    {
        static void Main(string[] args)
        {

            StreamWriter writer = new StreamWriter("StreamsDemo.txt");

            using (writer)
            {
                for (int i = 1; i <= 20; i++)
                {
                    writer.WriteLine(i);
                }
            }


            StreamReader reader = new StreamReader("StreamsDemo.txt");

            using (reader)
            {
                while (true)
                {
                    string line = reader.ReadLine();
                    if (line == null)
                    {
                        Console.WriteLine("End Of File!");
                        break;
                    }

                    Console.WriteLine(line);
                }
            }
        }
    }
}
