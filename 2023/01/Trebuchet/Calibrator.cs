namespace Trebuchet;

public static class Calibrator
{
   public static int DecodeCalibrationValues(IEnumerable<string> calibrationDocument)
    {
        var total = 0;

        // Enumerate over each line of text in the calibration document and call the
        // function that returns the number for that line.
        foreach(var line in calibrationDocument)
        {
            // Add the number from the current line to the running total.
            total += DecodeLine(line);
        }

        return total;
    }

    public static string TransformLine(string line) {
        // Replace each instance of the WORD for a number, with the actual number.
        // Note that we will only do this for words representing numbers 0-9. In other
        // words, we do not need to replace "sixteen" with "16" but "6".

        // There's a catch. We need to properly handle the case like: "eightwo".
        // It must be recognized as "82". Note that the "t" is shared by the "eight"
        // and the "two" so we cannot do a simple .Replace().

        // Create a dictionary of the key/values we can to inject into the string.
        var numbers = new Dictionary<string, string> {
            { "one",   "1"},
            { "two",   "2"},
            { "three", "3"},
            { "four",  "4"},
            { "five",  "5"},
            { "six",   "6"},
            { "seven", "7"},
            { "eight", "8"},
            { "nine",  "9"},
        };

        var transformedLine = string.Empty;
        for(var i = 0; i < line.Length; i++) 
        {
            // Append the current character to the string we are transforming into.
            transformedLine += line[i];

            // Enumerate over all the number keys above (one, two... nine).
            foreach(var key in numbers.Keys) 
            {
                // For each key (number written with letters), determine if we are
                // at the start of that key within the string. If so, add the digit
                // to the string.
                if(i + key.Length <= line.Length && line.Substring(i, key.Length) == key)
                {
                    transformedLine += numbers[key];
                }
            }
        }

        return transformedLine;
    }

    public static int DecodeLine(string line)
    {
        // Declare the nullable integers so we can determine later if they have been 
        // set already. (Really only necessary for "first")
        int? firstDigit = null;
        int? secondDigit = null;

        // Enumerate over each character from the line of text.
        var transformedLine = TransformLine(line);
        foreach(var ch in transformedLine)
        {
            // Check to determine if the character is numberic...
            if(char.IsNumber(ch)) 
            {
                // If "firstDigit" has not been set, assign the value of the character 
                // to the variable. Note that by default, assiging "ch" to the variable
                // would actually assign the ASCII value to the variable, so we need 
                // to adjust it a bit. For reference: 0 = 48, 1 = 49... 9 = 57.
                firstDigit ??= ch - 48;

                // ALWAYS assign the numeric character to the "secondDigit" as this will
                // ensure that no matter what, the last numeric digit will be assigned.
                secondDigit = ch - 48;
            }
        }

        // Build and return the two-digit number from the individual first and second 
        // digit variables.
        var value = (firstDigit!.Value * 10) + secondDigit!.Value;
        return value;
    }
}
