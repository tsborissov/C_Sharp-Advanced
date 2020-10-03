using System;
using System.Linq;

namespace _4._Add_VAT
{
    class Program
    {
        static void Main(string[] args)
        {

            Func<double, double> addVat = p => p * 1.2;

            double[] prices = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .Select(addVat)
                .ToArray();

            foreach (var price in prices)
            {
                Console.WriteLine($"{price:F2}");
            }
        }
    }
}
