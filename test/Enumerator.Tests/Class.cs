using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace System.Collections.Generic.Tests
{
    public class ClassEnumerator
    {
        [Fact]
        public void ArgumentNull()
        {
            Assert.Throws<ArgumentNullException>(() => Enumerator.Class<short>(null));
            Assert.Throws<ArgumentNullException>(() => Enumerator.Class<int>(null, 123));
        }
        
        [Fact]
        public void IndexOutOfRange()
        {
            Assert.Throws<IndexOutOfRangeException>(() => Enumerator.Class(new byte[0], 0));
            Assert.Throws<IndexOutOfRangeException>(() => Enumerator.Class(new byte[0], -2));
        }
        
        [Theory]
        [InlineData(0, -1)] // -1 is a valid index
        [InlineData(1, 0)]
        [InlineData(123, 57)]
        [InlineData(456, 455)]
        public void ValidConfigurations(int arrayCapacity, int index)
        {
            var e = Enumerator.Class(new byte[arrayCapacity], index);
        }
        
        [Fact]
        public void KeepInSync()
        {
            var array = Enumerable.Range(0, 123).ToArray();
            var e = Enumerator.Class(array);
            
            // Starting index should be -1
            int expectedIndex = -1;
            Assert.Throws<IndexOutOfRangeException>(() => e.Current);
            
            while (e.MoveNext())
            {
                Assert.Equal(++expectedIndex, e.Current);
            }
        }
    }
}