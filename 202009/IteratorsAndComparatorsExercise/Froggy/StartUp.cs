using System;
using System.Linq;
using System.Text;

namespace Froggy
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var stones = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var lake = new Lake(stones);

            Console.WriteLine(string.Join(", ", lake));

            //var sb = new StringBuilder();

            //foreach (var stone in lake)
            //{
            //    sb.Append($"{stone}, ");
            //}

            //Console.WriteLine(sb.ToString().TrimEnd(' ', ','));
        }
    }
}
