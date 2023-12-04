
using Code;

var schematic = File.ReadAllLines("Schematic.txt").ToArray();

var parts = Part.Initialize(schematic);
var symbols = Symbol.Initialize(schematic);
var schematicPartsSum = Symbol.GetAdjacentPartsSum(symbols, parts);
Console.WriteLine($"What is the sum of all of the part numbers in the engine schematic? {schematicPartsSum}");

var schematicGearRatioSums = Symbol.GetAdjacentGearRatioSums(symbols, parts);
Console.WriteLine($"What is the sum of all of the gear ratios in your engine schematic? {schematicGearRatioSums}");
