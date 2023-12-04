
using Code;

var puzzleInput = File.ReadAllText("PuzzleInput.txt");

var signal = Signal.Initialize(puzzleInput);
Console.WriteLine($"How many characters need to be processed before the first start-of-packet marker is detected? {signal.MarkerPosition}");

Console.WriteLine($"How many characters need to be processed before the first start-of-message marker is detected? {signal.MessagePosition}");