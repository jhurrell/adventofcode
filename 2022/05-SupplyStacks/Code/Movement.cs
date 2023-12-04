using System.Text.RegularExpressions;

namespace Code;

public class Movement
{
    public int FromStack { get; set; } = 0;
    public int ToStack { get; set; } = 0;
    public int Quantity { get; set; } = 0;
    public string Value { get; set; } = string.Empty;
    public static Regex Regex = new("(\\d+)"); 

    public static List<Movement> Initialize(string[] puzzle)
    {
        return puzzle
            .Where(p => p.StartsWith("move"))
            .Select(m => Initialize(m))
            .ToList();
    }

    public static Movement Initialize(string movement)
    {
        var matches = Regex.Matches(movement);

        return new Movement 
        {
            FromStack = int.Parse(matches[1].ToString()),
            ToStack = int.Parse(matches[2].ToString()),
            Quantity = int.Parse(matches[0].ToString()),
            Value = movement
        };
    }
}