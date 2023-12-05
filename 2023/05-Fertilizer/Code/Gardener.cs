namespace Code;

public class Gardener
{
    public static uint GetLocation(Dictionary<string, Mappings> maps, uint seed)
    {
        var soil = maps["seed-to-soil"].GetDestination(seed);
        var fertilizer = maps["soil-to-fertilizer"].GetDestination(soil);
        var water = maps["fertilizer-to-water"].GetDestination(fertilizer);
        var light = maps["water-to-light"].GetDestination(water);
        var temperature = maps["light-to-temperature"].GetDestination(light);
        var humidity = maps["temperature-to-humidity"].GetDestination(temperature);
        var location = maps["humidity-to-location"].GetDestination(humidity);

        return location;
    }

    public static List<uint> GetLocations(Dictionary<string, Mappings> maps, Seeds seeds)
    {
        return seeds.Ranges.Select(r => GetLocation(maps, r.Start)).ToList();
    }    

    public static uint GetLowestLocation(Dictionary<string, Mappings> maps, Seeds seeds)
    {
        return seeds.Ranges.Select(s => GetLocation(maps, s.Start)).Min(l => l);
    }

    public static List<SeedRange> GetOverlappingSeedRanges(Dictionary<string, Mappings> maps, Seeds seeds)
    {
        var overlappingRangers = new List<SeedRange>{};

        var seedToSoil = maps["seed-to-soil"];
        foreach(var map in seedToSoil.Map)
        {
            foreach(var range in seeds.Ranges)
            {
                Console.WriteLine($"{map.SourceStart} -> {map.SourceStart + map.Count}");
            }
        }

        return overlappingRangers;
    }
}