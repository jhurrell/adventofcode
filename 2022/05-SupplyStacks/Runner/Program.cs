
using Code;

var puzzle = File.ReadAllLines("PuzzleInput.txt");

var stacks = Stack.Initialize(puzzle);
var movements = Movement.Initialize(puzzle);

var popCrates = Crane.GetTopCratesFromPopMovements(stacks, movements);
Console.WriteLine($"After the rearrangement procedure completes, what crate ends up on top of each stack? {popCrates}");

stacks = Stack.Initialize(puzzle);
var dequeueCrates = Crane.GetTopCratesFromDequeueMovements(stacks, movements);
Console.WriteLine($"After the rearrangement procedure completes, what crate ends up on top of each stack? {dequeueCrates}");
