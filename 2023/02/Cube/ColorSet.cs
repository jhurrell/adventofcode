namespace Cube;

// A ColorSet represents a grouping of colors along with their counts for a 
// single handful of cubes that the elf pulled from the bag. Follows the pattern:
// # color, #color, #color
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
        // Break up the string. For example:
        //  1 red, 2 green, 3 blue
        // would create an array with the elements:
        //  1 red
        //  2 green
        //  3 blue
        var colorPairs = colorSet.Trim().Split(",");

        // Loop over each element in the array.
        foreach(var colorPair in colorPairs)
        {
            // We want to split by the space character so we have yet another 
            // array with the first element as the count and the second element 
            // as the color. For example:
            //  1 red
            // would create an array with the elements:
            //  1
            //  red
            var colorPairParts = colorPair.Trim().Split(" ");

            // For each split pair, grab the number and the color.
            var count = int.Parse(colorPairParts[0].Trim());
            var color = colorPairParts[1].Trim();

            // Determine which color cube we are processing and assign the count.
            switch(color)
            {
                case "red":
                    Red = count;
                    break;
                case "green":
                    Green = count;
                    break;
                case "blue":
                    Blue = count;
                    break;
            }
        }
    }
}
