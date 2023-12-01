namespace Trebuchet.Tests;

public class CalibratorTests
{
    [Theory]

    [InlineData(12, "1abc2")]
    [InlineData(38, "pqr3stu8vwx")]
    [InlineData(15, "a1b2c3d4e5f")]
    [InlineData(77, "treb7uchet")]

    [InlineData(29, "two1nine")]
    [InlineData(83, "eightwothree")]
    [InlineData(13, "abcone2threexyz")]
    [InlineData(24, "xtwone3four")]
    [InlineData(42, "4nineeightseven2")]
    [InlineData(14, "zoneight234")]
    [InlineData(76, "7pqrstsixteen")]

    [InlineData(82, "eightwo")]
    public void DecodeLine(int expected, string input)
    {
        Assert.Equal(expected, Calibrator.DecodeLine(input));
    }

    [Fact]
    public void DecodeCalibrationValues_Part1()
    {
        var examples = new List<string> {
            "1abc2",
            "pqr3stu8vwx",
            "a1b2c3d4e5f",
            "treb7uchet"
        };

        Assert.Equal(142, Calibrator.DecodeCalibrationValues(examples));
    }

    [Fact]
    public void DecodeCalibrationValues_Part2()
    {
        var examples = new List<string> {
            "two1nine",
            "eightwothree",
            "abcone2threexyz",
            "xtwone3four",
            "4nineeightseven2",
            "zoneight234",
            "7pqrstsixteen",
        };

        Assert.Equal(281, Calibrator.DecodeCalibrationValues(examples));
    }    
}