using Xunit;
using FluentAssertions;
using LearnCSharp.Solutions;

namespace WithTests.Solutions
{
    public class IntegersTests
    {
        [Fact]
        [Trait("Category", "Solution")]
        public void it_adds()
        {
            var expected = 4;
            var actual = Integers.Add(2, 2);

            actual.Should().Be(expected);
        }       
    }
}
