using System;


namespace CreateCustomDataStructures
{
    public class CustomList
    {
        private const int DefaultCapacity = 2;
        private int capacity;
        private int[] data;

        public CustomList()
            : this (DefaultCapacity)
        {
        }

        public CustomList(int capacity)
        {
            this.capacity = capacity;
            this.data = new int[capacity];
        }

        public int Count { get; private set; }

        public int this[int index]
        {
            get
            {
                this.ValidateIndex(index);

                return this.data[index];
            }
            set
            {
                this.ValidateIndex(index);

                data[index] = value;
            }
        }

        public void Clear()
        {
            this.Count = 0;
            this.data = new int[capacity];
        }

        public void Add(int element) // Adds the given element to the end of the list
        {
            if (this.Count == this.data.Length)
            {
                this.Resize();
            }
            
            this.data[this.Count] = element;
            this.Count++;
        }

        public void Insert(int index, int element)
        {
            this.ValidateIndex(index);

            if (this.Count == this.data.Length)
            {
                Resize();
            }

            for (int i = this.Count; i > index; i--)
            {
                this.data[i] = this.data[i - 1];
            }

            this.data[index] = element;

            this.Count++;
        }

        public int RemoveAt(int index) // Removes the element at the given index
        {
            this.ValidateIndex(index);

            int result = data[index];

            for (int i = index + 1; i < this.Count; i++)
            {
                this.data[i - 1] = this.data[i];
            }

            this.Count--;

            return result;
        }

        public bool Contains(int element) // Checks if the list contains the given element returns (True or False)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (data[i] == element)
                {
                    return true;
                }
            }
            
            return false;
        }

        public void Swap(int firstIndex, int secondIndex) // Swaps the elements at the given indexes
        {
            this.ValidateIndex(firstIndex);
            this.ValidateIndex(secondIndex);

            int tempData = this.data[firstIndex];
            this.data[firstIndex] = this.data[secondIndex];
            this.data[secondIndex] = tempData;
        }

        private void Resize() // this method will be used to increase the internal collection's length twice
        {
            var newCapacity = this.data.Length * 2;

            var newData = new int[newCapacity];

            for (int i = 0; i < this.data.Length; i++)
            {
                newData[i] = this.data[i];
            }

            this.data = newData;
        }

        private void Shrink() // this method will help us to decrease the internal collection's length twice
        {
            if (this.data.Length >= this.Count * 2)
            {
                int[] newData = new int[this.Count];

                for (int i = 0; i < this.Count; i++)
                {
                    newData[i] = data[i];
                }

                data = newData;
            }
        }

        private void ValidateIndex(int index)
        {
            if (index > -1 && index < this.Count)
            {
                return;
            }

            var message = this.Count == 0 ? "The list is empty."
                : $"The list has {this.Count} elements and is zero-based.";

            throw new Exception($"Index out of range. {message}");
        }

    }
}
