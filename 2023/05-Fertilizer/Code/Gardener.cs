namespace Code;

public class Gardener
{
    public static uint GetLocationForValue(Dictionary<string, Mappings> maps, uint value)
    {
        var soil = maps["seed-to-soil"].GetDestinationForValue(value);
        var fertilizer = maps["soil-to-fertilizer"].GetDestinationForValue(soil);
        var water = maps["fertilizer-to-water"].GetDestinationForValue(fertilizer);
        var light = maps["water-to-light"].GetDestinationForValue(water);
        var temperature = maps["light-to-temperature"].GetDestinationForValue(light);
        var humidity = maps["temperature-to-humidity"].GetDestinationForValue(temperature);
        var location = maps["humidity-to-location"].GetDestinationForValue(humidity);

        return location;
    }
   
    public static List<uint> GetLocationsViaDistinct(Dictionary<string, Mappings> maps, Seeds seeds)
    {
        return seeds.Ranges.Select(r => GetLocationForValue(maps, r.Start)).ToList();
    }    

    public static uint GetLowestLocationViaDistinct(Dictionary<string, Mappings> maps, Seeds seeds)
    {
        return seeds.Ranges.Select(s => GetLocationForValue(maps, s.Start)).Min(l => l);
    }


    public static Range GetLocationsForRange(Dictionary<string, Mappings> maps, Range testRange)
    {
        var resultRange = testRange;
        foreach(var map in maps)        
        {
            LogState(map.Value);
            resultRange = map.Value.GetDestinationsForRange(resultRange);
            LogRange(resultRange);
        }

        return resultRange;
    }

    public static void LogState(Mappings mappings)
    {
        Console.WriteLine($"{mappings.Name}...");
        foreach(var map in mappings.Maps)
        {
            Console.WriteLine($"\tContains: {map.Source.Start} -> {map.Source.End}");
        }
    }

    public static void LogRange(Range range)
    {
        Console.WriteLine($"\tReturned: {range.Start} -> {range.End}");
    }

    public static List<Range> GetLocationsViaRange(Dictionary<string, Mappings> maps, Seeds seeds)
    {
        Console.WriteLine($"GetLocationsViaRange...");
        var seedRanges = string.Join("-", seeds.Ranges.Select(r => new { r.Start, r.End }));
        Console.WriteLine($"GetLocationsViaRange Seed Ranges: {seedRanges}");

        return seeds.Ranges.Select(r => GetLocationsForRange(maps, r)).ToList();
    }    

    public static uint GetLowestLocationViaRange(Dictionary<string, Mappings> maps, Seeds seeds)
    {
        Console.WriteLine($"GetLowestLocationViaRange...");
        var seedRanges = string.Join("-", seeds.Ranges.Select(r => new { r.Start, r.End }));
        Console.WriteLine($"GetLowestLocationViaRange Seed Ranges: {seedRanges}");
        return seeds.Ranges.Select(s => GetLocationsForRange(maps, s)).Min(l => l.Start);
    }    
}