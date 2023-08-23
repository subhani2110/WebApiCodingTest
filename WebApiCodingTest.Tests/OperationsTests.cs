using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace WebApiCodingTest.Tests
{
    public class OperationsTests
    {
        [Fact]
        public void Add_WhenCalled_ReturnsSum()
        {
            // Arrange
            var num1 = 1;
            var num2 = 2;
            var expected = 3;

            // Act
            var actual = new Operations().Add(num1, num2);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
