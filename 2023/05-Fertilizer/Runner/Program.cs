
using Code;

Console.WriteLine("Read puzzle file...");
var puzzle = File.ReadLines("Puzzle.txt").ToArray();

Console.WriteLine("Call Seeds.Initialize...");
var seeds = Seeds.InitializeAsDistinct(puzzle);

Console.WriteLine("Call SourceToDestination.Initialize...");
var maps = Mappings.Initialize(puzzle);

Console.WriteLine("Call Gardener.GetLowestLocation...");
var lowestLocation = Gardener.GetLowestLocationViaDistinct(maps, seeds);

Console.WriteLine($"What is the lowest location number that corresponds to any of the initial seed numbers? {lowestLocation}");


Console.WriteLine("Call Gardener.GetLowestLocationViaRange...");
var lowestRange = Gardener.GetLowestLocationViaRange(maps, seeds);
Console.WriteLine($"What is the lowest location number that corresponds to any of the initial seed numbers? {lowestRange}");
