using System.Text;
using System.Text.RegularExpressions;

namespace Code;

public static class Races
{
    public struct Race {
        public long Time;
        public long Distance;
    };

    public static long ExecutePart1(string[] input)
    {
        List<Race> races = new() { };
        List<long> winningRacesCounts = new() { };

        ParseRacesForPart1(input, ref races);
        RunAllRaces(races, ref winningRacesCounts);

        long product = 1;
        foreach(var winningRace in winningRacesCounts)
        {
            product *= winningRace;
        }

        return product;
    }

    public static long ExecutePart2(string[] input)
    {
        List<Race> races = new() { };
        List<long> winningRacesCounts = new() { };

        ParseRacesForPart2(input, ref races);
        RunAllRaces(races, ref winningRacesCounts);

        long product = 1;
        foreach(var winningRace in winningRacesCounts)
        {
            product *= winningRace;
        }
        
        return product;
    }    

    private static void ParseRacesForPart1(string[] input, ref List<Race> races)
    {
        var times = input[0][10..].Split(" ", StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
        var distances = input[1][10..].Split(" ", StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);

        // Initialize all the races.
        for(var raceCount = 0; raceCount < times.Length; raceCount++)
        {
            races.Add(new Race { Time = long.Parse(times[raceCount]), Distance = long.Parse(distances[raceCount]) });
        }
    }

    private static void ParseRacesForPart2(string[] input, ref List<Race> races)
    {
        var time = Regex.Replace(input[0][10..], @"\s+", "");
        var distance = Regex.Replace(input[1][10..], @"\s+", "");

        races.Add(new Race { Time = long.Parse(time), Distance = long.Parse(distance) });
    }    

    private static void RunAllRaces(List<Race> races, ref List<long> winningRaces)
    {
        foreach(var race in races)
        {
            long winningCount = 0;
            RunRaces(race, ref winningCount);
            winningRaces.Add(winningCount);
        }
    }

    private static void RunRaces(Race race, ref long winningCount)
    {
        for(var t = 1; t < race.Time; t++)
        {
            var distance = (race.Time - t) * t;
            if(distance > race.Distance)
                winningCount += 1;
        }
    }
}
