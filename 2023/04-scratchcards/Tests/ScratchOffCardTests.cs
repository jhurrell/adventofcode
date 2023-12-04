using Code;

namespace Tests;

public class ScratchOffCardTests
{
    [Theory]
    [InlineData(1, "Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53")]
    [InlineData(2, "Card 2: 13 32 20 16 61 | 61 30 68 82 17 32 24 19")]
    [InlineData(3, "Card 3:  1 21 53 59 44 | 69 82 63 72 16 21 14  1")]
    [InlineData(4, "Card 4: 41 92 73 84 69 | 59 84 76 51 58  5 54 83")]
    [InlineData(5, "Card 5: 87 83 26 28 32 | 88 30 70 12 93 22 82 36")]
    [InlineData(6, "Card 6: 31 18 13 56 72 | 74 77 10 23 35 67 36 11")]
    public void Initialize_CardNumber(int expected, string game)
    {
        var card = ScratchOffCard.Initialize(game);
        Assert.Equal(expected, card.CardNumber);
    }

    [Theory]
    [InlineData(4, "Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53")]
    [InlineData(2, "Card 2: 13 32 20 16 61 | 61 30 68 82 17 32 24 19")]
    [InlineData(2, "Card 3:  1 21 53 59 44 | 69 82 63 72 16 21 14  1")]
    [InlineData(1, "Card 4: 41 92 73 84 69 | 59 84 76 51 58  5 54 83")]
    [InlineData(0, "Card 5: 87 83 26 28 32 | 88 30 70 12 93 22 82 36")]
    [InlineData(0, "Card 6: 31 18 13 56 72 | 74 77 10 23 35 67 36 11")]
    public void MatchingNumbers_Count(int expected, string game)
    {
        var card = ScratchOffCard.Initialize(game);
        Assert.Equal(expected, card.MatchingNumbers.Count);
    }   

    [Theory]
    [InlineData(8, "Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53")]
    [InlineData(2, "Card 2: 13 32 20 16 61 | 61 30 68 82 17 32 24 19")]
    [InlineData(2, "Card 3:  1 21 53 59 44 | 69 82 63 72 16 21 14  1")]
    [InlineData(1, "Card 4: 41 92 73 84 69 | 59 84 76 51 58  5 54 83")]
    [InlineData(0, "Card 5: 87 83 26 28 32 | 88 30 70 12 93 22 82 36")]
    [InlineData(0, "Card 6: 31 18 13 56 72 | 74 77 10 23 35 67 36 11")]
    public void Points(int expected, string game)
    {
        var card = ScratchOffCard.Initialize(game);
        Assert.Equal(expected, card.Points);
    } 

    [Fact]
    public void PointsSum()
    {
        var games = new List<string>
        {
            "Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53",
            "Card 2: 13 32 20 16 61 | 61 30 68 82 17 32 24 19",
            "Card 3:  1 21 53 59 44 | 69 82 63 72 16 21 14  1",
            "Card 4: 41 92 73 84 69 | 59 84 76 51 58  5 54 83",
            "Card 5: 87 83 26 28 32 | 88 30 70 12 93 22 82 36",
            "Card 6: 31 18 13 56 72 | 74 77 10 23 35 67 36 11"
        };

        var cards = ScratchOffCard.Initialize(games);
        Assert.Equal(13, cards.Sum(c => c.Points));
    }  

    [Fact]
    public void WonCards_Game_1()
    {
        var card = ScratchOffCard.Initialize("Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53");

        Assert.Collection(card.WonCards, 
            item => Assert.Equal(2, item),
            item => Assert.Equal(3, item),
            item => Assert.Equal(4, item),
            item => Assert.Equal(5, item)
        );
    } 

    [Fact]
    public void WonCards_Game_2()
    {
        var card = ScratchOffCard.Initialize("Card 2: 13 32 20 16 61 | 61 30 68 82 17 32 24 19");

        Assert.Collection(card.WonCards, 
            item => Assert.Equal(3, item),
            item => Assert.Equal(4, item)
        );
    }

    [Fact]
    public void WonCards_Game_3()
    {
        var card = ScratchOffCard.Initialize("Card 3:  1 21 53 59 44 | 69 82 63 72 16 21 14  1");

        Assert.Collection(card.WonCards, 
            item => Assert.Equal(4, item),
            item => Assert.Equal(5, item)
        );
    }

    [Fact]
    public void GetWinnersCardNumbers_Count()
    {
        var games = new List<string>
        {
            "Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53",
            "Card 2: 13 32 20 16 61 | 61 30 68 82 17 32 24 19",
            "Card 3:  1 21 53 59 44 | 69 82 63 72 16 21 14  1",
            "Card 4: 41 92 73 84 69 | 59 84 76 51 58  5 54 83",
            "Card 5: 87 83 26 28 32 | 88 30 70 12 93 22 82 36",
            "Card 6: 31 18 13 56 72 | 74 77 10 23 35 67 36 11"
        };

        var cards = ScratchOffCard.Initialize(games);
        var winningNumber = ScratchOffCard.GetWinnersCardNumbers(cards);
        Assert.Equal(30, winningNumber.Count);        
        //Assert.True(true);
    }
}