namespace Code;

public class Mapping
{
    public Range Source { get; init; } = new();
    public Range Destination { get; init; } = new();

    public static Mapping Initialize(uint sourceStart, uint destinationStart, uint count)
    {
        return new Mapping 
        {
            Source = new Range { Start = sourceStart, End = sourceStart + count - 1 },
            Destination = new Range { Start = destinationStart, End = destinationStart + count - 1 },
        };
    }

    public uint? GetDestinationValue(uint testValue)
    {
        if(testValue >= Source.Start && testValue <= Source.End)
        {
            var offset = testValue - Source.Start;
            return Destination.Start + offset;
        }

        return null;
    } 

    public Range? GetDestinationRange(Range testRange)
    {
        // Determine if the ranges overlap.
        //Console.WriteLine($"WTF Source : {Source.Start}-{Source.End}");
        //Console.WriteLine($"WTF Test   : {testRange.Start}-{testRange.End}");
        if(testRange.End >= Source.Start && testRange.Start <= Source.End)
        {
            // The ranges overlap.
            var result = new Range {};
            var offset = Math.Max(Source.Start, testRange.Start) - Source.Start;
            var length = Math.Min(Source.End, testRange.End) - Source.Start;

            // Return the appropriate ranges from the Destination.
            result.Start = Destination.Start + offset;
            result.End = Destination.Start + length;

            return result;
        }

        return null;
    }    
}
