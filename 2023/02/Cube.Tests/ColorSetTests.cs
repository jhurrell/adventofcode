namespace Cube.Tests;

public class ColorSetTests
{
    [Theory]
    [InlineData(4, 0, 3, "3 blue, 4 red")]
    [InlineData(1, 2, 6, "1 red, 2 green, 6 blue")]
    [InlineData(0, 2, 0, "2 green")]
    public void ColorSet_Constructor(
        int expectedRed, 
        int expectedGreen, 
        int expectedBlue, 
        string colorSets)
    {
        var colorSet = new ColorSet(colorSets);
        Assert.Equal(expectedRed, colorSet.Red);
        Assert.Equal(expectedGreen, colorSet.Green);
        Assert.Equal(expectedBlue, colorSet.Blue);
    }

    [Fact]
    public void InitializeColorSet_Game_1()
    {
        var colorSets = ColorSet.InitializeColorSet("3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green");
        Assert.Collection(colorSets, 
            item => {
                Assert.Equal(4, item.Red);
                Assert.Equal(0, item.Green);
                Assert.Equal(3, item.Blue);
            },
            item => {
                Assert.Equal(1, item.Red);
                Assert.Equal(2, item.Green);
                Assert.Equal(6, item.Blue);
            },
            item => {
                Assert.Equal(0, item.Red);
                Assert.Equal(2, item.Green);
                Assert.Equal(0, item.Blue);
            }
        );
    }

    [Fact]
    public void InitializeColorSet_Game_2()
    {
        var colorSets = ColorSet.InitializeColorSet("1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue");
        Assert.Collection(colorSets, 
            item => {
                Assert.Equal(0, item.Red);
                Assert.Equal(2, item.Green);
                Assert.Equal(1, item.Blue);
            },
            item => {
                Assert.Equal(1, item.Red);
                Assert.Equal(3, item.Green);
                Assert.Equal(4, item.Blue);
            },
            item => {
                Assert.Equal(0, item.Red);
                Assert.Equal(1, item.Green);
                Assert.Equal(1, item.Blue);
            }
        );
    }
   
    [Fact]
    public void InitializeColorSet_Game_3()
    {
        var colorSets = ColorSet.InitializeColorSet("8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red");
        Assert.Collection(colorSets, 
            item => {
                Assert.Equal(20, item.Red);
                Assert.Equal(8, item.Green);
                Assert.Equal(6, item.Blue);
            },
            item => {
                Assert.Equal(4, item.Red);
                Assert.Equal(13, item.Green);
                Assert.Equal(5, item.Blue);
            },
            item => {
                Assert.Equal(1, item.Red);
                Assert.Equal(5, item.Green);
                Assert.Equal(0, item.Blue);
            }
        );
    } 
      
    [Fact]
    public void InitializeColorSet_Game_4()
    {
        var colorSets = ColorSet.InitializeColorSet("1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red");
        Assert.Collection(colorSets, 
            item => {
                Assert.Equal(3, item.Red);
                Assert.Equal(1, item.Green);
                Assert.Equal(6, item.Blue);
            },
            item => {
                Assert.Equal(6, item.Red);
                Assert.Equal(3, item.Green);
                Assert.Equal(0, item.Blue);
            },
            item => {
                Assert.Equal(14, item.Red);
                Assert.Equal(3, item.Green);
                Assert.Equal(15, item.Blue);
            }
        );
    } 
   
    [Fact]
    public void InitializeColorSet_Game_5()
    {
        var colorSets = ColorSet.InitializeColorSet("6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green");
        Assert.Collection(colorSets, 
            item => {
                Assert.Equal(6, item.Red);
                Assert.Equal(3, item.Green);
                Assert.Equal(1, item.Blue);
            },
            item => {
                Assert.Equal(1, item.Red);
                Assert.Equal(2, item.Green);
                Assert.Equal(2, item.Blue);
            }
        );
    }      
}
