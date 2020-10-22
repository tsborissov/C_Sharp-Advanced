using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ListyIterator
{
    class ListyIterator<T> : IEnumerable<T>
    {
        private List<T> data;
        private int index;

        public ListyIterator(List<T> collection)
        {
            this.data = collection;
            this.index = 0;
        }

        public bool Move()
        {
            bool hasNext = this.HasNext();
            
            if (hasNext)
            {
                index++;
            }

            return hasNext;
        }

        public bool HasNext()
        {
            if (index + 1 < this.data.Count)
            {
                return true;
            }
            return false;
        }

        public void Print()
        {
            if (!this.data.Any())
            {
                throw new InvalidOperationException("Invalid Operation!");
            }
            
                Console.WriteLine(this.data[index]);
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var element in data)
            {
                yield return element;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
