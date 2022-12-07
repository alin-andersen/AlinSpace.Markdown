namespace AlinSpace.Markdown
{
    // https://daringfireball.net/projects/markdown/syntax#header
    public static class Parser
    {
        public static IEnumerable<IMarkdownComponent> FromFile(string pathToFile)
        {
            var content = File.ReadAllText(pathToFile);
            return FromText(content);
        }

        public static IEnumerable<IMarkdownComponent> FromText(string text)
        {
            var lines = text.Split(Environment.NewLine);

            var parser = new LinesParser(lines);

            var components = new List<IMarkdownComponent>();

            while (parser.TryTakeNextLine(out var line))
            {
                if (string.IsNullOrWhiteSpace(line))
                    continue;

                line = line.TrimStart();

                if (HandleHeaders(components, parser, line))
                    continue;

                if (HandleHorizontalRule(components, line))
                    continue;

                if (HandleCodeBlock(components, parser, line))
                    continue;

                if (HandleParagraph(components, parser, line))
                    continue;
            }

            return components;
        }

        #region Headers

        private static bool HandleHeaders(IList<IMarkdownComponent> components, LinesParser parser, string line)
        {
            if (HandleHeader(components, parser, line, "# ", HeaderLevel.H1))
                return true;

            if (HandleHeader(components, parser, line, "## ", HeaderLevel.H2))
                return true;

            if (HandleHeader(components, parser, line, "### ", HeaderLevel.H3))
                return true;

            if (HandleHeader(components, parser, line, "#### ", HeaderLevel.H4))
                return true;

            if (HandleHeader(components, parser, line, "##### ", HeaderLevel.H5))
                return true;

            if (HandleHeader(components, parser, line, "###### ", HeaderLevel.H6))
                return true;

            return false;
        }

        private static bool HandleHeader(IList<IMarkdownComponent> components, LinesParser parser, string line, string headerPrefix, HeaderLevel level)
        {
            if (!line.StartsWith(headerPrefix))
                return false;

            var content = line.Substring(headerPrefix.Length);

            components.Add(new Header(level, content));

            return true;
        }

        #endregion

        private static bool HandleParagraph(IList<IMarkdownComponent> components, LinesParser parser, string line)
        {
            var lines = parser.TakeNextLinesUntil(line => string.IsNullOrWhiteSpace(line?.Trim()));

            components.Add(new Paragraph(new string[] { line }.Concat(lines).ToMultiLineString()));

            return true;
        }

        private static bool HandleHorizontalRule(List<IMarkdownComponent> components, string line)
        {
            if (!line.StartsWith("-"))
                return false;

            components.Add(new Separator());

            return true;
        }

        private static bool HandleCodeBlock(List<IMarkdownComponent> components, LinesParser parser, string line)
        {
            const string prefix = "```";

            if (!line.StartsWith(prefix))
                return false;

            var languageName = line.Substring(prefix.Length);

            if (string.IsNullOrWhiteSpace(languageName))
                languageName = null;

            var codeLines = parser.TakeNextLinesUntil(line => line.StartsWith(prefix));

            parser.TakeNextLine();

            components.Add(new Codeblock(languageName, codeLines.ToMultiLineString()));

            return true;
        }
    }
}
