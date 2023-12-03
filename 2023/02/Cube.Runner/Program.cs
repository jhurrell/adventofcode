using Cube;

var gamesResults = File.ReadLines("GamesResults.txt").ToList();
var games = Games.Initialize(gamesResults);

var sum = games.GetPossibleGamesIdSum(12, 13, 14);
Console.WriteLine($"What is the sum of the IDs of those games? {sum}");

var power = games.GetPower();
Console.WriteLine($"What is the sum of the power of these sets? {power}");
