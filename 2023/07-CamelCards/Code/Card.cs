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
                _ => 'Z'
            };            
}
