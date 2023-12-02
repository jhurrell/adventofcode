
using RockPaperScissors;

var roundCodes = File.ReadAllLines("RoundCodes.txt").ToList();


var shapesScore = Tournament.PlayShapeShapeRounds(roundCodes);
Console.WriteLine($"Total Score when playing with shapes: {shapesScore}");

var winLoseDraw = Tournament.PlayWinLoseDrawRounds(roundCodes);
Console.WriteLine($"Total Score when playing by win/lose/draw: {winLoseDraw}");
