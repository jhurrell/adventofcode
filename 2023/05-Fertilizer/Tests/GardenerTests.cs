using Code;
using Range = Code.Range;

namespace Tests;

public class GardenerTests
{
    [Theory]
    [InlineData(82, 79)]
    [InlineData(43, 14)]
    [InlineData(86, 55)]
    [InlineData(35, 13)]
    public void InitializeAsDistinct(uint expected, uint seed)
    {
        var seeds = Seeds.InitializeAsDistinct(Puzzle.Value);
        var maps = Mappings.Initialize(Puzzle.Value);
        Assert.Equal(expected, Gardener.GetLocationForValue(maps, seed));
    }

    [Fact]
    public void GetLowestLocationViaDistinct()
    {
        var seeds = Seeds.InitializeAsDistinct(Puzzle.Value);
        var maps = Mappings.Initialize(Puzzle.Value);
        Assert.Equal<uint>(35, Gardener.GetLowestLocationViaDistinct(maps, seeds));
    }  

    [Fact]
    public void GetLowestLocationViaRanges()
    {
        var seeds = Seeds.InitializeAsRanges(Puzzle.Value);
        var maps = Mappings.Initialize(Puzzle.Value);
        Assert.Equal<uint>(46, Gardener.GetLowestLocationViaRange(maps, seeds));
    }

    [Fact]
    public void GetLowestLocationViaRanges_ForExample()
    {
        var maps = Mappings.Initialize(Puzzle.Value);
        Assert.Equal<uint>(46, Gardener.GetLowestLocationViaRange(maps, new Seeds { Ranges = new List<Range> { new  Range { Start = 82, End = 82 } }}));
    }         
}