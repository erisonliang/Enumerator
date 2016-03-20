using System;
using System.Collections.Generic;

namespace System.Collections.Generic
{
    public static class Enumerator
    {
        public static StructEnumerator<T> Struct<T>(T[] array)
        {
            return new StructEnumerator<T>(array);
        }

        public static StructEnumerator<T> Struct<T>(T[] array, int index)
        {
            return new StructEnumerator<T>(array, index);
        }

        public static ClassEnumerator<T> Class<T>(T[] array)
        {
            return new ClassEnumerator<T>(array);
        }

        public static ClassEnumerator<T> Class<T>(T[] array, int index)
        {
            return new ClassEnumerator<T>(array, index);
        }
    }
}
