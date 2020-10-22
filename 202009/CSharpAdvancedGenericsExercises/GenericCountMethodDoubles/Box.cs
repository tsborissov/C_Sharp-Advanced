using System;
using System.Collections.Generic;
using System.Text;

namespace GenericCountMethodDoubles
{
    public class Box<T> where T : IComparable
    {
        public Box(List<T> elements)
        {
            this.Elements = elements;
        }
        
        public List<T> Elements { get; set; }

        public int CountGreaterElements(List<T> elements, T elementToCompare)
        {
            int counter = 0;

            foreach (var element in elements)
            {
                if (elementToCompare.CompareTo(element) < 0)
                {
                    counter++;
                }
            }

            return counter;
        }
    }
}
