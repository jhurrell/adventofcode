namespace Rucksack.Tests;

public class SackTests
{
    [Theory]
    [InlineData("abc", "123", "abc123")]
    [InlineData("vJrwpWtwJgWr", "hcsFMMfFFhFp", "vJrwpWtwJgWrhcsFMMfFFhFp")]
    [InlineData("jqHRNqRjqzjGDLGL", "rsFMfFZSrLrFZsSL", "jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL")]
    public void CompartmentsSplit(string expectedA, string expectedB, string contents)
    {
        var compartments = Sack.Initialize(contents);
        Assert.Equal(expectedA, compartments.CompartmentA);
        Assert.Equal(expectedB, compartments.CompartmentB);
    }

    [Theory]
    [InlineData('p', "vJrwpWtwJgWrhcsFMMfFFhFp")]
    [InlineData('L', "jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL")]
    [InlineData('P', "PmmdzqPrVvPwwTWBwg")]
    [InlineData('v', "wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn")]
    [InlineData('t', "ttgJtRGJQctTZtZT")]
    [InlineData('s', "CrZsJsPPZsGzwwsLwLmpwMDw")]
    public void CommonItem(char expected, string contents)
    {
        var compartments = Sack.Initialize(contents);
        Assert.Equal(expected, compartments.CommonItem);
    }

    [Theory]
    [InlineData(1, "aa")]
    [InlineData(26, "zz")]
    [InlineData(27, "AA")]
    [InlineData(52, "ZZ")]
    public void Priority(int expected, string contents)
    {
        var compartments = Sack.Initialize(contents);
        Assert.Equal(expected, compartments.Priority);
    }

    [Fact]
    public void IntializeMany()
    {
        var contents = new List<string>
        {
            "vJrwpWtwJgWrhcsFMMfFFhFp",
            "jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL",
            "PmmdzqPrVvPwwTWBwg",
            "wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn",
            "ttgJtRGJQctTZtZT",
            "CrZsJsPPZsGzwwsLwLmpwMDw",
        };

        var compartments = Sack.Initialize(contents);
        Assert.Equal(157, compartments.Sum(c => c.Priority));
    }    
}