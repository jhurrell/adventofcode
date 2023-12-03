namespace Rucksack.Tests;

public class GroupTests
{
    [Fact]
    public void Initialize()
    {
        var contents = new List<string>
        {
            "vJrwpWtwJgWrhcsFMMfFFhFp",
            "jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL",
            "PmmdzqPrVvPwwTWBwg"
        };

        var groups = Group.Initialize(contents);

        Assert.Equal(3, groups.Sacks.Count);
    }

    [Fact]
    public void BadgeItemType_Example_1()
    {
        var contents = new List<string>
        {
            "vJrwpWtwJgWrhcsFMMfFFhFp",
            "jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL",
            "PmmdzqPrVvPwwTWBwg"
        };

        var groups = Group.Initialize(contents);

        Assert.Equal('r', groups.BadgeItemType);        
    }

    [Fact]
    public void BadgeItemType_Example_2()
    {
        var contents = new List<string>
        {
            "wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn",
            "ttgJtRGJQctTZtZT",
            "CrZsJsPPZsGzwwsLwLmpwMDw"
        };

        var groups = Group.Initialize(contents);

        Assert.Equal('Z', groups.BadgeItemType);        
    }


    [Fact]
    public void BadgeItemTypePriority_Example_1()
    {
        var contents = new List<string>
        {
            "vJrwpWtwJgWrhcsFMMfFFhFp",
            "jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL",
            "PmmdzqPrVvPwwTWBwg"
        };

        var groups = Group.Initialize(contents);

        Assert.Equal(18, groups.BadgeItemTypePriority);        
    }

    [Fact]
    public void BadgeItemTypePriority_Example_2()
    {
        var contents = new List<string>
        {
            "wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn",
            "ttgJtRGJQctTZtZT",
            "CrZsJsPPZsGzwwsLwLmpwMDw"
        };

        var groups = Group.Initialize(contents);

        Assert.Equal(52, groups.BadgeItemTypePriority);        
    }       
}