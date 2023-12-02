namespace RockPaperScissors;

public class Round
{
    public static Dictionary<string, int> OutcomeScoreKey = new()
    {
        // opponent/self
        // 1 = rock, 2 = paper, 3 = scissors
        { "A X", 3 + 1 },   // rock/rock
        { "A Y", 6 + 2 },   // rock/paper
        { "A Z", 0 + 3 },   // rock/scissors

        { "B X", 0 + 1 },   // paper/rock
        { "B Y", 3 + 2 },   // paper/paper
        { "B Z", 6 + 3 },   // paper/scissors

        { "C X", 6 + 1 },   // scissors/rock
        { "C Y", 0 + 2 },   // scissors/paper
        { "C Z", 3 + 3 },   // scissors/scissors
    };

    public static Dictionary<string, int> DesiredShapeKey = new()
    {
        // X = lose, Y = draw, Z = win
        // 1 = rock, 2 = paper, 3 = scissors
        { "A X", 0 + 3 },   // rock/lose by choosing scissors
        { "A Y", 3 + 1 },   // rock/draw by choosing rock
        { "A Z", 6 + 2 },   // rock/win by choosing paper

        { "B X", 0 + 1 },   // paper/lose by choosing rock
        { "B Y", 3 + 2 },   // paper/draw by choosing paper
        { "B Z", 6 + 3 },   // paper/win by choosing scissors

        { "C X", 0 + 2 },   // scissors/lose by choosing paper
        { "C Y", 3 + 3 },   // scissors/draw by choosing scissors
        { "C Z", 6 + 1 },   // scissors/win by choosing rock
    };

    public int TotalScore { get; init; }

    public Round(int totalScore)
    {
        TotalScore = totalScore;
    }

    public static Round InitializeShapeShape(string round) 
    {
        return new Round(OutcomeScoreKey[round]);
    }

    public static Round InitializeWinLoseDraw(string round) 
    {
        return new Round(DesiredShapeKey[round]);
    }
}
