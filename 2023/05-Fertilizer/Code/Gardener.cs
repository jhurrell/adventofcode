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
        return seeds.Values.Select(s => Gardener.GetLocation(maps, s)).ToList();
    }    

    public static uint GetLowestLocation(Dictionary<string, Mappings> maps, Seeds seeds)
    {
        return seeds.Values.Select(s => Gardener.GetLocation(maps, s)).Min(l => l);
    }       
}