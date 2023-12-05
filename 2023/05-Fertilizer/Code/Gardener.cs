namespace Code;

public class Gardener
{
    public Dictionary<string, Mappings> Mappings { get; init; } = new();
    public Seeds Seeds { get; init; } = new();

    public static Gardener Initialize(Dictionary<string, Mappings> mappings, Seeds seeds)
    {
        return new Gardener
        {
            Mappings = mappings,
            Seeds = seeds
        };
    }

    public uint GetLocationForValue(uint value)
    {
        var soil = Mappings["seed-to-soil"].GetDestinationForValue(value);
        var fertilizer = Mappings["soil-to-fertilizer"].GetDestinationForValue(soil);
        var water = Mappings["fertilizer-to-water"].GetDestinationForValue(fertilizer);
        var light = Mappings["water-to-light"].GetDestinationForValue(water);
        var temperature = Mappings["light-to-temperature"].GetDestinationForValue(light);
        var humidity = Mappings["temperature-to-humidity"].GetDestinationForValue(temperature);
        var location = Mappings["humidity-to-location"].GetDestinationForValue(humidity);

        return location;
    }

    public uint GetLowestLocationFromSeedValues()
    {
        return Seeds.Ranges.Select(s => GetLocationForValue(s.Start)).Min(l => l);
    }

    public uint GetLowestLocationFromSeedRanges()
    {
        var lowest = uint.MaxValue;
        foreach(var range in Seeds.Ranges)
        {
            Console.WriteLine($"{range.Start} -> {range.End} ({(range.End - range.Start):0,000} seeds)");

            for(var value = range.Start; value <= range.End; value++)
            {
                var result = GetLocationForValue(value);

                if(result < lowest)
                {
                    lowest = result;
                    Console.WriteLine($"New lowest {lowest}");
                }
            }
        }

        return lowest;
    }    
}