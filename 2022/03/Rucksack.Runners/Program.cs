
using Rucksack;

var contents = File.ReadAllLines("CompartmentContents.txt").ToList();
var compartments = Compartments.Initialize(contents);
var prioritySum = compartments.Sum(c => c.Priority);
Console.WriteLine($"The sum of all types is {prioritySum}");