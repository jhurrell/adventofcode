namespace Tests;

public class SectionManagerTests
{
    [Fact]
    public void FullyContainedCount()
    {
        var assignments = new List<string>
        {
            "2-4,6-8",
            "2-3,4-5",
            "5-7,7-9",
            "2-8,3-7",
            "6-6,4-6",
            "2-6,4-8",            
        };

        var manager = SectionManager.Initialize(assignments);

        Assert.Equal(2, manager.FullyContainedCount);
    }    
}