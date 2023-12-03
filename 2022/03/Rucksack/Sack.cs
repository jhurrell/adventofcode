namespace Rucksack;

public class Sack
{
    public string Items { get; init; } = string.Empty;
    public string CompartmentA { get; init; } = string.Empty;
    public string CompartmentB { get; init; } = string.Empty;

    public static Sack Initialize(string contents)
    {
        var split = contents.Length / 2;
        return new Sack 
        { 
            Items = contents,
            CompartmentA = contents.Substring(0, split),
            CompartmentB = contents.Substring(split, split),
        };
    }

    public static List<Sack> Initialize(List<string> contents)
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

    public int Priority => Priorities.Lookup[CommonItem];
}
