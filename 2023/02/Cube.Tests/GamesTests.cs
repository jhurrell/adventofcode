namespace Cube.Tests;

public class GamesTests
{
    protected List<string> _gamesResults = new()
    {
        "Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green",
        "Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue",
        "Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red",
        "Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red",
        "Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green"
    };

    [Fact]
    public void AllGames()
    {
        var games = Games.Initialize(_gamesResults);
        Assert.Collection(games.AllGames, 
            item => Assert.Equal(1, item.GameId),
            item => Assert.Equal(2, item.GameId),
            item => Assert.Equal(3, item.GameId),
            item => Assert.Equal(4, item.GameId),
            item => Assert.Equal(5, item.GameId)
        );
    } 

    [Fact]
    public void GetPossibleGames()
    {
        var games = Games.Initialize(_gamesResults).GetPossibleGames(12, 13, 14);
        Assert.Collection(games, 
            item => Assert.Equal(1, item.GameId),
            item => Assert.Equal(2, item.GameId),
            item => Assert.Equal(5, item.GameId)
        );
    }    

    [Fact]
    public void GetPossibleGamesCount()
    {
        var games = Games.Initialize(_gamesResults);   
        Assert.Equal(3, games.GetPossibleGamesCount(12, 13, 14));
    }

    [Fact]
    public void GetPossibleGamesIdSum()
    {
        var games = Games.Initialize(_gamesResults);   
        Assert.Equal(8, games.GetPossibleGamesIdSum(12, 13, 14));        
    }
}
