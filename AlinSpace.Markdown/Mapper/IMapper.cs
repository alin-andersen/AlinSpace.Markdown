namespace AlinSpace.Markdown
{
    public interface IMapper<T>
    {
        IEnumerable<T> Map(IEnumerable<IMarkdownComponent> components);
    }
}
