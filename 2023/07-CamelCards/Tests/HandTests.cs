using Code;

namespace Tests;

public class HandTests 
{
    [Fact]
    public void Initialize_Collection()
    {
        var hands = Hand.Initialize(File.ReadAllLines("PuzzleExample.txt"));
        Assert.Collection(hands, 
            item => 
            {
                Assert.Equal("32T3K", item.Cards);
                Assert.Equal(765, item.Bid);
            },
            item => 
            {
                Assert.Equal("T55J5", item.Cards);
                Assert.Equal(684, item.Bid);
            },
            item => 
            {
                Assert.Equal("KK677", item.Cards);
                Assert.Equal(28, item.Bid);
            },
            item => 
            {
                Assert.Equal("KTJJT", item.Cards);
                Assert.Equal(220, item.Bid);
            },
            item => 
            {
                Assert.Equal("QQQJA", item.Cards);
                Assert.Equal(483, item.Bid);
            }
        );
    }   

    [Theory]
    [InlineData("A-AAAAA", "AAAAA")]  // Five of a kind
    [InlineData("B-AAGAA", "AA8AA")]  // Four of a kind
    [InlineData("C-MLLLM", "23332")]  // Full house
    [InlineData("D-EEEFG", "TTT98")]  // Three of a kind
    [InlineData("E-MLKLM", "23432")]  // Two pair
    [InlineData("F-AMLAK", "A23A4")]  // One pair
    [InlineData("G-MLKJI", "23456")]  // High card
    public void SortKey(string expected, string cards)
    {
        var hand = new Hand { Cards = cards };
        Assert.Equal(expected, hand.SortKey);
    }

    [Theory]
    [InlineData(6440, "PuzzleExample.txt")]
    [InlineData(247823654, "Puzzle.txt")]
    public void GetTotalWinnings(int expected, string puzzleFilePath)
    {
        var hands = Hand.Initialize(File.ReadAllLines(puzzleFilePath));
        Assert.Equal(expected, Hand.GetTotalWinnings(hands));
    }

    [Theory]
    [InlineData(5905, "PuzzleExample.txt")]
    [InlineData(245461700, "Puzzle.txt")]
    public void GetTotalWinningsJokersWild(int expected, string puzzleFilePath)
    {
        var hands = Hand.Initialize(File.ReadAllLines(puzzleFilePath));
        Assert.Equal(expected, Hand.GetTotalWinningsJokersWild(hands));
    } 
}