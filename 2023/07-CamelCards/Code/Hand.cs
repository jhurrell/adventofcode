namespace Code;

public class Hand
{
    public string Cards { get; set; } = string.Empty;
    public int Bid { get; set; } = 0;
    public string RankKey { get; set; } = string.Empty;

    public static char HandRank(string cards)
    {
        // Collect the counts of each Card.
        var groupings = cards
            .GroupBy(g => g)
            .Select(g => new { Count = g.Count() })
            .OrderByDescending(g => g.Count)
            .ToList();

        // Five of a kind, where all five cards have the same label: AAAAA
        if(groupings.Count == 1)
            return 'A';

        // Four of a kind, where four cards have the same label and one card has 
        // a different label: AA8AA
        if(groupings.Count == 2 && groupings[0].Count == 4 && groupings[1].Count == 1)
            return 'B';

        // Full house, where three cards have the same label, and the remaining 
        // two cards share a different label: 23332
        if(groupings.Count == 2 && groupings[0].Count == 3 && groupings[1].Count == 2)
            return 'C';

        // Three of a kind, where three cards have the same label, and the 
        // remaining two cards are each different from any other card in the 
        // hand: TTT98
        if(groupings.Count == 3 && groupings[0].Count == 3)
            return 'D';

        // Two pair, where two cards share one label, two other cards share 
        // a second label, and the remaining card has a third label: 23432
        if(groupings.Count == 3 && groupings[0].Count == 2 && groupings[1].Count == 2)
            return 'E';        

        // One pair, where two cards share one label, and the other three cards 
        // have a different label from the pair and each other: A23A4
        if(groupings.Count == 4 && groupings[0].Count == 2)
            return 'F';        

        // High card, where all cards' labels are distinct: 23456              
        return 'G';
    }

    public static Hand Initialize(string hand)
    {
        // Extract the individual components of the hand.
        var cards = hand[..5];
        var bid = int.Parse(hand[6..]);

        return new Hand 
        {
            Cards = cards,
            Bid = bid,
            RankKey = $"{HandRank(cards)}-{string.Join(string.Empty, cards.Select(c => Card.Transform(c)))}"
        };
    }

    public static List<Hand> Initialize(string[] hands)
    {
        return hands
            .Select(Initialize)
            .OrderByDescending(h => h.RankKey)
            .ToList();
    }

    public static int GetTotalWinnings(List<Hand> hands)
    {
        var winnings = 0;

        var index = 1;
        foreach(var hand in hands.OrderByDescending(h => h.RankKey))
        {
            winnings += hand.Bid * index++;
        }

        return winnings;
    }
}