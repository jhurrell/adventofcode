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
        // We need to take something like this:
        //  3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green
        // and split it into something like this at each semicolon:
        //  3 blue, 4 red
        //  1 red, 2 green, 6 blue
        //  2 green
        var colorSets = colorResults.Split(";");

        // Once we have done that, we will loop over each element and instantiate
        // a class for each.
        return colorSets.Select(cs => new ColorSet(cs)).ToList();
    }

    public ColorSet(string colorSet)
    {
        // We need to take something like this:
        //  1 red, 2 green, 3 blue
        // and split it into something like this at each comma:
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
            // and split it into something like this at each space:
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
