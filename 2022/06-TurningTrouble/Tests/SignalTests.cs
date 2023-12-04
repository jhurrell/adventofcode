using Code;

namespace Tests;

public class SignalTests
{
    [Theory]
    [InlineData(false, "aaa")]
    [InlineData(true, "abc")]
    [InlineData(false, "aabc")]
    [InlineData(true, "abcd")]
    public void AreAllCharactersDifferent(bool expected, string signal)
    {
        Assert.Equal(expected, Signal.AreAllCharactersDifferent(signal));
    }

    [Theory]
    [InlineData(7, "mjqjpqmgbljsphdztnvjfqwrcgsmlb")]
    [InlineData(5, "bvwbjplbgvbhsrlpgdmjqwftvncz")]
    [InlineData(6, "nppdvjthqldpwncqszvftbrmjlhg")]
    [InlineData(10, "nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg")]
    [InlineData(11, "zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw")]
    public void Initialize(int expectedMarkerPosition, string buffer)
    {
        var signal = Signal.Initialize(buffer);
        Assert.Equal(expectedMarkerPosition, signal.MarkerPosition);
        Assert.Equal(buffer, signal.Buffer);
    }

    [Theory]
    [InlineData(7, "mjqjpqmgbljsphdztnvjfqwrcgsmlb")]
    [InlineData(5, "bvwbjplbgvbhsrlpgdmjqwftvncz")]
    [InlineData(6, "nppdvjthqldpwncqszvftbrmjlhg")]
    [InlineData(10, "nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg")]
    [InlineData(11, "zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw")]
    public void LocateMarker(int expected, string buffer)
    {
        var position = Signal.LocateStartOfDistinct(buffer, 4);
        Assert.Equal(expected, position);
    }

    [Theory]
    [InlineData(19, "mjqjpqmgbljsphdztnvjfqwrcgsmlb")]
    [InlineData(23, "bvwbjplbgvbhsrlpgdmjqwftvncz")]
    [InlineData(23, "nppdvjthqldpwncqszvftbrmjlhg")]
    [InlineData(29, "nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg")]
    [InlineData(26, "zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw")]
    public void LocateMessage(int expected, string buffer)
    {
        var position = Signal.LocateStartOfDistinct(buffer, 14);
        Assert.Equal(expected, position);
    }     
}