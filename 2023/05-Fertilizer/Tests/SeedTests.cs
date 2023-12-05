using Code;

namespace Tests;

public class SeedsTests
{
    [Fact]
    public void InitializeAsDistinct()
    {
        var seed = Seeds.InitializeAsDistinct(Puzzle.Value);

        Assert.Collection(seed.Ranges, 
            item => 
            {
                Assert.Equal<uint>(79, item.Start);
                Assert.Equal<uint>(79, item.End);
            },
            item => 
            {
                Assert.Equal<uint>(14, item.Start);
                Assert.Equal<uint>(14, item.End);
            },
            item => 
            {
                Assert.Equal<uint>(55, item.Start);
                Assert.Equal<uint>(55, item.End);
            },
            item => 
            {
                Assert.Equal<uint>(13, item.Start);
                Assert.Equal<uint>(13, item.End);
            }
        );        
    }

    [Fact]
    public void InitializeAsRanges()
    {
        var seed = Seeds.InitializeAsRanges(Puzzle.Value);

        Assert.Collection(seed.Ranges, 
            item => 
            {
                Assert.Equal<uint>(79, item.Start);
                Assert.Equal<uint>(92, item.End);
            },
            item => 
            {
                Assert.Equal<uint>(55, item.Start);
                Assert.Equal<uint>(67, item.End);
            }
        );
    }    
}