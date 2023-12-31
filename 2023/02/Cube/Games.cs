namespace Cube;

// Games is a container class that stores all the games. Additionally, it
// exposes some aggregate methods assist in testing and to actually answer
// the questions posed in Parts 1 and 2.
public class Games
{
    public List<Game> AllGames { get; init; } = new();

    public static Games Initialize(List<string> gameResults)
    {
        var games = new Games 
        {
            AllGames = gameResults.Select(g => new Game(g)).ToList()
        };

        return games;
    }

    public List<Game> GetPossibleGames(int red, int green, int blue) => 
        AllGames.Where(g => g.WasGamePossible(red, green, blue)).ToList();

    public int GetPossibleGamesCount(int red, int green, int blue) => 
        GetPossibleGames(red, green, blue).Count;

    public int GetPossibleGamesIdSum(int red, int green, int blue) => 
        GetPossibleGames(red, green, blue).Sum(g => g.GameId);

    public int GetPower() => 
        AllGames.Sum(g => g.Power);
}
