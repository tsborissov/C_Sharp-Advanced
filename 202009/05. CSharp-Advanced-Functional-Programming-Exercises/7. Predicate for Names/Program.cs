using System;
using System.Linq;

namespace _7._Predicate_for_Names
{
    class Program
    {
        static void Main(string[] args)
        {
            int nameLength = int.Parse(Console.ReadLine());

            string[] names = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            Func<string, bool> lengthCheck = new Func<string, bool>(name => name.Length <= nameLength);

            Console.WriteLine(String.Join(Environment.NewLine, names
                .Where(lengthCheck)
                ));
        }
    }
}
