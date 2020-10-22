using System;
using System.Collections.Generic;

namespace GenericCountMethodStrings
{
    public 
        class StartUp
    {
        static void Main(string[] args)
        {
            List<string> inputList = new List<string>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                inputList.Add(Console.ReadLine());
            }

            Box<string> box = new Box<string>(inputList);

            string comparisonElement = Console.ReadLine();

            Console.WriteLine(box.CountGreaterElements(inputList, comparisonElement));

        }
    }
}
