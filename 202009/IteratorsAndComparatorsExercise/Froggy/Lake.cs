using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Froggy
{
    public class Lake : IEnumerable<int>
    {
        private List<int> data;

        public Lake(int[] collection)
        {
            this.data = new List<int> (collection);
        }

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < this.data.Count; i += 2)
            {
                yield return this.data[i];
            }

            int returnIndex = this.data.Count - 1;
            if (this.data.Count % 2 != 0)
            {
                returnIndex--;
            }

            for (int i = returnIndex; i >= 0; i -= 2)
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
