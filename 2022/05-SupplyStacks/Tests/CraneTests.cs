using Code;

namespace Tests;

public class CraneTests
{
    [Fact]
    public void MovementsWithPop()
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

        var stacks = Stack.Initialize(puzzle);
        var movements = Movement.Initialize(puzzle);
        var results = Crane.PerformMovementsWithPop(stacks, movements);

        Assert.Collection(results, 
            item => 
            {
                Assert.Equal(1, item.Key);
                Assert.Collection(item.Value.Crates, 
                    crate => Assert.Equal('C', crate)
                );
            },
            item => 
            {
                Assert.Equal(2, item.Key);
                Assert.Collection(item.Value.Crates, 
                    crate => Assert.Equal('M', crate)
                );
            },
            item => 
            {
                Assert.Equal(3, item.Key);
                Assert.Collection(item.Value.Crates, 
                    crate => Assert.Equal('P', crate),
                    crate => Assert.Equal('D', crate),
                    crate => Assert.Equal('N', crate),
                    crate => Assert.Equal('Z', crate)
                );
            }
        );
    }

    [Fact]
    public void TopCratesWithPop()
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

        var stacks = Stack.Initialize(puzzle);
        var movements = Movement.Initialize(puzzle);
        var results = Crane.GetTopCratesFromPopMovements(stacks, movements);

        Assert.Equal("CMZ", results);
    }


   [Fact]
    public void MovementsWithDequeue()
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

        var stacks = Stack.Initialize(puzzle);
        var movements = Movement.Initialize(puzzle);
        var results = Crane.PerformMovementsWithDequeue(stacks, movements);

        Assert.Collection(results, 
            item => 
            {
                Assert.Equal(1, item.Key);
                Assert.Collection(item.Value.Crates, 
                    crate => Assert.Equal('M', crate)
                );
            },
            item => 
            {
                Assert.Equal(2, item.Key);
                Assert.Collection(item.Value.Crates, 
                    crate => Assert.Equal('C', crate)
                );
            },
            item => 
            {
                Assert.Equal(3, item.Key);
                Assert.Collection(item.Value.Crates, 
                    crate => Assert.Equal('P', crate),
                    crate => Assert.Equal('Z', crate),
                    crate => Assert.Equal('N', crate),
                    crate => Assert.Equal('D', crate)
                );
            }
        );
    }

    [Fact]
    public void TopCratesWithDequeue()
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

        var stacks = Stack.Initialize(puzzle);
        var movements = Movement.Initialize(puzzle);
        var results = Crane.GetTopCratesFromDequeueMovements(stacks, movements);

        Assert.Equal("MCD", results);
    }    
}