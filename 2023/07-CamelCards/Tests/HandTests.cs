using Code;

namespace Tests;

public class HandTests 
{
    [Theory]
    [InlineData('A', "AAAAA")]  // Five of a kind
    [InlineData('B', "AA8AA")]  // Four of a kind
    [InlineData('C', "23332")]  // Full house
    [InlineData('D', "TTT98")]  // Three of a kind
    [InlineData('E', "23432")]  // Two pair
    [InlineData('F', "A23A4")]  // One pair
    [InlineData('G', "23456")]  // High card
    public void Initialize_Single(char expectedRank, string cards)
    {
        Assert.Equal(expectedRank, Hand.HandRank(cards));
    }

    [Fact]
    public void Initialize_Collection()
    {
        var hands = Hand.Initialize(File.ReadAllLines("PuzzleExample.txt"));
        Assert.Collection(hands, 
            item => Assert.Equal("32T3K", item.Cards),
            item => Assert.Equal("KTJJT", item.Cards),
            item => Assert.Equal("KK677", item.Cards),
            item => Assert.Equal("T55J5", item.Cards),
            item => Assert.Equal("QQQJA", item.Cards)
        );
    }    

    [Theory]
    [InlineData("A-AAAAA", "AAAAA 1")]  // Five of a kind (A)
    [InlineData("A-BBBBB", "KKKKK 1")]  // Five of a kind (K)
    public void RankKey(string expected, string cards)
    {
        var hand = Hand.Initialize(cards);
        Assert.Equal(expected, hand.RankKey);
    }

    [Theory]
    [InlineData(6440, "PuzzleExample.txt")]
    [InlineData(247823654, "Puzzle.txt")]
    public void GetTotalWinnings(int expected, string puzzleFilePath)
    {
        var hands = Hand.Initialize(File.ReadAllLines(puzzleFilePath));
        Assert.Equal(expected, Hand.GetTotalWinnings(hands));
    }
}