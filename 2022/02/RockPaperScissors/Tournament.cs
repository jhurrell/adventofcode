namespace RockPaperScissors;

public static class Tournament
{
    public static int PlayShapeShapeRounds(List<string> rounds)    
    {
        var results = new List<Round>{};
        results.AddRange(rounds.Select(r => Round.InitializeShapeShape(r)));
        return results.Sum(r => r.TotalScore);
    }

    public static int PlayWinLoseDrawRounds(List<string> rounds)    
    {
        var results = new List<Round>{};
        results.AddRange(rounds.Select(r => Round.InitializeWinLoseDraw(r)));
        return results.Sum(r => r.TotalScore);
    }
}
