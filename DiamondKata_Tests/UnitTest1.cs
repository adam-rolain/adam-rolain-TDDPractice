using System;
using Xunit;
using DiamondKata;

namespace DiamondKata_Tests
{
    public class UnitTest1
    {
        [Theory]
        [InlineData('A', 1)]
        [InlineData('B', 3)]
        [InlineData('C', 5)]
        [InlineData('D', 7)]
        [InlineData('E', 9)]
        [InlineData('Z', 51)]
        public void GetDiamondWidthTests(char _letter, int _expected)
        {
            Assert.Equal(_expected, Diamond.GetDiamondWidth(_letter));
        }

        [Theory]
        [InlineData(1, ".")]
        [InlineData(3, "...")]
        [InlineData(5, ".....")]
        [InlineData(51, "...................................................")]
        public void GenerateBlankLineTests(int _width, string _expected)
        {
            Assert.Equal(_expected, Diamond.GenerateBlankLine(_width));
        }

        [Theory]
        [InlineData('A', "A\n")]
        [InlineData('C', "..A..\n.B.B.\nC...C\n.B.B.\n..A..\n")]
        [InlineData('E', "....A....\n...B.B...\n..C...C..\n.D.....D.\nE.......E\n.D.....D.\n..C...C..\n...B.B...\n....A....\n")]
        public void CreateGridTests(char _letter, string _expected)
        {
            Assert.Equal(_expected, Diamond.CreateGrid(_letter));
        }
    }
}
