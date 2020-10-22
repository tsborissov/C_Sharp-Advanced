using System;
using System.Collections;
using System.Collections.Generic;

namespace EnumeratorsDemo
{
    public class NumbersEnumerator : IEnumerator<int>
    {
        private int[] data;
        private int index;

        public NumbersEnumerator(int[] array)
        {
            this.Reset();
            
            this.data = array;
        }
        
        public int Current
        {
            get { return this.data[this.index]; }
        }

        object IEnumerator.Current => this.Current;

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            this.index++;

            return this.index < data.Length;
        }

        public void Reset()
        {
            this.index = -1;
        }
    }
}
