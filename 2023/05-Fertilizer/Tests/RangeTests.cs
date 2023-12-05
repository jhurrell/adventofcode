using Range = Code.Range;

namespace Tests;

public class RangeTests
{
    [Theory]
    [InlineData(4, 4, 4, 6, 1, 4)]
    [InlineData(4, 5, 4, 6, 1, 5)]
    [InlineData(4, 6, 4, 6, 1, 6)]
    [InlineData(4, 6, 4, 6, 1, 7)]
    [InlineData(4, 4, 4, 6, 3, 4)]
    [InlineData(4, 4, 4, 6, 4, 4)]
    [InlineData(5, 5, 4, 6, 5, 5)]
    [InlineData(5, 6, 4, 6, 5, 6)]
    [InlineData(5, 6, 4, 6, 5, 7)]
    [InlineData(6, 6, 4, 6, 6, 7)]
    public void GetOverlap_WhenOverlap(uint expectedStart, uint expectedEnd, uint leftStart, uint leftEnd, uint rightStart, uint rightEnd)
    {
        var result = Range.GetOverlap(new Range { Start = leftStart, End = leftEnd }, new Range { Start = rightStart, End = rightEnd } );
        Assert.Equal(expectedStart, result?.Start);
        Assert.Equal(expectedEnd, result?.End);
    }

    [Theory]
    [InlineData(4, 6, 1, 3)]
    [InlineData(4, 6, 7, 9)]
    public void GetOverlap_WhenNoOverlap(uint leftStart, uint leftEnd, uint rightStart, uint rightEnd)
    {
        var result = Range.GetOverlap(new Range { Start = leftStart, End = leftEnd }, new Range { Start = rightStart, End = rightEnd } );
        Assert.Null(result);
    }
}