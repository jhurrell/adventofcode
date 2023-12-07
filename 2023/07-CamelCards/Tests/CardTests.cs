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
    [InlineData('Z', 'X')]
    public void Transform(char expected, char label)
    {
        Assert.Equal(expected, Card.Transform(label));
    }
}