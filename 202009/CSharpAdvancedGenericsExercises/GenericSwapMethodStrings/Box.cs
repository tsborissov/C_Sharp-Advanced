using System.Collections.Generic;
using System.Text;

namespace GenericSwapMethodStrings
{
    public class Box<T>
    {
        public List<T> Values { get; set; }

        public Box(List<T> values)
        {
            this.Values = values;
        }

        public void Swap(List<T> collection, int firstIndex, int secondIndex)
        {
            T swapBuffer = collection[firstIndex];
            this.Values[firstIndex] = collection[secondIndex];
            this.Values[secondIndex] = swapBuffer;
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
