using Code;

namespace Tests;

public class SeedsTests
{
    [Fact]
    public void Initialize()
    {
        var seed = Seeds.Initialize(Puzzle.Value);

        Assert.Collection(seed.Values, 
            item => Assert.Equal<uint>(79, item),
            item => Assert.Equal<uint>(14, item),
            item => Assert.Equal<uint>(55, item),
            item => Assert.Equal<uint>(13, item)
        );
    }
}