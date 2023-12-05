namespace Code;

public class Seeds
{
    public List<uint> Values { get; set; } = new();

    public static Seeds Initialize(string[] puzzle)
    {
        foreach(var line in puzzle)        
        {
            if(line.StartsWith("seeds:"))
            {
                return new Seeds
                {
                    Values = line.Replace("seeds: ", "").Split(" ").Select(s => uint.Parse(s)).ToList()
                };
            }
        }

        return new();
    }
}
