using System;
using System.Collections.Generic;

namespace GenericCountMethodDoubles
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<double> inputElements = new List<double>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                double currentElement = double.Parse(Console.ReadLine());

                inputElements.Add(currentElement);
            }

            Box<double> box = new Box<double>(inputElements);

            double comparatorElement = double.Parse(Console.ReadLine());

            int greaterElementsCount = box.CountGreaterElements(box.Elements, comparatorElement);

            Console.WriteLine(greaterElementsCount);
        }
    }
}
