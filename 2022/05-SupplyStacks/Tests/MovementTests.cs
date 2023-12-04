using Code;

namespace Tests;

public class MovementTests
{
    [Theory]
    [InlineData(2, 1, 1, "move 1 from 2 to 1")]
    [InlineData(1, 3, 3, "move 3 from 1 to 3")]
    [InlineData(2, 1, 2, "move 2 from 2 to 1")]
    [InlineData(1, 2, 1, "move 1 from 1 to 2")]
    public void Initialize(int expectedFrom, int expectedTo, int expectedQuantity, string movement)
    {
        var move = Movement.Initialize(movement);
        Assert.Equal(expectedFrom, move.FromStack);
        Assert.Equal(expectedTo, move.ToStack);
        Assert.Equal(expectedQuantity, move.Quantity);
    }

    [Fact]
    public void Initialize_Movements()
    {
        var puzzle = new string[]
        {
            "    [D]    ",
            "[N] [C]    ",
            "[Z] [M] [P]",
            " 1   2   3 ",
            "",
            "move 1 from 2 to 1",
            "move 3 from 1 to 3",
            "move 2 from 2 to 1",
            "move 1 from 1 to 2",
        };

        var movements = Movement.Initialize(puzzle);
        Assert.Collection(movements, 
            item =>
            {
                Assert.Equal(2, item.FromStack);
                Assert.Equal(1, item.ToStack);
                Assert.Equal(1, item.Quantity);
            },
            item =>
            {
                Assert.Equal(1, item.FromStack);
                Assert.Equal(3, item.ToStack);
                Assert.Equal(3, item.Quantity);
            },
            item =>
            {
                Assert.Equal(2, item.FromStack);
                Assert.Equal(1, item.ToStack);
                Assert.Equal(2, item.Quantity);
            },
            item =>
            {
                Assert.Equal(1, item.FromStack);
                Assert.Equal(2, item.ToStack);
                Assert.Equal(1, item.Quantity);
            }                                    
        );
    }
}
