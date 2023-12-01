namespace Day01;

public static class StupidElves
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

    public static int DecodeLine(string line)
    {
        // Declare the nullable integers so we can determine later if they have been 
        // set already. (Really only necessary for "first")
        int? firstDigit = null;
        int? secondDigit = null;

        // Enumerate over each character from the line of text.
        foreach(var ch in line)
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
        return (firstDigit!.Value * 10) + secondDigit!.Value;
    }
}