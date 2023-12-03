namespace Tests;

public class SectionsTests
{
    [Theory]
    [InlineData("2-4,6-8")]
    [InlineData("2-3,4-5")]
    [InlineData("5-7,7-9")]
    [InlineData("2-8,3-7")]
    [InlineData("6-6,4-6")]
    [InlineData("2-6,4-8")]
    public void Assignments_Count(string assignments)
    {
        var pair = Section.Initialize(assignments);
        Assert.Equal(2, pair.Assignments.Count);
    }

    [Theory]
    [InlineData(false, "2-4,6-8")]
    [InlineData(false, "2-3,4-5")]
    [InlineData(false, "5-7,7-9")]
    [InlineData(true, "2-8,3-7")]
    [InlineData(true, "6-6,4-6")]
    [InlineData(false, "2-6,4-8")]
    public void AssignmentsAreContained(bool expected, string assignments)
    {
        var pair = Section.Initialize(assignments);
        Assert.Equal(expected, pair.AssignmentsAreContained);
    }      
}