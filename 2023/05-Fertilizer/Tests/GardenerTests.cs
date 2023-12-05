using Code;
using Range = Code.Range;

namespace Tests;

public class GardenerTests
{
    // [Theory]
    // [InlineData(82, 79)]
    // [InlineData(43, 14)]
    // [InlineData(86, 55)]
    // [InlineData(35, 13)]
    // public void InitializeAsDistinct(uint expected, uint seed)
    // {
    //     var seeds = Seeds.InitializeAsDistinct(Puzzle.Value);
    //     var maps = Mappings.Initialize(Puzzle.Value);
    //     Assert.Equal(expected, Gardener.Initialize(maps, seeds));
    // }

    // [Fact]
    // public void GetLowestLocationViaDistinct()
    // {
    //     var seeds = Seeds.InitializeAsDistinct(Puzzle.Value);
    //     var maps = Mappings.Initialize(Puzzle.Value);
    //     Assert.Equal<uint>(35, Gardener.GetLowestLocationViaDistinct(maps, seeds));
    // }  

    // [Fact]
    // public void GetLowestLocationViaRanges_ForExample_82()
    // {
    //     var maps = Mappings.Initialize(Puzzle.Value);
    //     Assert.Equal<uint>(46, Gardener.GetLowestLocationViaRange(maps, new Seeds { Ranges = new List<Range> { new() { Start = 82, End = 82 } }}));
    // }

    // [Fact]
    // public void GetLowestLocationViaRanges_ForExample_79_14()
    // {
    //     var maps = Mappings.Initialize(Puzzle.Value);
    //     Assert.Equal<uint>(46, Gardener.GetLowestLocationViaRange(maps, new Seeds { Ranges = new List<Range> { new() { Start = 79, End = 92 } }}));
    // }    
}
