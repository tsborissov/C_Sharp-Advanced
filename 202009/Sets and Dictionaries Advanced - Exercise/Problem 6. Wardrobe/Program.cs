using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem_6._Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());

            var wardrobe = new Dictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();

                string[] tokens = input.Split(" -> ").ToArray();
                string color = tokens[0];
                string[] clothesInput = tokens[1].Split(',').ToArray();

                if (!wardrobe.ContainsKey(color))
                {
                    wardrobe.Add(color, new Dictionary<string, int>());
                }

                for (int j = 0; j < clothesInput.Length; j++)
                {
                    string currentClothes = clothesInput[j];
                    
                    if (!wardrobe[color].ContainsKey(currentClothes))
                    {
                        wardrobe[color].Add(currentClothes, 0);
                    }

                    wardrobe[color][currentClothes]++;
                }
            }

            string[] searchTokens = Console.ReadLine().Split().ToArray();

            string searchColor = searchTokens[0];
            string searchClothes = searchTokens[1];

            StringBuilder output = new StringBuilder();

            foreach (var (color, clothes) in wardrobe)
            {
                output.Append($"{color} clothes:");
                output.Append(Environment.NewLine);

                foreach (var (clothing, count) in clothes)
                {
                    output.Append($"* {clothing} - {count}");

                    if (color == searchColor && clothing == searchClothes)
                    {
                        output.Append(" (found!)");
                    }

                    output.Append(Environment.NewLine);
                }

            }
            Console.WriteLine(output);
        }
    }
}
