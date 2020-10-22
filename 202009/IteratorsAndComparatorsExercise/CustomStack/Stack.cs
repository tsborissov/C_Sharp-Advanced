using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustomStack
{
    class Stack<T> : IEnumerable<T>
    {
        private int index;
        private List<T> data;

        public Stack()
        {
            data = new List<T>();
            this.index = this.data.Count - 1;
        }

        public void Push(params T[] collection)
        {
            this.data.AddRange(collection);
        }

        public T Pop()
        {
            if (!this.data.Any())
            {
                throw new Exception("No elements");
            }

            T result = this.data[this.data.Count - 1];
            this.data.RemoveAt(this.data.Count - 1);

            return result;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = this.data.Count - 1; i >= 0; i--)
            {
                yield return this.data[i];
            }

        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
