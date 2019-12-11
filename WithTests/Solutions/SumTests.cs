using Xunit;
using FluentAssertions;
using LearnCSharp.Solutions;

namespace WithTests.Solutions
{
    public class SumTests
    {
        [Fact]
        [Trait("Category", "Solution")]
        public void it_sums_any_size()
        {
            var numbers = new[] {1, 2, 3};
            
            var expected = 6;
            var actual = Sum.Add(numbers);

            actual.Should().Be(expected);
        }

        [Fact]
        [Trait("Category", "Solution")]
        public void it_sums_tails()
        {
            var expected = new[] {2, 9};
            var actual = Sum.AddTails(
                new[] {1, 2},
                new[] {0, 9}
            );

            actual.Should().Equal(expected);
        }
        
        [Fact]
        [Trait("Category", "Solution")]
        public void it_sums_empty_collections()
        {
            var expected = new[] {0, 9};
            var actual = Sum.AddTails(
                new int[] {},
                new[] {3, 4, 5}
            );

            actual.Should().Equal(expected);
        }
    }
}
