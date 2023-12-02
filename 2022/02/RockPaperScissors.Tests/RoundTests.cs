namespace RockPaperScissors.Tests;

public class RoundTests
{
    [Theory]
    [InlineData(8, "A Y")]
    [InlineData(1, "B X")]
    [InlineData(6, "C Z")]
    public void InitializeShapeShape(int expected, string round)
    {
        Assert.Equal(expected, Round.InitializeShapeShape(round).TotalScore);
    }

    [Theory]
    [InlineData(4, "A Y")]
    [InlineData(1, "B X")]
    [InlineData(7, "C Z")]
    public void InitializeShapeOutcomeExamples(int expected, string round)
    {
        Assert.Equal(expected, Round.InitializeWinLoseDraw(round).TotalScore);
    }     

    [Theory]
    [InlineData(0 + 3, "A X")]
    [InlineData(3 + 1, "A Y")]
    [InlineData(6 + 2, "A Z")]

    [InlineData(0 + 1, "B X")]
    [InlineData(3 + 2, "B Y")]
    [InlineData(6 + 3, "B Z")]

    [InlineData(0 + 2, "C X")]
    [InlineData(3 + 3, "C Y")]
    [InlineData(6 + 1, "C Z")]
    public void InitializeShapeOutcome(int expected, string round)
    {
        Assert.Equal(expected, Round.InitializeWinLoseDraw(round).TotalScore);
    }    
}
