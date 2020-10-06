using System;
using System.Linq;

namespace _1._Action_Point
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string[]> printAction = (items) => Console.WriteLine(String.Join(Environment.NewLine, items));

            string[] names = Console
                .ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            printAction(names);
        }
    }
}
