using System;
using Xunit;
using OddEven;

namespace OddEven_Tests
{
    public class OddEvenUnitTests 
    {
        [Theory]
        [InlineData(1, false)]
        [InlineData(8, true)]
        [InlineData(99, false)]
        [InlineData(100, true)]
        public void TestIsEven(int _num, bool _expected)
        {
            Assert.Equal(_expected, OddEven.OddEven.IsEven(_num));
        }

        [Theory]
        [InlineData(1, "PRIME")]
        [InlineData(2, "PRIME")]
        [InlineData(8, "EVEN")]
        [InlineData(11, "PRIME")]
        [InlineData(97, "PRIME")]
        [InlineData(99, "ODD")]
        [InlineData(100, "EVEN")]
        public void TestCategorizeEvenOddPrime(int _num, string _expected)
        {
            Assert.Equal(_expected, OddEven.OddEven.CategorizeEvenOddPrime(_num));
        }
    }
    
    public class PrimeNumbersUnitTests
    {
        [Theory]
        [InlineData(2, true)]
        [InlineData(3, true)]
        [InlineData(4, false)]
        [InlineData(11, true)]
        [InlineData(60, false)]
        [InlineData(73, true)]
        [InlineData(100, false)]
        public void TestIsPrimeNumber(int _num, bool _expected)
        {
            Assert.Equal(_expected, PrimeNumbers.IsPrimeNumber(_num));
        }

        [Theory]
        [InlineData(1, 2)]
        [InlineData(2, 3)]
        [InlineData(5, 11)]
        [InlineData(21, 73)]
        [InlineData(42, 181)]
        [InlineData(204, 1249)]

        public void TestGetPrime(int _num, int _expected)
        {
            Assert.Equal(_expected, PrimeNumbers.GetPrime(_num));
        }
    }
}
