namespace Rucksack;

public class Group
{
    public List<Sack> Sacks { get; init; } = new();

    public static Group Initialize(List<string> contents)
    {
        return new Group 
        {
            Sacks = contents.Select(c => Sack.Initialize(c)).ToList()
        };
    }

    public char BadgeItemType
    {
        get
        {
            // Find the item type common to all 3 Sacks. We'll do this by picking 
            // the first Sack and looping over the characters and checking the 
            // other two Sacks for the same character.
            var testSack = Sacks[0];
            foreach(var ch in testSack.Items)
            {
                if(Sacks[1].Items.Contains(ch) && Sacks[2].Items.Contains(ch))
                {
                    return ch;
                }
            }

            return '0';
        }
    }

    public int BadgeItemTypePriority
    {
        get
        {
            return Priorities.Lookup[BadgeItemType];
        }
    }    
}