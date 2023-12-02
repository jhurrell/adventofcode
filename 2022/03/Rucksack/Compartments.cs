namespace Rucksack;

public class Compartments
{
    public string CompartmentA { get; init; } = string.Empty;
    public string CompartmentB { get; init; } = string.Empty;
    public Dictionary<char, int> PriorityLookup { get; init; } = new();

    public static Compartments Initialize(string contents)
    {
        // Calculate the PriorityLookup.
        // A = 65, Z = 90, a = 97, z = 122
        var priorityLookup = new Dictionary<char, int> {};
        for(var i = 0; i < 26; i++)
        {
            priorityLookup.Add((char)(65 + i), i + 27); // uppercase
            priorityLookup.Add((char)(97 + i), i + 1);  // lowercase
        }

        var split = contents.Length / 2;
        return new Compartments 
        { 
            CompartmentA = contents.Substring(0, split),
            CompartmentB = contents.Substring(split, split),
            PriorityLookup = priorityLookup,
        };
    }

    public static List<Compartments> Initialize(List<string> contents)
    {
        return contents.Select(c => Initialize(c)).ToList();
    }

    public char CommonItem 
    {
        get {
            for(var i = 0; i < CompartmentA.Length; i++)
            {
                var item = CompartmentA[i];
                if(CompartmentB.Contains(item)) {
                    return item;
                }
            }

            return '0';
        }
    }

    public int Priority => PriorityLookup[CommonItem];
}
