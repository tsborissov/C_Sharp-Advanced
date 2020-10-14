using System;
using System.Collections.Generic;
using System.Text;

namespace CreateCustomDataStructures
{
    public class CustomStack
    {
        private const int DEFAULT_CAPACITY = 4;
        private int capacity;
        private int[] data;

        public CustomStack()
            : this(DEFAULT_CAPACITY)
        {
        }

        public CustomStack(int capacity)
        {
            this.capacity = capacity;
            this.data = new int[capacity];
        }

        public int Count { get; private set; }

        public void Push(int element)
        {
            if (this.Count == this.data.Length)
            {
                Resize();

            }
            
            this.data[this.Count] = element;

            this.Count++;
        }

        public int Pop()
        {
            this.ValidateEmptyStack();

            int result = this.data[this.Count - 1];

            this.Count--;
            
            return result;
        }


        public void ForEach(Action<int> action)
        {
            for (int i = this.Count - 1; i >= 0 ; i--)
            {
                action(this.data[i]);
            }
        }

        public int Peek()
        {
            this.ValidateEmptyStack();

            int result = this.data[this.Count - 1];

            return result;
        }

        public void Clear()
        {
            this.Count = 0;
            this.data = new int[this.capacity];
        }

        private void Resize()
        {
            int newCapacity = this.data.Length * 2;

            int[] newData = new int[newCapacity];

            for (int i = 0; i < this.data.Length; i++)
            {
                newData[i] = data[i];
            }

            this.data = newData;
        }

        private void ValidateEmptyStack()
        {
            if (this.Count == 0)
            {
                throw new Exception("Stack is Empty.");
            }
        }


    }
}
