namespace Code;

public class Map
{
    public List<Range> Ranges { get; set; } = new();

    public static List<Map> Initialize(string[] input)
    {
        var maps = new List<Map> {};

        for(var i = 0; i < input.Length; i++)
        {
            var line = input[i];

            if(line.Contains("map"))
            {
                var map = new Map {};
                for(var m = i + 1; i < input.Length; m++)                
                {
                    line = input[m];
                    if(line.Trim() == "")
                    {
                        i = m;
                        continue;
                    }
                }
            }

            Console.WriteLine($"Line[{i}] = {line}");
        }

        return maps;
    }
}