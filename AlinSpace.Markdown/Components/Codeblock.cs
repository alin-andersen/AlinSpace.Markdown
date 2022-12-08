namespace AlinSpace.Markdown
{
    public class CodeBlock : IMarkdownComponent
    {
        public string Language { get; }

        public string Code { get; }

        public CodeBlock(
            string language, 
            string code)
        {
            Language = language;
            Code = code;
        }
    }
}
