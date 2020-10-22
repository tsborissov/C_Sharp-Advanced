using System;
using System.Linq;

namespace Tuple
{
    public class StartUp
    {
        static void Main(string[] args)
        {

            string[] firstInput = Console.ReadLine().Split().ToArray();

            string name = $"{firstInput[0]} {firstInput[1]}";
            string address = firstInput[2];

            Tuple<string, string> firstTuple = new Tuple<string, string>(name, address);

            string[] secondInput = Console.ReadLine().Split().ToArray();

            name = secondInput[0];
            int beerLiters = int.Parse(secondInput[1]);

            Tuple<string, int> secondTuple = new Tuple<string, int>(name, beerLiters);

            string[] thirdInput = Console.ReadLine().Split().ToArray();

            int someInteger = int.Parse(thirdInput[0]);
            double someDouble = double.Parse(thirdInput[1]);

            Tuple<int, double> thirdTuple = new Tuple<int, double>(someInteger, someDouble);

            Console.WriteLine(firstTuple);
            Console.WriteLine(secondTuple);
            Console.WriteLine(thirdTuple);

        }
    }
}
