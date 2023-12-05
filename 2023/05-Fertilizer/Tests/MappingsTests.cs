using Code;

namespace Tests;

public class MappingsTests
{
    [Fact]    
    public void Initialize()
    {
        var mappings = Mappings.Initialize(Puzzle.Value);

        Assert.Collection(mappings, 
            item => Assert.Equal("seed-to-soil", item.Key),
            item => Assert.Equal("soil-to-fertilizer", item.Key),
            item => Assert.Equal("fertilizer-to-water", item.Key),
            item => Assert.Equal("water-to-light", item.Key),
            item => Assert.Equal("light-to-temperature", item.Key),
            item => Assert.Equal("temperature-to-humidity", item.Key),
            item => Assert.Equal("humidity-to-location", item.Key)
        );
    }

    [Theory]
    [InlineData(81, 79)]
    [InlineData(14, 14)]
    [InlineData(57, 55)]
    [InlineData(13, 13)]
    public void GetDestination(uint expected, uint seed)
    {
        var mappings = Mappings.Initialize(Puzzle.Value);

        Assert.Equal(expected, mappings["seed-to-soil"].GetDestinationForValue(seed));
    }
}