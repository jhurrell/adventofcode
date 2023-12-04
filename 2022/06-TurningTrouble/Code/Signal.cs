namespace Code;

public class Signal
{
    public string Buffer { get; init; } = string.Empty;
    public int MarkerPosition { get; init; } = 0;
    public int MessagePosition { get; init; } = 0;
    
    public static Signal Initialize(string buffer)
    {
        return new Signal 
        { 
            Buffer = buffer,
            MarkerPosition = LocateMarker(buffer),
            MessagePosition = LocateMessage(buffer)
        };
    }

    public static int LocateMarker(string buffer, int windowSize = 4)
    {
        for(var i = 0; i < buffer.Length - 4; i++)
        {
            var fragment = buffer.Substring(i, windowSize);
            var areAllDifferent = AreAllCharactersDifferent(fragment);

            if(fragment.Length >= 4 && areAllDifferent)
            {
                return i + windowSize;
            }
        }

        return 0;
    }

    public static int LocateMessage(string buffer, int windowSize = 14)
    {
        for(var i = 0; i < buffer.Length - 4; i++)
        {
            var fragment = buffer.Substring(i, windowSize);
            var areAllDifferent = AreAllCharactersDifferent(fragment);

            if(fragment.Length >= 4 && areAllDifferent)
            {
                return i + windowSize;
            }
        }

        return 0;
    }    

    public static bool AreAllCharactersDifferent(string signal) => 
        signal.Distinct().Count() == signal.Length;
}
