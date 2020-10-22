using System;
using System.Collections;
using System.Collections.Generic;

namespace EnumeratorsDemo
{
    public class Numbers : IEnumerable<int>
    {
        private int[] data;

        public Numbers(int[] array)
        {
            this.data = array;
        }

        public int Count
        {
            get { return this.data.Length; }
        }

        public IEnumerator<int> GetEnumerator()
        {
            return new NumbersEnumerator(this.data);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
