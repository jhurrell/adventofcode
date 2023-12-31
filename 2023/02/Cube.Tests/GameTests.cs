namespace Cube.Tests;

public class GameTests
{
    [Theory]
    [InlineData(1, "Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green")]
    [InlineData(2, "Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue")]
    [InlineData(3, "Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red")]
    [InlineData(4, "Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red")]
    [InlineData(5, "Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green")]
    [InlineData(123, "Game 123: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green")]
    public void GameId_CanBeParsedFromGameResultsString(int expected, string gameResults)
    {
        var game = new Game(gameResults);
        Assert.Equal(expected, game.GameId);
    }

    [Theory]
    [InlineData(3, "Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green")]
    [InlineData(3, "Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue")]
    [InlineData(3, "Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red")]
    [InlineData(3, "Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red")]
    [InlineData(2, "Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green")]
    public void ColorSets_CanBeParsedFromGameResultsString(int expected, string gameResults)
    {
        var game = new Game(gameResults);
        Assert.Equal(expected, game.ColorSets.Count);
    }

    [Theory]
    [InlineData(true, "Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green")]
    [InlineData(true, "Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue")]
    [InlineData(false, "Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red")]
    [InlineData(false, "Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red")]
    [InlineData(true, "Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green")]
    public void WasGamePossible(bool expected, string gameResults)
    {
        var game = new Game(gameResults);
        Assert.Equal(expected, game.WasGamePossible(12, 13, 14));
    }

    [Theory]
    [InlineData(4, "Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green")]
    [InlineData(1, "Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue")]
    [InlineData(20, "Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red")]
    [InlineData(14, "Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red")]
    [InlineData(6, "Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green")]
    public void MinimumRed(int expected, string gameResults)
    {
        var game = new Game(gameResults);
        Assert.Equal(expected, game.MaximumRed);
    }

    [Theory]
    [InlineData(2, "Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green")]
    [InlineData(3, "Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue")]
    [InlineData(13, "Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red")]
    [InlineData(3, "Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red")]
    [InlineData(3, "Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green")]
    public void MinimumGreen(int expected, string gameResults)
    {
        var game = new Game(gameResults);
        Assert.Equal(expected, game.MaximumGreen);
    }    

    [Theory]
    [InlineData(6, "Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green")]
    [InlineData(4, "Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue")]
    [InlineData(6, "Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red")]
    [InlineData(15, "Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red")]
    [InlineData(2, "Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green")]
    public void MinimumBlue(int expected, string gameResults)
    {
        var game = new Game(gameResults);
        Assert.Equal(expected, game.MaximumBlue);
    }

    [Theory]
    [InlineData(48, "Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green")]
    [InlineData(12, "Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue")]
    [InlineData(1560, "Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red")]
    [InlineData(630, "Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red")]
    [InlineData(36, "Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green")]
    public void Power(int expected, string gameResults)
    {
        var game = new Game(gameResults);
        Assert.Equal(expected, game.Power);
    }              
}