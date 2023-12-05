using Code;

namespace Tests;

public class SourceToDestinationTests
{
    [Fact]
    public void Initialize_Many()
    {
        var map = Mappings.Initialize(Puzzle.Value);
        Assert.Collection(map, 
            item => 
            {
                Assert.Equal("seed-to-soil", item.Key);
                Assert.Equal("seed-to-soil", item.Value.Name);
            },
            item => 
            {
                Assert.Equal("soil-to-fertilizer", item.Key);
                Assert.Equal("soil-to-fertilizer", item.Value.Name);
            },
            item => 
            {
                Assert.Equal("fertilizer-to-water", item.Key);
                Assert.Equal("fertilizer-to-water", item.Value.Name);
            },
            item => 
            {
                Assert.Equal("water-to-light", item.Key);
                Assert.Equal("water-to-light", item.Value.Name);
            },
            item => 
            {
                Assert.Equal("light-to-temperature", item.Key);
                Assert.Equal("light-to-temperature", item.Value.Name);
            },
            item => 
            {
                Assert.Equal("temperature-to-humidity", item.Key);
                Assert.Equal("temperature-to-humidity", item.Value.Name);
            },
            item => 
            {
                Assert.Equal("humidity-to-location", item.Key);
                Assert.Equal("humidity-to-location", item.Value.Name);
            }
        );
    }

    [Fact]
    public void Initialize_SeedToSoil()
    {
        var map = Mappings.Initialize("seed-to-soil map:|50 98 2|52 50 48");

        Assert.Equal<uint>(81, map.GetDestination(79));
        Assert.Equal<uint>(14, map.GetDestination(14));
        Assert.Equal<uint>(57, map.GetDestination(55));
        Assert.Equal<uint>(13, map.GetDestination(13));
    }
}
