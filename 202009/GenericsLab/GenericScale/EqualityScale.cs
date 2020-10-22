using System;
using System.Collections.Generic;
using System.Text;

namespace GenericScale
{
    public class EqualityScale<T>
    {
        private T left;
        private T right;

        public EqualityScale(T left, T right)
        {
            this.right = right;
            this.left = left;
        }


        public bool AreEqual()
        {
            return this.left.Equals(this.right);
        }
    }
}
