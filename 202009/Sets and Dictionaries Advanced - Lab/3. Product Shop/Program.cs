using System;
using System.Collections.Generic;

namespace _3._Product_Shop
{
    class Program
    {
        static void Main(string[] args)
        {

            var foodShops = new SortedDictionary<string, Dictionary<string, double>>();

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Revision")
                {
                    break;
                }

                string[] tokens = input.Split(", ", StringSplitOptions.RemoveEmptyEntries);

                string shop = tokens[0];
                string product = tokens[1];
                double price = double.Parse(tokens[2]);

                if (!foodShops.ContainsKey(shop))
                {
                    foodShops[shop] = new Dictionary<string, double>();
                }

                foodShops[shop][product] = price;
            }

            foreach (var shop in foodShops)
            {
                Console.WriteLine($"{shop.Key}->");

                foreach (var product in shop.Value)
                {
                    Console.WriteLine($"Product: {product.Key}, Price: {product.Value}");
                }
            }

        }
    }
}
