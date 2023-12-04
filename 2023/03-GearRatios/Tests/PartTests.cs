using Code;

namespace Tests;

public class PartTests
{

    [Fact]
    public void Initialize_WhenSomeNumbersAreAtTheEndOfTheLine()
    {
        var schematic = new string[]
        {
            "123..456"
        };

        var parts = Part.Initialize(schematic);

        Assert.Collection(parts, 
            item => {
                Assert.Equal(0, item.Row);
                Assert.Equal(0, item.StartIndex);
                Assert.Equal(2, item.EndIndex);
                Assert.Equal("123", item.Number);
            },
            item => {
                Assert.Equal(0, item.Row);
                Assert.Equal(5, item.StartIndex);
                Assert.Equal(7, item.EndIndex);
                Assert.Equal("456", item.Number);
            }
        );       
    }

    [Fact]
    public void Initialize()
    {
        var schematic = new string[]
        {
            "467..114..",   // 0
            "...*......",   // 1
            "..35..633.",   // 2
            "......#...",   // 3
            "617*......",   // 4
            ".....+.58.",   // 5
            "..592.....",   // 6
            "......755.",   // 7
            "...$.*....",   // 8
            ".664.598.."    // 9    
        };

        var parts = Part.Initialize(schematic);
        
        Assert.Collection(parts, 
            // 0: 467..114..
            item => {
                Assert.Equal(0, item.Row);
                Assert.Equal(0, item.StartIndex);
                Assert.Equal(2, item.EndIndex);
                Assert.Equal("467", item.Number);
            },
            item => {
                Assert.Equal(0, item.Row);
                Assert.Equal(5, item.StartIndex);
                Assert.Equal(7, item.EndIndex);
                Assert.Equal("114", item.Number);
            },

            // 1: ...*......

            // 2: ..35..633. 
            item => {
                Assert.Equal(2, item.Row);
                Assert.Equal(2, item.StartIndex);
                Assert.Equal(3, item.EndIndex);
                Assert.Equal("35", item.Number);
            },
            item => {
                Assert.Equal(2, item.Row);
                Assert.Equal(6, item.StartIndex);
                Assert.Equal(8, item.EndIndex); 
                Assert.Equal("633", item.Number);
            },

            // 3: ......#...

            // 4: 617*......
            item => {
                Assert.Equal(4, item.Row);
                Assert.Equal(0, item.StartIndex);
                Assert.Equal(2, item.EndIndex);
                Assert.Equal("617", item.Number);
            },

            // 5: .....+.58.
            item => {
                Assert.Equal(5, item.Row);
                Assert.Equal(7, item.StartIndex);
                Assert.Equal(8, item.EndIndex);      
                Assert.Equal("58", item.Number);
            },


            // 6: ..592.....
            item => {
                Assert.Equal(6, item.Row);
                Assert.Equal(2, item.StartIndex);
                Assert.Equal(4, item.EndIndex);
                Assert.Equal("592", item.Number);
            },

            // 7: ......755.
            item =>
            {
                Assert.Equal(7, item.Row);
                Assert.Equal(6, item.StartIndex);
                Assert.Equal(8, item.EndIndex);
                Assert.Equal("755", item.Number);
            },

            // 8: ...$.*....       

            // 9: .664.598..
            item => {
                Assert.Equal(9, item.Row);
                Assert.Equal(1, item.StartIndex);
                Assert.Equal(3, item.EndIndex);
                Assert.Equal("664", item.Number);                
            },
            item => {
                Assert.Equal(9, item.Row);
                Assert.Equal(5, item.StartIndex);
                Assert.Equal(7, item.EndIndex);
                Assert.Equal("598", item.Number);                   
            }                    
        );
    }

    [Theory]
    [InlineData(false, 0, 0)]
    [InlineData(true, 0, 1)]
    [InlineData(true, 0, 2)]
    [InlineData(true, 0, 3)]
    [InlineData(false, 0, 4)]
    [InlineData(false, 1, 0)]
    [InlineData(false, 1, 1)]
    [InlineData(false, 1, 2)]
    [InlineData(false, 1, 3)]
    [InlineData(false, 1, 4)]    
    public void ExistsAtPosition(bool expected, int row, int column)
    {
        var schematic = new string[] { ".123." };
        var part = Part.Initialize(schematic).First();

        Assert.Equal(expected, part.ExistsAtPosition(row, column));
    }
}