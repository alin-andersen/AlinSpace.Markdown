using System.Text;

namespace AlinSpace.Markdown
{
    public static class StringEnumerableExtensions
    {
        public static string ToMultiLineString(this IEnumerable<string> lines)
        {
            var builder = new StringBuilder();

            foreach(var line in lines)
            {
                builder.AppendLine(line);
            }

            return builder.ToString().Trim();
        }
    }
}
