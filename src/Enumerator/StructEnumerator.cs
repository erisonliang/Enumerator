using System;
using System.Collections.Generic;

namespace System.Collections.Generic
{
    public struct StructEnumerator<T>
    {
        private readonly T[] array;
        private int index;

        internal StructEnumerator(T[] array)
            : this(array, -1)
        { }

        internal StructEnumerator(T[] array, int index)
        {
            this.array = array;
            this.index = index;
        }

        public T Current => array[index];

        public bool MoveNext() => ++index < array.Length;
    }
}
