using Xunit;
using FluentAssertions;
using LearnCSharp.Solutions;

namespace WithTests.Solutions
{
    public class IterationTests
    {
        [Fact]
        [Trait("Category", "Solution")]
        public void it_repeats()
        {
            var expected = "aaaa";
            var actual = Iteration.Repeat("a");

            actual.Should().Be(expected);
        }
    }
}
