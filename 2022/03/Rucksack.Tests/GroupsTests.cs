namespace Rucksack.Tests;

public class GroupsTests
{
    [Fact]
    public void Trios()
    {
        var contents = new List<string>
        {
            "vJrwpWtwJgWrhcsFMMfFFhFp",
            "jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL",
            "PmmdzqPrVvPwwTWBwg",            
            "wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn",
            "ttgJtRGJQctTZtZT",
            "CrZsJsPPZsGzwwsLwLmpwMDw"
        };

        var groups = Groups.Initialize(contents);

        Assert.Equal(2, groups.Trios.Count);
    }  

    [Fact]
    public void BadgeItemTypePrioritySum()
    {
        var contents = new List<string>
        {
            "vJrwpWtwJgWrhcsFMMfFFhFp",
            "jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL",
            "PmmdzqPrVvPwwTWBwg",            
            "wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn",
            "ttgJtRGJQctTZtZT",
            "CrZsJsPPZsGzwwsLwLmpwMDw"
        };

        var groups = Groups.Initialize(contents);

        Assert.Equal(70, groups.BadgeItemTypePrioritySum);        
    }       
}