using FluentAssertions;

namespace AlinSpace.Markdown.UnitTests.Headers
{
    public class Tests
    {
        #region Headers

        [Fact]
        public void Header_H1()
        {
            var markdown = @"# Test";

            var components = Parser.FromText(markdown);

            components.Count().Should().Be(1);
            components.First().GetType().Should().Be(typeof(Header));
            components.Cast<Header>().First().Level.Should().Be(HeaderLevel.H1);
        }

        [Fact]
        public void Header_H2()
        {
            var markdown = @"## Test";

            var components = Parser.FromText(markdown);

            components.Count().Should().Be(1);
            components.First().GetType().Should().Be(typeof(Header));
            components.Cast<Header>().First().Level.Should().Be(HeaderLevel.H2);
        }

        [Fact]
        public void Header_H3()
        {
            var markdown = @"### Test";

            var components = Parser.FromText(markdown);

            components.Count().Should().Be(1);
            components.First().GetType().Should().Be(typeof(Header));
            components.Cast<Header>().First().Level.Should().Be(HeaderLevel.H3);
        }

        [Fact]
        public void Header_H4()
        {
            var markdown = @"#### Test";

            var components = Parser.FromText(markdown);

            components.Count().Should().Be(1);
            components.First().GetType().Should().Be(typeof(Header));
            components.Cast<Header>().First().Level.Should().Be(HeaderLevel.H4);
        }

        [Fact]
        public void Header_H5()
        {
            var markdown = @"##### Test";

            var components = Parser.FromText(markdown);

            components.Count().Should().Be(1);
            components.First().GetType().Should().Be(typeof(Header));
            components.Cast<Header>().First().Level.Should().Be(HeaderLevel.H5);
        }

        [Fact]
        public void Header_H6()
        {
            var markdown = @"###### Test";

            var components = Parser.FromText(markdown);

            components.Count().Should().Be(1);
            components.First().GetType().Should().Be(typeof(Header));
            components.Cast<Header>().First().Level.Should().Be(HeaderLevel.H6);
        }

        #endregion
    }
}
