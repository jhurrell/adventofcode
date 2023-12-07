using Code;

namespace Tests;

public class CardTests
{
    [Theory]
    [InlineData('A', 'A')]
    [InlineData('B', 'K')]
    [InlineData('C', 'Q')]
    [InlineData('D', 'J')]
    [InlineData('E', 'T')]
    [InlineData('F', '9')]
    [InlineData('G', '8')]
    [InlineData('H', '7')]
    [InlineData('I', '6')]
    [InlineData('J', '5')]
    [InlineData('K', '4')]
    [InlineData('L', '3')]
    [InlineData('M', '2')]
    [InlineData('.', 'X')]
    public void Transform_Character(char expected, char label)
    {
        Assert.Equal(expected, Card.Transform(label));
    }

    [Fact]
    public void Transform_String()
    {
        Assert.Equal("ABCDEFGHIJKLM", Card.Transform("AKQJT98765432"));
    }

    [Theory]
    [InlineData('A', 'A')]
    [InlineData('B', 'K')]
    [InlineData('C', 'Q')]
    [InlineData('D', 'T')]
    [InlineData('E', '9')]
    [InlineData('F', '8')]
    [InlineData('G', '7')]
    [InlineData('H', '6')]
    [InlineData('I', '5')]
    [InlineData('J', '4')]
    [InlineData('K', '3')]
    [InlineData('L', '2')]
    [InlineData('Z', 'J')]
    [InlineData('.', 'X')]
    public void TransformJokersWild_Character(char expected, char label)
    {
        Assert.Equal(expected, Card.TransformJokersWild(label));
    }  

    [Fact]
    public void TransformJokersWild_String()
    {
        Assert.Equal("ABCZDEFGHIJKL", Card.TransformJokersWild("AKQJT98765432"));
    }    
}