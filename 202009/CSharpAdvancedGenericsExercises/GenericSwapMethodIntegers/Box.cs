using System;
using System.Collections.Generic;
using System.Text;

namespace GenericSwapMethodIntegers
{
    public class Box<T>
    {
        public Box(List<T> collection)
        {
            this.Values = collection;       
        }
        
        public List<T> Values { get; set; }


        public void Swap(List<T> collection, int firstIndex, int secondIndex)
        {
            T swapBuffer = collection[firstIndex];
            collection[firstIndex] = collection[secondIndex];
            collection[secondIndex] = swapBuffer;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var item in this.Values)
            {
                sb.AppendLine($"{item.GetType()}: {item}");
            }
            
            return sb.ToString().TrimEnd();
        }
    }
}
