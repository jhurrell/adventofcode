using Code;

var assignments = File.ReadAllLines("Assignments.txt").ToList();
var manager = SectionManager.Initialize(assignments);
var fullyContainedPairsCount = manager.FullyContainedCount;
Console.WriteLine($"In how many assignment pairs does one range fully contain the other? {fullyContainedPairsCount}");
