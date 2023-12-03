
using Rucksack;

var contents = File.ReadAllLines("CompartmentContents.txt").ToList();

var compartments = Sack.Initialize(contents);
var prioritySum = compartments.Sum(c => c.Priority);
Console.WriteLine($"What is the sum of the priorities of those item types? {prioritySum}");

var groups = Groups.Initialize(contents);
var sumPriorities = groups.BadgeItemTypePrioritySum;
Console.WriteLine($"What is the sum of the priorities of those item types? {sumPriorities}");
