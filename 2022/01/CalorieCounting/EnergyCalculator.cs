namespace CalorieCounting;

public static class EnergyCalculator
{
    public static List<int> CalculateCalorieSums(string[] calories)
    {
        var elfCalories = new List<int> { 0 };
        var elfIndex = 0;

        for(var i = 0; i < calories.Length; i++)        
        {
            var record = calories[i];
            
            if(record == "") 
            {
                elfIndex++;
                elfCalories.Add(0);
            } 
            else 
            {
                elfCalories[elfIndex] += int.Parse(record);
            }
        }

        return elfCalories;
    }

    public static int CalculateSumOfTopN(string[] calories, int top)
    {
        var calorieSums = CalculateCalorieSums(calories);

        return calorieSums
            .OrderByDescending(c => c)
            .Take(top)
            .Sum(c => c);
    }    
}
