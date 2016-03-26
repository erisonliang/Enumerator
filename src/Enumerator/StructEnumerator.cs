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
            if (array == null)
                throw new ArgumentNullException(nameof(array));
            if ((uint)(index + 1) > array.Length)
                throw new IndexOutOfRangeException(nameof(index));
            
            this.array = array;
            this.index = index;
        }

        public T Current => array[index];

        public bool MoveNext() => ++index < array.Length;
    }
}
