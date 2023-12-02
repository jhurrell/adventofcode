namespace Cube;

public class ColorSet
{
    public int Red { get; set; } = 0;
    public int Green { get; set; } = 0;
    public int Blue { get; set; } = 0;

    public static List<ColorSet> InitializeColorSet(string colorResults)
    {
        var colorSets = colorResults.Split(";");
        return colorSets.Select(cs => new ColorSet(cs)).ToList();
    }

    public ColorSet(string colorSet)
    {
        var colorPairs = colorSet.Trim().Split(",");

        foreach(var colorPair in colorPairs)
        {
            // Split the segment into parts.
            var colorPairParts = colorPair.Trim().Split(" ");
            var count = colorPairParts[0].Trim();
            var color = colorPairParts[1].Trim();
            switch(color)
            {
                case "red":
                    Red = int.Parse(count);
                    break;
                case "green":
                    Green = int.Parse(count);
                    break;
                case "blue":
                    Blue = int.Parse(count);
                    break;
            }
        }
    }
}
