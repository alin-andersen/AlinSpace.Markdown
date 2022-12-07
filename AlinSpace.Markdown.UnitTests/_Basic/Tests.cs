using FluentAssertions;

namespace AlinSpace.Markdown.UnitTests.Basic
{
    public class Tests
    {
        [Fact]
        public void Basic01()
        {
            var markdown = @"
# Test

1
2
3

4";

            var components = Parser.FromText(markdown);

            components.Count().Should().Be(3);
            components.Skip(0).First().GetType().Should().Be(typeof(Header));
            components.Skip(1).First().GetType().Should().Be(typeof(Paragraph));
            components.Skip(2).First().GetType().Should().Be(typeof(Paragraph));

            components.Skip(0).Take(1).Cast<Header>().First().Level.Should().Be(HeaderLevel.H1);
            components.Skip(1).Take(1).Cast<Paragraph>().First().Text.Should().Be(@"1
2
3");
            components.Skip(2).Take(1).Cast<Paragraph>().First().Text.Should().Be("4");
        }
    }
}
