namespace Code;

public class SensorReadings
{
    public List<List<int>> Readings { get; set; } = new();

    public static SensorReadings Initialize(string[] input)
    {
        SensorReadings sensorReadings = new();

        foreach(var line in input)        
        {
            sensorReadings.Readings.Add(line.Split(" ").Select(int.Parse).ToList());
        }

        return sensorReadings;
    }

    public static void GetDeltas(List<int> readings, ref List<List<int>> deltas)
    {
        var currentDeltas = new List<int> {};
        for(var i = 0; i < readings.Count - 1; i++)
        {
            currentDeltas.Add(readings[i + 1] - readings[i]);
        }

        deltas.Add(currentDeltas);

        if (currentDeltas.Any(o => o != currentDeltas[0]))
        {
            GetDeltas(currentDeltas, ref deltas);
        }

        return;
    }

    public static int CalculateNextSequence(List<int> readings, List<List<int>> deltas)
    {
        var nextSequence = readings.Last();
        Console.WriteLine($"CalculateNextSequence for {nextSequence}...");

        foreach(var d in deltas)
        {
            nextSequence += d.Last();
        }

        return nextSequence;
    }

    public static int CalculateSumOfNextSequences(List<List<int>> readings)
    {
        var answer = 0;
        foreach(var reading in readings)
        {
            var deltas = new List<List<int>> {};
            GetDeltas(reading, ref deltas);
            answer += CalculateNextSequence(reading, deltas);
        }

        return answer;
    }
}
