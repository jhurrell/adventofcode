namespace CalorieCounting.Tests;

public class EnergyCalculatorTests
{
    [Fact]
    public void CalculateCalorieSums()
    {
        var elfCalories = new string[] {
            "1000",
            "2000",
            "3000",
            "",
            "4000",
            "",
            "5000",
            "6000",
            "",
            "7000",
            "8000",
            "9000",
            "",
            "10000",
        };

        Assert.Collection(EnergyCalculator.CalculateCalorieSums(elfCalories), 
            item => Assert.Equal(6000, item),
            item => Assert.Equal(4000, item),
            item => Assert.Equal(11000, item),
            item => Assert.Equal(24000, item),
            item => Assert.Equal(10000, item)
        );
    }

    [Fact]
    public void CalculateSumOfTopN()
    {
        var elfCalories = new string[] {
            "1000",
            "2000",
            "3000",
            "",
            "4000",
            "",
            "5000",
            "6000",
            "",
            "7000",
            "8000",
            "9000",
            "",
            "10000",
        };

        var all = EnergyCalculator.CalculateCalorieSums(elfCalories);
        foreach(var item in all)
        {
            Console.WriteLine(item);
        }

        Assert.Equal(45000, EnergyCalculator.CalculateSumOfTopN(elfCalories, 3));
    }    
}