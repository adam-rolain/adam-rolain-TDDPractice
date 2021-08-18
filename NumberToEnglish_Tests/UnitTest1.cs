using System;
using Xunit;
using NumberToEnglish;
using System.Collections.Generic;

namespace NumberToEnglish_Tests
{
    public class UnitTest1
    {
        [Theory]
        [InlineData(10, null)]
        [InlineData(9, "hundred")]
        [InlineData(8, null)]
        [InlineData(2, null)]
        [InlineData(4, "thousand")]
        [InlineData(3, "hundred")]
        [InlineData(7, "million")]
        public void GetFillersTest(int position, string _expected)
        {
            Assert.Equal(_expected, Converter.GetFiller(position));
        }

        [Theory]
        [InlineData(10, "")]
        [InlineData(9, "nine")]
        [InlineData(8, "eight")]
        [InlineData(7, "seven")]
        [InlineData(6, "six")]
        [InlineData(5, "five")]
        [InlineData(4, "four")]
        [InlineData(3, "three")]
        [InlineData(2, "two")]
        [InlineData(1, "one")]
        [InlineData(0, "")]
        public void WriteDigitTest(int digit, string _expected)
        {
            Assert.Equal(_expected, Converter.WriteDigit(digit));
        }

        [Theory]
        [InlineData(100, "One hundred")]
        [InlineData(101, "One hundred one")]
        [InlineData(1000, "One thousand")]
        [InlineData(1000000, "One million")]
        [InlineData(1000000000, "Our program is not able to write passed 999,999,999.99")]
        [InlineData(999999999, "Nine hundred ninety-nine million nine hundred ninety-nine thousand nine hundred ninety-nine")]
        [InlineData(-1, "Our program is not able to write any numbers less than 0")]
        [InlineData(0, "Zero")]
        [InlineData(1, "One")]
        [InlineData(12850987, "Twelve million eight hundred fifty thousand nine hundred eighty-seven")]
        public void ConvertToEnglishTest(decimal number, string _expected)
        {
            Assert.StartsWith(_expected, Converter.ConvertToEnglish(number));
        }

        [Theory]
        [InlineData("one", "One")]
        [InlineData("ONE", "One")]
        [InlineData("", "")]
        [InlineData(null, "")]
        public void CapitalizedTest(string word, string expected)
        {
            Assert.Equal(expected, Converter.Capitalize(word));
        }

        [Theory]
        [InlineData(10, "ten")]
        [InlineData(11, "eleven")]
        [InlineData(12, "twelve")]
        [InlineData(13, "thirteen")]
        [InlineData(15, "fifteen")]
        [InlineData(18, "eightteen")]
        [InlineData(30, "thirty")]
        [InlineData(65, "sixty-five")]
        [InlineData(9, null)]
        [InlineData(100, null)]
        public void Write10Through99Test(int number, string expected)
        {
            if (number < 100 && number > 9)
            {
                Assert.StartsWith(expected, Converter.Write10Through99(number));
            }
            else
            {
                Assert.Equal(expected, Converter.Write10Through99(number));
            }    
        }

        [Theory]
        [InlineData(20, "twenty")]
        [InlineData(30, "thirty")]
        [InlineData(40, "forty")]
        [InlineData(50, "fifty")]
        [InlineData(60, "sixty")]
        [InlineData(70, "seventy")]
        [InlineData(80, "eighty")]
        [InlineData(90, "ninety")]
        [InlineData(19, null)]
        [InlineData(100, null)]
        public void WriteTensTest(int number, string expected)
        {
            if (number.ToString()[1] == '0' && number > 19 && number < 100)
            {
                Assert.StartsWith(expected, Converter.WriteTens(number));
            }
            else
            {
                Assert.Equal(expected, Converter.WriteTens(number));
            }
        }
    }
}
