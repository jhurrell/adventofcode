
using Code;

var games = File.ReadAllLines("Games.txt").ToList();
var cards = ScratchOffCard.Initialize(games);

var pointsSum = cards.Sum(c => c.Points);
Console.WriteLine($"How many points are they worth in total? {pointsSum}");

var totalCardsWon = ScratchOffCard.GetWinnersCardNumbers(cards).Count;
Console.WriteLine($"How many total scratchcards do you end up with? {totalCardsWon}");
