namespace Code;

public class Mappings
{
    public string MapText { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public List<Mapping> Map { get; set; } = new();

    public uint GetDestination(uint source)
    {
        // Attempt to locate the mapping that contains the source.
        var mapping = Map
            .Where(m => m.ContainsSource(source))
            .FirstOrDefault();

        if(mapping is not null)
        {
            var offset = source - mapping.SourceStart;
            return mapping.DestinationStart + offset;
        }

        return source;
    }

    public static Mappings Initialize(string mapText)
    {
        var mappings = new Mappings { MapText = mapText };

        // Split the string into parts.
        var parts = mapText.Split("|");

        // Set the name.
        mappings.Name = parts[0].Replace(" map:", "");

        // Enumerate over each of the remaining parts to create the maps.
        for(var pi = 1; pi < parts.Length; pi++)
        {
            // Split the remainted of the string into the numeric components.
            var part = parts[pi];

            // Convert the components to numeric so we can work with them.
            var values = part.Split(" ");
            mappings.Map.Add(new Mapping { 
                SourceStart = uint.Parse(values[1]),
                DestinationStart = uint.Parse(values[0]),
                Count = uint.Parse(values[2])
            });
        }

        return mappings;
    }

    public static Dictionary<string, Mappings> Initialize(string[] puzzle)
    {
        // Merge all the lines into a single string and include the pipe symbol
        // as a seperator.
        var all = string.Join("|", puzzle);

        // Split on double pipes. This stands in for the double crlf that existed
        // in the file between each mapping section.
        var maps = all.Split("||");

        return maps
            .Where(m => !m.StartsWith("seeds: "))
            .Select(m => Initialize(m))
            .ToDictionary(k => k.Name, v => v);
    }
}
