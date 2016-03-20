using System;
using System.Collections.Generic;

namespace System.Collections.Generic
{
    public sealed class ClassEnumerator<T> : IEnumerator<T>
    {
        private readonly T[] array;
        private int index;

        internal ClassEnumerator(T[] array)
            : this(array, -1)
        { }

        internal ClassEnumerator(T[] array, int index)
        {
            this.array = array;
            this.index = index;
        }

        public T Current => array[index];

        public bool MoveNext() => ++index < array.Length;

        object IEnumerator.Current => this.Current;

        void IDisposable.Dispose() { }

        void IEnumerator.Reset() => index = -1;
    }
}
