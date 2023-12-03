namespace Cube;

// A Game represents single record or line from the file. It will read and understand
// a string that follows the pattern:
// Game #: # color # color; #color, #color, #color...
// for example:
// Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green
// Game 10: 6 blue, 1 green, 1 red; 17 red, 8 blue, 1 green; 4 blue, 10 red
// Game 100: 10 red; 11 blue, 12 red; 1 green, 7 blue, 6 red
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

    // Calculate whether the game was possible by comparing the number of each
    // color that might be in the bag, compared to the largest number of each
    // color that was actually PULLED from the bag.
    public bool WasGamePossible(int red, int green, int blue)
    {
        return ColorSets
            .All(c => c.Red <= red && c.Green <= green && c.Blue <= blue);
    }

    // What is the fewest number of cubes of each color that could have been in 
    // the bag to make the game possible?
    // Now, at first, you might think they are asking for the smallest number, but
    // in reality, they are asking us to find the LARGEST number needed to have
    // made the game possible. For example, if we pulled out 1 red, then 2, then 5,
    // we would have needed 5. Calculate the number of each color needed.
    public int MaximumRed
    {
        get 
        {
            return ColorSets.Max(s => s.Red);
        }
    }

    public int MaximumGreen
    {
        get 
        {
            return ColorSets.Max(s => s.Green);
        }
    }    

    public int MaximumBlue
    {
        get 
        {
            return ColorSets.Max(s => s.Blue);
        }
    } 

    // Calculate the "power" of the minimum number of each color needed.
    // This is basically multiplying red * green * blue.
    public int Power
    {
        get 
        {
            return MaximumRed * MaximumGreen * MaximumBlue;
        }
    } 
}
