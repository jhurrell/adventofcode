using Code;

namespace Tests;

public class GardenerTests
{
    [Theory]
    [InlineData(82, 79)]
    [InlineData(43, 14)]
    [InlineData(86, 55)]
    [InlineData(35, 13)]
    public void GetLocation(uint expected, uint seed)
    {
        var seeds = Seeds.InitializeAsDistinct(Puzzle.Value);
        var maps = Mappings.Initialize(Puzzle.Value);
        Assert.Equal(expected, Gardener.GetLocation(maps, seed));
    }

    [Fact]
    public void GetLowestLocation()
    {
        var seeds = Seeds.InitializeAsDistinct(Puzzle.Value);
        var maps = Mappings.Initialize(Puzzle.Value);
        Assert.Equal<uint>(35, Gardener.GetLowestLocation(maps, seeds));
    }    
}