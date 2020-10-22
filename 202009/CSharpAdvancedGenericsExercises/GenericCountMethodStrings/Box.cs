using System;
using System.Collections.Generic;
using System.Text;

namespace GenericCountMethodStrings
{
    public class Box<T> where T : IComparable
    {
        public Box(List<T> collection)
        {
            this.Values = collection;
        }

        public List<T> Values { get; set; }

        public int CountGreaterElements(List<T> elements, T comparisonElement)
        {
            int largerCount = 0;

            foreach (var element in elements)
            {
                if (comparisonElement.CompareTo(element) < 0)
                {
                    largerCount++;
                }
            }

            return largerCount;
        }
    }
}
