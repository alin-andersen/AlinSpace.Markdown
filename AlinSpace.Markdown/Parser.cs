namespace AlinSpace.Markdown
{
    public static class Parser
    {
        public static IEnumerable<IMarkdownComponent> FromFile(string pathToFile)
        {
            var lines = File.ReadAllLines(pathToFile);

            // TODO



        }
    }
}
