using System;

namespace EnumeratorsDemo
{
    public class StartUp
    {
        static void Main(string[] args)
        {

            Numbers numbers = new Numbers(new int[] { 1, 2, 3, 4, 5 });

            int sum = 0;

            foreach (var number in numbers)
            {
                sum += number;
            }

            Console.WriteLine(sum);
        }
    }
}
