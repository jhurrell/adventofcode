namespace RockPaperScissors.Tests;

public class TournamentTests
{
    [Fact]
    public void PlayShapeShapeRounds()
    {
        var rounds = new List<string>
        {
            "A Y",
            "B X",
            "C Z",
        };

        Assert.Equal(15, Tournament.PlayShapeShapeRounds(rounds));
    }

    [Fact]
    public void PlayWinLoseDrawRounds()
    {
        var rounds = new List<string>
        {
            "A Y",
            "B X",
            "C Z",
        };

        Assert.Equal(12, Tournament.PlayWinLoseDrawRounds(rounds));
    }    
}