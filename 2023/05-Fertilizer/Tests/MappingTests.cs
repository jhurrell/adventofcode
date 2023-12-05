using Code;
using Range = Code.Range;

namespace Tests;

public class MappingTests
{
    [Theory]
    [InlineData(1, 2, 3, 4, 1, 3, 2)]
    [InlineData(1, 5, 10, 14, 1, 10, 5)]
    public void Initialize(
        uint expectedSourceStart,
        uint expectedSourceEnd,
        uint expectedDestinationStart,
        uint expectedDestinationEnd,
        uint sourceStart,
        uint destinationStart,
        uint count
    )
    {
        var mapping = Mapping.Initialize(sourceStart, destinationStart, count);
        Assert.Equal(expectedSourceStart, mapping.Source.Start);
        Assert.Equal(expectedSourceEnd, mapping.Source.End);
        Assert.Equal(expectedDestinationStart, mapping.Destination.Start);
        Assert.Equal(expectedDestinationEnd, mapping.Destination.End);
    }

    [Theory]
    [InlineData(98, 50, 98, 2, 50)]
    [InlineData(99, 50, 98, 2, 51)]
    public void GetDestinationValue_WhenExistsInRange(uint expected, uint sourceStart, uint destStart, uint count, uint testValue)
    {
        var mapping = Mapping.Initialize(sourceStart, destStart, count);
        var result = mapping.GetDestinationValue(testValue);
        
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(50, 98, 2, 49)]
    [InlineData(50, 98, 2, 52)]
    public void GetDestinationValue_WhenNotExistsInRange(uint sourceStart, uint destStart, uint count, uint testValue)
    {
        var mapping = Mapping.Initialize(sourceStart, destStart, count);
        var result = mapping.GetDestinationValue(testValue);
        
        Assert.Null(result);
    }        

    [Theory]
    [InlineData(50, 50, 98, 50, 2, 97, 98)]
    [InlineData(10, 12, 1, 10, 5, 1, 3)]
    public void GetDestinationRange(uint expectedStart, uint expectedEnd, uint sourceStart, uint destStart, uint count, uint rangeStart, uint rangeEnd)
    {
        var mapping = Mapping.Initialize(sourceStart, destStart, count);
        var results = mapping.GetDestinationRange(new Range { Start = rangeStart, End = rangeEnd });
        
        Assert.Equal(expectedStart, results?.Start);
        Assert.Equal(expectedEnd, results?.End);
    }
}