namespace Cube;

public class Game
{
    public int GameId { get; set; }
    public List<ColorSet> ColorSets { get; set; } = new();

    public Game(string gameResults)
    {
        // Extract the Game ID.
        var gameParts = gameResults.Split(":");
        GameId = int.Parse(gameParts[0].Replace("Game ", ""));
        ColorSets = ColorSet.InitializeColorSet(gameParts[1]);
    }

    public bool WasGamePossible(int red, int green, int blue)
    {
        return ColorSets
            .All(c => c.Red <= red && c.Green <= green && c.Blue <= blue);
    }
}
