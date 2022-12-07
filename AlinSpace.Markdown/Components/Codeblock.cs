namespace AlinSpace.Markdown
{
    public class Codeblock : IMarkdownComponent
    {
        public string Language { get; }

        public string Code { get; }

        public Codeblock(
            string language, 
            string code)
        {
            Language = language;
            Code = code;
        }
    }
}
