using Trebuchet;

Console.WriteLine("Load calibration values from file...");
var calibrationValues = File.ReadAllLines("CalibrationValues.txt");

Console.WriteLine("Calculate the sum of all the calibration values...");
var sum = Calibrator.DecodeCalibrationValues(calibrationValues);

Console.WriteLine($"Sum of all values is: {sum}");
