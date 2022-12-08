namespace AlinSpace.Markdown
{
    public class Mapper<T> : IMapper<T>
    {
        private readonly Func<CodeBlock, T> codeBlockMapping;
        private readonly Func<Header, T> headerMapping;
        private readonly Func<Paragraph, T> paragraphMapping;
        private readonly Func<Separator, T> separatorMapping;
        
        public Mapper(
            Func<CodeBlock, T> codeBlockMapping,
            Func<Header, T> headerMapping,
            Func<Paragraph, T> paragraphMapping,
            Func<Separator, T> separatorMapping)
        {
            this.codeBlockMapping = codeBlockMapping;
            this.headerMapping = headerMapping;
            this.paragraphMapping = paragraphMapping;
            this.separatorMapping = separatorMapping;
        }

        public IEnumerable<T> Map(IEnumerable<IMarkdownComponent> components)
        {
            var mappedComponents = new List<T>();

            foreach(var component in components)
            {
                switch(component)
                {
                    case CodeBlock codeBlock:
                        mappedComponents.Add(codeBlockMapping(codeBlock));
                        break;

                    case Header header:
                        mappedComponents.Add(headerMapping(header));
                        break;

                    case Paragraph paragraph:
                        mappedComponents.Add(paragraphMapping(paragraph));
                        break;

                    case Separator separator:
                        mappedComponents.Add(separatorMapping(separator));
                        break;

                    default:
                        continue;
                }
            }

            return mappedComponents;
        }
    }
}
