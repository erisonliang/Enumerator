using System;
using System.Collections.Generic;

namespace System.Collections.Generic
{
    public sealed class ClassEnumerator<T> : IEnumerator<T>
    {
        private static readonly ClassEnumerator<T> s_emptyEnumerator =
            new ClassEnumerator<T>(new T[0]);

        private readonly T[] array;
        private int index;

        private ClassEnumerator(T[] array)
            : this(array, -1)
        { }

        private ClassEnumerator(T[] array, int index)
        {
            this.array = array;
            this.index = index;
        }

        public T Current => array[index];

        public bool MoveNext() => ++index < array.Length;

        object IEnumerator.Current => this.Current;

        void IDisposable.Dispose() { }

        void IEnumerator.Reset() => index = -1;

        internal static ClassEnumerator<T> Create(T[] array)
        {
            return array.Length == 0 ?
                s_emptyEnumerator :
                new ClassEnumerator<T>(array);
        }
    }
}
