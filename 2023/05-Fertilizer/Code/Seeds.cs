namespace Code;

public class Seeds
{
    public List<SeedRange> Ranges { get; set; } = new();

    public static Seeds InitializeAsDistinct(string[] puzzle)
    {
        var seeds = new Seeds {};

        foreach(var line in puzzle)        
        {
            if(line.StartsWith("seeds:"))
            {
                seeds.Ranges.AddRange(line
                    .Replace("seeds: ", "")
                    .Split(" ")
                    .Select(s => new SeedRange 
                    { 
                        Start = uint.Parse(s), 
                        End = uint.Parse(s) 
                    })
                    .ToList());

                return seeds;
            }
        }

        return seeds;
    }

    public static Seeds InitializeAsRanges(string[] puzzle)
    {
        var seeds = new Seeds {};

        foreach(var line in puzzle)        
        {
            if(line.StartsWith("seeds:"))
            {
                var pairs = line.Replace("seeds: ", "").Split(" ");

                for(var i = 0; i < pairs.Length; i+=2)
                {
                    var start = uint.Parse(pairs[i]);
                    var count = uint.Parse(pairs[i + 1]);

                    seeds.Ranges.Add(new SeedRange { Start = start, End = start + count - 1} );
                }

                return seeds;
            }
        }

        return new();
    }    
}
