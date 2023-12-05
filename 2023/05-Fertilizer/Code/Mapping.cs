namespace Code;

public class Mapping
{
    public uint SourceStart { get; set; } = 0;
    public uint DestinationStart { get; set; } = 0;
    public uint Count { get; set; } = 0;

    public bool ContainsSource(uint source)
    {
        return source >= SourceStart && source <= SourceStart + Count;
    }
}
