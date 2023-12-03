namespace Code;

public class Assignment
{
    public int Min { get; init; } = 0;
    public int Max { get; init; } = 0;

    public static Assignment Initialize(string assignment)
    {
        var ranges = assignment.Split("-");
        return new Assignment 
        {
            Min = int.Parse(ranges[0]),
            Max = int.Parse(ranges[1]),
        };
    }

    public static bool IsFullyContained(Assignment saA, Assignment saB)
    {
        return saA.Min >= saB.Min && saA.Max <= saB.Max || saB.Min >= saA.Min && saB.Max <= saA.Max;
    }
}
