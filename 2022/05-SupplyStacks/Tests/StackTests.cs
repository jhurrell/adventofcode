using System.Diagnostics.Contracts;
using Code;

namespace Tests;

public class StackTests
{
    public string[] Puzzle = new string[]
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

    [Fact]
    public void Initialize_ToList()
    {
        var stacks = Stack.Initialize(Puzzle);
        Assert.Collection(stacks, 
            item => 
            {
                Assert.Equal(1, item.Key);
                Assert.Collection(item.Value.Crates, 
                    item => Assert.Equal('Z', item),
                    item => Assert.Equal('N', item)
                );
            },
            item => 
            {
                Assert.Equal(2, item.Key);
                Assert.Collection(item.Value.Crates, 
                    item => Assert.Equal('M', item),
                    item => Assert.Equal('C', item),
                    item => Assert.Equal('D', item)
                );
            },
            item => 
            {
                Assert.Equal(3, item.Key);
                Assert.Collection(item.Value.Crates, 
                    item => Assert.Equal('P', item)
                );
            }            
        );
    }

    [Fact]
    public void Pop_1()
    {
        var stacks = Stack.Initialize(Puzzle);
        var stack = stacks[1];

        Assert.Collection(stack.Pop(1),
            item => Assert.Equal('N', item)
        );

        Assert.Collection(stack.Crates, 
            item => Assert.Equal('Z', item)
        );
    }

    [Fact]
    public void Pop_2()
    {
        var stacks = Stack.Initialize(Puzzle);
        var stack = stacks[2];

        Assert.Collection(stack.Pop(2),
            item => Assert.Equal('C', item),
            item => Assert.Equal('D', item)
        );

        Assert.Collection(stack.Crates, 
            item => Assert.Equal('M', item)
        );
    }    
}