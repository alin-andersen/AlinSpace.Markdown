namespace AlinSpace.Markdown
{
    public class Codeblock : IMarkdownComponent
    {
        public string Language { get; }

        public string Text { get; }

        public Codeblock(
            string language, 
            string text)
        {
            Language = language;
            Text = text;
        }
    }
}
