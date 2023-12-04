namespace Code;

public class ScratchOffCard
{
    public int CardNumber { get; set; } = 0;
    public List<int> WinningNumbers { get; set; } = new();
    public List<int> CardNumbers { get; set; } = new();

    public static List<ScratchOffCard> Initialize(List<string> games)
    {
        return games.Select(g => ScratchOffCard.Initialize(g)).ToList();
    }

    public static ScratchOffCard Initialize(string game)
    {
        // Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53
        var meta = game.Split(":");
        var cardNumber = int.Parse(meta[0].Replace("Card ", ""));

        // Split the card's game values into the winning and card numbers.
        var numbers = meta[1].Split("|");

        return new ScratchOffCard
        {
            CardNumber = cardNumber,
            WinningNumbers = ScratchOffCard.ToIntArray(numbers[0]),
            CardNumbers = ScratchOffCard.ToIntArray(numbers[1])
        };
    }

    public static List<int> ToIntArray(string numbers)
    {
        return numbers
            .Trim()
            .Split(" ")
            .Select(n => n.Trim())
            .Where(n => n.Trim() != "")
            .Select(n => int.Parse(n))
            .ToList();
    }

    public List<int> MatchingNumbers
    {
        get 
        {
            return WinningNumbers
                .Where(a => CardNumbers.Any(b => b == a))
                .ToList();
        }
    }

    public int Points
    {
        get 
        {
            return (int)Math.Pow(2, MatchingNumbers.Count - 1);
        }
    }

    public List<int> WonCards
    {
        get
        {
            return Enumerable.Range(CardNumber + 1, MatchingNumbers.Count).ToList();
        }
    }

    public static List<int> GetWinnersCardNumbers(List<ScratchOffCard> cards)
    {
        var winningCardNumbers = new List<int> {};

        // Enumerate over each card and calculate how many additional
        // cards each has won.
        foreach(var card in cards)
        {
            // Collect the list of cards won by the current card.
            var wonCards = card.WonCards;

            // If the card already exists in the list, add its won cards
            // for each instance already in the list.
            if(winningCardNumbers.Any(c => c == card.CardNumber))
            {
                var count = winningCardNumbers.Count(c => c == card.CardNumber);
                for(var i = 0; i < count; i++)
                {
                    winningCardNumbers.AddRange(wonCards);
                }
            }

            // Add the original card and the winners.
            winningCardNumbers.Add(card.CardNumber);
            winningCardNumbers.AddRange(wonCards);
        }

        return winningCardNumbers;
    }
}
