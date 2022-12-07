namespace AlinSpace.Markdown
{
    public class Header : IMarkdownComponent
    {
        public HeaderLevel Level { get; }

        public string Text { get; }

        public Header(
            HeaderLevel level, 
            string text)
        {
            Level = level;
            Text = text;
        }
    }
}