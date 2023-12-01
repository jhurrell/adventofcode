// See https://aka.ms/new-console-template for more information
using CalorieCounting;

Console.WriteLine("Hello, World!");

var elfCalories = File.ReadAllLines("ElfCalories.txt");

var maxCalories = EnergyCalculator.CalculateCalorieSums(elfCalories);
Console.WriteLine(maxCalories);

var topThree = EnergyCalculator.CalculateSumOfTopN(elfCalories, 3);
Console.WriteLine(topThree);