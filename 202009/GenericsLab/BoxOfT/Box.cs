using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace BoxOfT
{
    public class Box<T>
    {
        private Stack<T> data;

        public Box()
        {
            data = new Stack<T>();
        }


        public int Count
        {
            get { return this.data.Count; }
        }

        public void Add(T element)
        {
            data.Push(element);
        }

        public T Remove()
        {
            return data.Pop();
        }
    }
}
