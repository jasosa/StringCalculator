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
    public class ValidatorTests
    {
        [Fact]
        public void TwoNumbersBetweenACommaReturnsValid()
        {
            // Arrange
            var input = "1,2";
            var delimiters = new List<char>{','};
            IValidator validator = new Validator();

            // Act
            var isValid = validator.Validate(input, delimiters);

            // Assert
            isValid.Should().BeTrue();
        }

        [Fact]
        public void TwoConsecutiveCommasReturnsNotValid()
        {
            // Arrange
            var input = "1,,3";
            var delimiters = new List<char> { ',' };
            IValidator validator = new Validator();

            // Act
            var isValid = validator.Validate(input, delimiters);

            // Assert
            isValid.Should().BeFalse();
        }

        [Fact]
        public void NegativeNumberReturnsNotValid()
        {
            // Arrange
            var input = "1,-2,3";
            var delimiters = new List<char> { ',' };
            IValidator validator = new Validator();

            // Act
            var isValid = validator.Validate(input, delimiters);

            // Assert
            isValid.Should().BeFalse();
            validator.LastErrorMessage.Should().Be("Negatives not allowed: -2");
        }
    }
}
