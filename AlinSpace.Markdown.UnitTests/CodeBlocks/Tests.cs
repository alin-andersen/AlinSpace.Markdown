using FluentAssertions;

namespace AlinSpace.Markdown.UnitTests.CodeBlocks
{
    public class Tests
    {
        [Fact]
        public void CodeBlock_Without_Language()
        {
            var markdown = @"```
1
2
3
```";

            var components = Parser.FromText(markdown);

            components.Count().Should().Be(1);
            components.First().GetType().Should().Be(typeof(CodeBlock));
            components.Cast<CodeBlock>().First().Language.Should().BeNull();
            components.Cast<CodeBlock>().First().Code.Should().Be(@"1
2
3");
        }

        [Fact]
        public void CodeBlock_With_Language()
        {
            var markdown = @"```csharp
1
2
3
```";

            var components = Parser.FromText(markdown);

            components.Count().Should().Be(1);
            components.First().GetType().Should().Be(typeof(CodeBlock));
            components.Cast<CodeBlock>().First().Language.Should().Be("csharp");
            components.Cast<CodeBlock>().First().Code.Should().Be(@"1
2
3");
        }

    }
}
