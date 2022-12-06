namespace AlinSpace.Markdown
{
    public static class Parser
    {
        // https://daringfireball.net/projects/markdown/syntax#header
        public static IEnumerable<IMarkdownComponent> FromFile(string pathToFile)
        {
            var lines = File.ReadAllLines(pathToFile);

            var linesParser = new LinesParser(lines);

            var components = new List<IMarkdownComponent>();

            while (linesParser.TryTakeNextLine(out var line))
            {
                if (string.IsNullOrWhiteSpace(line))
                    continue;

                line = line.TrimStart();


                if (HandleHeaders(linesParser, line))
                    continue;
            }

            return components;
        }

        private static bool HandleHeaders(LinesParser linesParser, string line)
        {




            return true;
        }
    }
}
