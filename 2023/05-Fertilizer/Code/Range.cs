namespace Code;

public class Range
{
    public uint Start { get; set; } = 0;
    public uint End { get; set; } = 0;

    public static Range? GetOverlap(Range left, Range right)
    {
        // Determine if the ranges overlap.
        if(right.End >= left.Start && right.Start <= left.End)
        {
            // The ranges overlap.
            var result = new Range 
            {
                // Apply the approproate range extents.
                Start = Math.Max(left.Start, right.Start),
                End = Math.Min(left.End, right.End)
            };

            return result;
        }

        return null;     
    }
}