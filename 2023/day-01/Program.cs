using Day01;

var calibrationValues = File.ReadAllLines("CalibrationValues.txt");

//******************************************************************************
// Part 1
//******************************************************************************

// Collect the example calibration values.
var part1SampleValues = new List<string> {
    "1abc2",
    "pqr3stu8vwx",
    "a1b2c3d4e5f",
    "treb7uchet"
};

// Demonstrate StupidElves.DecodeLine().
foreach(var value in part1SampleValues)
{
    Console.WriteLine($"Line '{value}' produces {StupidElves.DecodeLine(value)}");
}

// Demonstrate StupidElves.DecodeCalibrationValues().
Console.WriteLine("Adding together produces...");
Console.WriteLine(StupidElves.DecodeCalibrationValues(part1SampleValues));

// Calculate the actual Calibration Values.
Console.WriteLine("What is the sum of all of the calibration values?");
Console.WriteLine(StupidElves.DecodeCalibrationValues(calibrationValues));


//******************************************************************************
// Part 2
//******************************************************************************
var part2SampleValues = new List<string> {
    "two1nine",
    "eightwothree",
    "abcone2threexyz",
    "xtwone3four",
    "4nineeightseven2",
    "zoneight234",
    "7pqrstsixteen",
};

// Demonstrate StupidElves.DecodeLine().
foreach(var value in part2SampleValues)
{
    Console.WriteLine($"Line '{value}' / '{StupidElves.TransformLine(value)}' produces {StupidElves.DecodeLine(value)}");
}

// Demonstrate StupidElves.DecodeCalibrationValues().
Console.WriteLine("Adding together produces...");
Console.WriteLine(StupidElves.DecodeCalibrationValues(part2SampleValues));

// Calculate the actual Calibration Values.
Console.WriteLine("What is the sum of all of the calibration values?");
Console.WriteLine(StupidElves.DecodeCalibrationValues(calibrationValues));
