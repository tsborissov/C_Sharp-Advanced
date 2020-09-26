using System;
using System.Collections.Generic;

namespace Problem_4._Even_Times
{
    class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());

            Dictionary<double, int> numbers = new Dictionary<double, int>();

            for (int i = 0; i < n; i++)
            {
                double number = double.Parse(Console.ReadLine());

                if (!numbers.ContainsKey(number))
                {
                    numbers.Add(number, 0);
                }

                numbers[number]++;
            }

            double evenAppearingNumber = 0;

            foreach (var num in numbers)
            {
                if (num.Value % 2 == 0)
                {
                    evenAppearingNumber = num.Key;
                    break;
                }
            }

            Console.WriteLine(evenAppearingNumber);
        }
    }
}
