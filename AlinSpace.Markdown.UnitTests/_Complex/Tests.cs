using FluentAssertions;

namespace AlinSpace.Markdown.UnitTests.Complex
{
    public class Tests
    {
        [Fact]
        public void Basic01()
        {
            var markdown = @"
# h1

## h2

1
2
3

4

-

```csharp

c1
c2

```

5
6
7

# h3

8";

            var components = Parser.FromText(markdown);

            components.Count().Should().Be(9);
            components.Skip(0).First().GetType().Should().Be(typeof(Header));
            components.Skip(1).First().GetType().Should().Be(typeof(Header));
            components.Skip(2).First().GetType().Should().Be(typeof(Paragraph));
            components.Skip(3).First().GetType().Should().Be(typeof(Paragraph));
            components.Skip(4).First().GetType().Should().Be(typeof(Separator));
            components.Skip(5).First().GetType().Should().Be(typeof(CodeBlock));
            components.Skip(6).First().GetType().Should().Be(typeof(Paragraph));
            components.Skip(7).First().GetType().Should().Be(typeof(Header));
            components.Skip(8).First().GetType().Should().Be(typeof(Paragraph));

            components.Skip(0).Take(1).Cast<Header>().First().Level.Should().Be(HeaderLevel.H1);
            components.Skip(0).Take(1).Cast<Header>().First().Text.Should().Be("h1");
            components.Skip(1).Take(1).Cast<Header>().First().Level.Should().Be(HeaderLevel.H2);
            components.Skip(1).Take(1).Cast<Header>().First().Text.Should().Be("h2");
            components.Skip(2).Take(1).Cast<Paragraph>().First().Text.Should().Be(@"1
2
3");
            components.Skip(3).Take(1).Cast<Paragraph>().First().Text.Should().Be("4");
            // Separator
            components.Skip(5).Take(1).Cast<CodeBlock>().First().Code.Should().Be(@"c1
c2");
            components.Skip(6).Take(1).Cast<Paragraph>().First().Text.Should().Be(@"5
6
7");
            components.Skip(7).Take(1).Cast<Header>().First().Level.Should().Be(HeaderLevel.H1);
            components.Skip(7).Take(1).Cast<Header>().First().Text.Should().Be("h3");
            components.Skip(8).Take(1).Cast<Paragraph>().First().Text.Should().Be("8");
        }
    }
}
