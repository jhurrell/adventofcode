
using Code;

Console.WriteLine("Read puzzle file...");
var puzzle = File.ReadLines("Puzzle.txt").ToArray();

Console.WriteLine("Calculate location from individual Seed values...");
var gardener = Gardener.Initialize(Mappings.Initialize(puzzle), Seeds.InitializeAsDistinct(puzzle));
var lowestByValue = gardener.GetLowestLocationFromSeedValues();
Console.WriteLine($"What is the lowest location number that corresponds to any of the initial seed numbers? {lowestByValue}");


Console.WriteLine("Call Gardener.GetLowestLocationViaRange...");
gardener = Gardener.Initialize(Mappings.Initialize(puzzle), Seeds.InitializeAsRanges(puzzle));
var lowestByRange = gardener.GetLowestLocationFromSeedRanges();
Console.WriteLine($"What is the lowest location number that corresponds to any of the initial seed numbers? {lowestByRange}");

// Check out:
// https://github.com/Lars-Kristian/AdventOfCode/blob/main/2023/App/Day5/Day5.cs
// https://github.com/Acc3ssViolation/advent-of-code-2023/blob/main/Advent/Advent/Assignments/Day05_2.cs
