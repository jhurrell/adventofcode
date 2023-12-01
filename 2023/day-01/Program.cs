using Day01;

// Collect the example calibration values.
var sampleCalibrationValues = new List<string> {
    "1abc2",
    "pqr3stu8vwx",
    "a1b2c3d4e5f",
    "treb7uchet"
};

// Demonstrate StupidElves.DecodeLine().
foreach(var value in sampleCalibrationValues)
{
    Console.WriteLine($"Example {value}: {StupidElves.DecodeLine(value)}");
}

// Demonstrate StupidElves.DecodeCalibrationValues().
Console.WriteLine("Adding together produces...");
Console.WriteLine(StupidElves.DecodeCalibrationValues(sampleCalibrationValues));

// Calculate the actual Calibration Values.
var calibrationValues = File.ReadAllLines("CalibrationValues.txt");
Console.WriteLine("What is the sum of all of the calibration values?");
Console.WriteLine(StupidElves.DecodeCalibrationValues(calibrationValues));
