namespace AlinSpace.Markdown
{
    public class Paragraph : IMarkdownComponent
    {
        public string Text { get; }

        public Paragraph(string text)
        {
            Text = text;
        }
    }
}