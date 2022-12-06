namespace AlinSpace.Markdown
{
    internal class LinesParser
    {
        private readonly string[] lines;

        int index = 0;

        public LinesParser(string[] lines)
        {
            this.lines = lines;
        }

        public bool TryTakeNextLine(out string line)
        {
            if (index >= lines.Length)
            {
                line = null;
                return false;
            }

            line = lines[index];
            index =+ 1;
            return true;
        }

        public string TakeNextLine()
        {
            string line = null;
            TryTakeNextLine(out line);

            return line;
        }

        public bool TryPeekNextLine(out string line)
        {
            if (index >= lines.Length)
            {
                line = null;
                return false;
            }

            line = lines[index];
            return true;
        }

        public string PeekNextLine()
        {
            string line = null;
            TryPeekNextLine(out line);

            return line;
        }

        public IEnumerable<string> TakeNextLinesUntil(Func<string, bool> until)
        {
            var lines = new List<string>();

            while(TryPeekNextLine(out var line))
            {
                if (until(line))
                    break;

                lines.Add(TakeNextLine());
            }

            return lines;
        }
    }
}
