using FluentAssertions;
using Source;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Tests
{
    public class CalculatorTests
    {
        public Calculator InitializeTestee()
        {
            return new Calculator(new Validator());
        }

        [Fact]
        public void AddEmptyStringReturns0()
        {
            // Arrange
            var testee = this.InitializeTestee();
            var numbers = string.Empty;

            // Act
            var result = testee.Add(numbers);

            // Assert
            result.Should().Be(0);
        }

        [Fact]
        public void AddSingleNumberStringReturnsNumber()
        {
            // Arrange
            var testee = this.InitializeTestee();
            var numbers = "2";

            // Act
            var result = testee.Add(numbers);

            // Assert
            result.Should().Be(2);
        }

        [Fact]
        public void AddTwoNumberStringReturnsTheSumOfThem()
        {
            // Arrange
            var testee = this.InitializeTestee();
            var numbers = "3,5";

            // Act
            var result = testee.Add(numbers);

            // Assert
            result.Should().Be(8);
        }

        [Fact]
        public void AddStringWithMoreThanTwoNumbersReturnsTheSumOfThem()
        {
            // Arrange
            var testee = this.InitializeTestee();
            var numbers = "3,8,9,10";

            // Act
            var result = testee.Add(numbers);

            // Assert
            result.Should().Be(30);
        }

        [Fact]
        public void AddStringWithNewLinesBetweenNumbersResturnsTheSumOfThem()
        {
            // Arrange
            var testee = this.InitializeTestee();
            var numbers = "1\n3,6";

            // Act
            var result = testee.Add(numbers);

            // Assert
            result.Should().Be(10);
        }

        [Fact]
        public void AddStringWithIncorrectFormat1ThenExceptionIsThrown()
        {
            // Arrange
            var testee = this.InitializeTestee();
            var numbers = "1,\n";

            // Act & Assert
            Assert.Throws<CalculatorFormatException>(() => testee.Add(numbers));
        }

        [Fact]
        public void AddStringWithIncorrectFormat2ThenExceptionIsThrown()
        {
            // Arrange
            var testee = this.InitializeTestee();
            var anotherIncorrectNumbers = "1\n,";

            // Act & Assert
            Assert.Throws<CalculatorFormatException>(() => testee.Add(anotherIncorrectNumbers));
        }

        [Fact]
        public void AddStringChangingDefaultDelimiterBySemiColonReturnsTheSumOfTheNumbers()
        {
            // Arrange
            var testee = this.InitializeTestee();
            var numbers = "//;\n1;2";

            // Act
            var result = testee.Add(numbers);

            // Assert
            result.Should().Be(3);
        }

        [Fact]
        public void AddStringChangingDefaultDelimiterByPLetterReturnsTheSumOfTheNumbers()
        {
            // Arrange
            var testee = this.InitializeTestee();
            var numbers = "//p\n1p2";

            // Act
            var result = testee.Add(numbers);

            // Assert
            result.Should().Be(3);
        }

        [Fact]
        public void AddStringWithANegativeNumberThenExceptionIsThrown()
        {
            // Arrange
            var testee = this.InitializeTestee();
            var negativeNumbers = "1,2,3,-5";

            // Act & Assert
            var exception = Assert.Throws<CalculatorFormatException>(() => testee.Add(negativeNumbers));
            exception.Message.Should().Be("Negatives not allowed: -5");
        }
    }
}
