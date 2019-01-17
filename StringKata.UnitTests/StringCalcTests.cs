using System;
using FluentAssertions;
using NUnit.Framework;

namespace StringKata.UnitTests
{
    [TestFixture]
    public class StringCalcTests
    {
        [Test]
        public void EmptyParameter_Should_Return_0()
        {
            var result = StringCalculator.Calculate("");
            result.Should().Be(0);
        }

        [TestCase("1", ExpectedResult = 1)]
        [TestCase("50", ExpectedResult = 50)]
        public int StringOf1_ShouldReturn_Number(string numbers)
        {
            var result = StringCalculator.Calculate(numbers);
            return result;
        }

        [TestCase("1,2", ExpectedResult = 3)]
        public int StringOf2_ShouldReturn_Sum(string numbers)
        {
            var result = StringCalculator.Calculate(numbers);
            return result;
        }

        [Test]
        public void Should_UseNewLines_AsDelimiters()
        {
            var result = StringCalculator.Calculate("1\n2,3");
            result.Should().Be(6);
        }

        [Test]
        public void HandleUserDefinedDelimiter()
        {
            var result = StringCalculator.Calculate("//;\n1;2");
            result.Should().Be(3);
        }

        [Test]
        public void NegativeNumbersShouldThrowException()
        {
            Action act = () => StringCalculator.Calculate("1,-2");
            act.Should().Throw<InvalidOperationException>()
                .WithMessage("whatever");
        }

        [TestCase("1,1001", ExpectedResult = 1)]
        [TestCase("1,1000", ExpectedResult = 1001)]
        public int IgnoreNumbersGreaterThan1000(string numbers)
        {
            var result = StringCalculator.Calculate(numbers);
            return result;
        }
    }
}