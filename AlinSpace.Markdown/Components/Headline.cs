namespace AlinSpace.Markdown
{
    public class Headline : IMarkdownComponent
    {
        public HeadlineLevel Level { get; }

        public string Text { get; }

        public Headline(
            HeadlineLevel level, 
            string text)
        {
            Level = level;
            Text = text;
        }
    }
}