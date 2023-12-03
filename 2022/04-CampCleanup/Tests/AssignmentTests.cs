namespace Tests;

public class SectionAssignmentTests
{
    [Theory]
    [InlineData(2, 4, "2-4")]
    [InlineData(6, 8, "6-8")]
    [InlineData(1, 123, "1-123")]
    [InlineData(123, 456, "123-456")]
    public void SectionAssignment_MinAndMax(int expectedMin, int expectedMax, string assignment)
    {
        var sectionAssignment = Assignment.Initialize(assignment);
        Assert.Equal(expectedMin, sectionAssignment.Min);
        Assert.Equal(expectedMax, sectionAssignment.Max);
    }

    [Theory]
    [InlineData(false, "2-4", "6-8")]
    [InlineData(false, "2-3", "4-5")]
    [InlineData(false, "5-7", "7-9")]
    [InlineData(true, "2-8", "3-7")]
    [InlineData(true, "6-6", "4-6")]
    [InlineData(false, "2-6", "4-8")]
    public void IsFullyContained(bool expected, string assignmentA, string assignmentB)
    {
        var saA = Assignment.Initialize(assignmentA);
        var saB = Assignment.Initialize(assignmentB);
        Assert.Equal(expected, Assignment.IsFullyContained(saA, saB));
    }
}