using Xunit;
using FluentAssertions;
using LearnCSharp.Solutions;

namespace WithTests.Solutions
{
    public class HelloWorldTests
    {
        [Fact]
        [Trait("Category", "Solution")]
        public void it_greets_with_a_person()
        {
            var expected = "Hello, Wes";
            var actual = HelloWorld.Greet("Wes", "English");

            actual.Should().Be(expected);
        }

        [Fact]
        [Trait("Category", "Solution")]
        public void it_greets_without_a_person()
        {
            var expected = "Hello, World";
            var actual = HelloWorld.Greet("", "English");

            actual.Should().Be(expected);
        }

        [Fact]
        [Trait("Category", "Solution")]
        public void it_greets_in_spanish()
        {
            var expected = "Hola, Roberto";
            var actual = HelloWorld.Greet("Roberto", "Spanish");

            actual.Should().Be(expected);
        }

        [Fact]
        [Trait("Category", "Solution")]
        public void it_greets_in_french()
        {
            var expected = "Bonjour, Lauren";
            var actual = HelloWorld.Greet("Lauren", "French");

            actual.Should().Be(expected);
        }
    }
}
