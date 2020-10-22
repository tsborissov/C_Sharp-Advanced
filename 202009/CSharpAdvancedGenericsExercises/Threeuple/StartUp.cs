using System;

namespace Threeuple
{
    public class StartUp
    {
        static void Main(string[] args)
        {

            string[] firstInput = Console.ReadLine().Split();

            string name = $"{firstInput[0]} {firstInput[1]}";
            string address = firstInput[2];
            string town = string.Empty;


            if (firstInput.Length == 4)
            {
                town = firstInput[3];
            }
            else if (firstInput.Length == 5)
            {
                town = $"{firstInput[3]} {firstInput[4]}";
            }

            

            Threeuple<string, string, string> firstThreeuple
                = new Threeuple<string, string, string>(name, address, town);

            string[] secondInput = Console.ReadLine().Split();

            name = secondInput[0];
            int litersOfBeer = int.Parse(secondInput[1]);

            bool drunkOrNot = secondInput[2] == "drunk" ? true : false;
            

            Threeuple<string, int, bool> secondThreeuple
                = new Threeuple<string, int, bool>(name, litersOfBeer, drunkOrNot);

            string[] thirdInput = Console.ReadLine().Split();

            name = thirdInput[0];
            double accountBallance = double.Parse(thirdInput[1]);
            string bankName = thirdInput[2];

            Threeuple<string, double, string> thirdThreeuple
                = new Threeuple<string, double, string>(name, accountBallance, bankName);

            Console.WriteLine(firstThreeuple);
            Console.WriteLine(secondThreeuple);
            Console.WriteLine(thirdThreeuple);

        }
    }
}
