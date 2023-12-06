using Code;

namespace Tests;

public class RacesTests
{
    [Theory]
    [InlineData(288, "PuzzleExample.txt")]
    [InlineData(1155175, "Puzzle.txt")]
    public void ExecutePart1(int expected, string puzzlePath)
    {
        Assert.Equal(expected, Races.ExecutePart1(File.ReadAllLines(puzzlePath)));
    }

    [Theory]
    [InlineData(71503, "PuzzleExample.txt")]
    [InlineData(35961505, "Puzzle.txt")]
    public void ExecutePart2(int expected, string puzzlePath)
    {
        Assert.Equal(expected, Races.ExecutePart2(File.ReadAllLines(puzzlePath)));
    }    
}