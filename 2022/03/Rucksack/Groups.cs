namespace Rucksack;

public class Groups
{
    public List<Group> Trios { get; init; } = new();

    public static Groups Initialize(List<string> contents)
    {
        var groups = new Groups {};

        // Split into chunks of 3 rows.
        for(var i = 0; i < contents.Count / 3; i++)
        {
            groups.Trios.Add(Group.Initialize(contents.Skip(i * 3).Take(3).ToList()));
        }

        return groups;
    }

    public int BadgeItemTypePrioritySum
    {
        get
        {
            return Trios.Sum(t => t.BadgeItemTypePriority);
        }
    }      
}