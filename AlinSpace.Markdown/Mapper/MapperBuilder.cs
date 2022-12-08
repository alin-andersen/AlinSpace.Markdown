namespace AlinSpace.Markdown
{
    public class MapperBuilder<T>
    {
        public static MapperBuilder<T> New()
        {
            return new MapperBuilder<T>();
        }

        public Func<CodeBlock, T> CodeBlockMapping { get; set; }

        public MapperBuilder<T> CodeBlock(Func<CodeBlock, T> mapping)
        {
            CodeBlockMapping = mapping;
            return this;
        }

        public Func<Header, T> HeaderMapping { get; set; }

        public MapperBuilder<T> Header(Func<Header, T> mapping)
        {
            HeaderMapping = mapping;
            return this;
        }

        public Func<Paragraph, T> ParagraphMapping { get; set; }

        public MapperBuilder<T> Paragraph(Func<Paragraph, T> mapping)
        {
            ParagraphMapping = mapping;
            return this;
        }

        public Func<Separator, T> SeparatorMapping { get; set; }

        public MapperBuilder<T> Separator(Func<Separator, T> mapping)
        {
            SeparatorMapping = mapping;
            return this;
        }

        public IMapper<T> Build()
        {
            return new Mapper<T>(
                CodeBlockMapping, 
                HeaderMapping, 
                ParagraphMapping, 
                SeparatorMapping);
        }
    }
}
