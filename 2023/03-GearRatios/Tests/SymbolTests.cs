using Code;

namespace Tests;

public class SymbolTests
{
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

        var symbols = Symbol.Initialize(schematic);

        Assert.Collection(symbols, 
            item => 
            {
                Assert.Equal(1, item.Row);
                Assert.Equal(3, item.Column);
                Assert.Equal('*', item.Value);
            },
            item => 
            {
                Assert.Equal(3, item.Row);
                Assert.Equal(6, item.Column);
                Assert.Equal('#', item.Value);
            },
            item => 
            {
                Assert.Equal(4, item.Row);
                Assert.Equal(3, item.Column);
                Assert.Equal('*', item.Value);
            } ,
            item => 
            {
                Assert.Equal(5, item.Row);
                Assert.Equal(5, item.Column);
                Assert.Equal('+', item.Value);
            },
            item => 
            {
                Assert.Equal(8, item.Row);
                Assert.Equal(3, item.Column);
                Assert.Equal('$', item.Value);
            },
            item => 
            {
                Assert.Equal(8, item.Row);
                Assert.Equal(5, item.Column);
                Assert.Equal('*', item.Value);
            }                           
        );
    }    

    [Theory]
    //[InlineData(0, 0, 0)]
    [InlineData(2, 0, 1)]
    [InlineData(1, 0, 2)]
    [InlineData(0, 0, 3)]
    [InlineData(0, 0, 4)]
    [InlineData(0, 0, 5)]
    [InlineData(0, 0, 6)]

    [InlineData(3, 1, 0)]
    //[InlineData(0, 1, 1)]
    [InlineData(2, 1, 2)]
    [InlineData(1, 1, 3)]
    [InlineData(1, 1, 4)]
    [InlineData(0, 1, 5)]
    [InlineData(0, 1, 6)] 

    //[InlineData(0, 2, 0)]
    [InlineData(2, 2, 1)]
    [InlineData(2, 2, 2)]
    //[InlineData(1, 2, 3)]
    [InlineData(1, 2, 4)]
    [InlineData(0, 2, 5)]
    [InlineData(0, 2, 6)]    
    public void GetAdjacentParts(int expected, int row, int column) 
    {
        var schematic = new string[] 
        {
            "1......",
            ".2.....",
            "3..4...",
        };

        var parts = Part.Initialize(schematic);
        var adjacentParts = Symbol.GetAdjacentParts(parts, row, column);
        Assert.Equal(expected, adjacentParts.Count);
    }

    [Fact]
    public void GetAdjacentPartsSum()
    {
        var schematic = new string[] 
        {
            "467..114..",
            "...*......",
            "..35..633.",
            "......#...",
            "617*......",
            ".....+.58.",
            "..592.....",
            "......755.",
            "...$.*....",
            ".664.598..",
        };

        var parts = Part.Initialize(schematic);
        var symbols = Symbol.Initialize(schematic);

        Assert.Equal(4361, Symbol.GetAdjacentPartsSum(symbols, parts));
    }

    [Fact]
    public void GetAdjacentGearRatioSums()
    {
        var schematic = new string[] 
        {
            "467..114..",
            "...*......",
            "..35..633.",
            "......#...",
            "617*......",
            ".....+.58.",
            "..592.....",
            "......755.",
            "...$.*....",
            ".664.598..",
        };

        var parts = Part.Initialize(schematic);
        var symbols = Symbol.Initialize(schematic);

        Assert.Equal(467835, Symbol.GetAdjacentGearRatioSums(symbols, parts));
    }    
}
