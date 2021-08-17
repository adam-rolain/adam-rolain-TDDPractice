using System;
using Xunit;

namespace PasswordVerifier_Tests
{
    public class UnitTest1
    {
        [Theory]
        [InlineData("adamr1234", true)]
        [InlineData("adamrol", false)]
        [InlineData("Adamrol2", true)]
        [InlineData("", false)]
        [InlineData("Ad8", true)]

        public void VerifyTests(string _password, bool _expected)
        {
            Assert.Equal(_expected, PasswordVerifier.PasswordVerifier.Verify(_password));
        }

        [Theory]
        [InlineData("adamr1234", true)]
        [InlineData("adamrol", false)]
        [InlineData("adamrol2", true)]
        public void IsLargerThanEightTests(string _password, bool _expected)
        {
            Assert.Equal(_expected, PasswordVerifier.PasswordVerifier.IsLargerThanEight(_password));
        }

        [Theory]
        [InlineData("Adamrolain", true)]
        [InlineData("adamRolain", true)]
        [InlineData("adamrol2", false)]
        public void HasAnUpperCaseTests(string _password, bool _expected)
        {
            Assert.Equal(_expected, PasswordVerifier.PasswordVerifier.HasAnUpperCase(_password));
        }

        [Theory]
        [InlineData("ADAMROLAIN", false)]
        [InlineData("ADAMrOLAIN", true)]
        [InlineData("123ADAMrol", true)]
        public void HasALowerCaseTests(string _password, bool _expected)
        {
            Assert.Equal(_expected, PasswordVerifier.PasswordVerifier.HasALowerCase(_password));
        }
         
        [Theory]
        [InlineData("adam0", true)]
        [InlineData("adamrolain", false)]
        [InlineData("adamr3olain", true)]
        public void HasANumberTests(string _password, bool _expected)
        {
            Assert.Equal(_expected, PasswordVerifier.PasswordVerifier.HasANumber(_password));
        }

    }
}
