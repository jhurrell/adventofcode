namespace Code;

public class Card
{
    public static char Transform(char card) => 
        card switch
            {
                'A' => 'A',
                'K' => 'B',
                'Q' => 'C',
                'J' => 'D',
                'T' => 'E',
                '9' => 'F',
                '8' => 'G',
                '7' => 'H',
                '6' => 'I',
                '5' => 'J',
                '4' => 'K',
                '3' => 'L',
                '2' => 'M',
                _ => '.'
            };

    public static char TransformJokersWild(char card) => 
        card switch
            {
                'A' => 'A',
                'K' => 'B',
                'Q' => 'C',
                'T' => 'D',
                '9' => 'E',
                '8' => 'F',
                '7' => 'G',
                '6' => 'H',
                '5' => 'I',
                '4' => 'J',
                '3' => 'K',
                '2' => 'L',
                'J' => 'Z',
                _ => '.'
            };  

    public static string Transform(string cards) => string.Join(string.Empty, cards.Select(c => Card.Transform(c)));
    public static string TransformJokersWild(string cards) => string.Join(string.Empty, cards.Select(c => Card.TransformJokersWild(c)));
}
