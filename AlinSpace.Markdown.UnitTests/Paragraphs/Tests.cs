using FluentAssertions;

namespace AlinSpace.Markdown.UnitTests.Paragraphs
{
    public class Tests
    {
        [Fact]
        public void Single()
        {
            var markdown = @"Test";

            var components = Parser.FromText(markdown);

            components.Count().Should().Be(1);
            components.First().GetType().Should().Be(typeof(Paragraph));
            components.Cast<Paragraph>().First().Text.Should().Be("Test");
        }

        [Fact]
        public void Multiple()
        {
            var markdown = @"1

2

3";

            var components = Parser.FromText(markdown);

            components.Count().Should().Be(3);
            components.Skip(0).First().GetType().Should().Be(typeof(Paragraph));
            components.Skip(1).First().GetType().Should().Be(typeof(Paragraph));
            components.Skip(2).First().GetType().Should().Be(typeof(Paragraph));

            components.Skip(0).Cast<Paragraph>().First().Text.Should().Be("1");
            components.Skip(1).Cast<Paragraph>().First().Text.Should().Be("2");
            components.Skip(2).Cast<Paragraph>().First().Text.Should().Be("3");
        }
    }
}
