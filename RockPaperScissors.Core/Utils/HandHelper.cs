using RockPaperScissors.Core.Domain;

namespace RockPaperScissors.Core.Utils;

public static class HandHelper
{
    private static int MaxExclusiveRange => Enum.GetValues<Hand>().Length;

    public static Hand GetRandomHand()
    {
        var index = Random.Shared.Next(0, MaxExclusiveRange) + 1;
        return GetHand(index);
    }

    public static Hand GetHand(int value) => value switch
    {
        1 => Hand.Rock,
        2 => Hand.Paper,
        _ => Hand.Scissors
    };

    public static Hand GetHand(string value) => value switch
    {
        "1" => Hand.Rock,
        "2" => Hand.Paper,
        _ => Hand.Scissors
    };

    public static string GetHandName(Hand hand) => hand switch
    {
        Hand.Rock => nameof(Hand.Rock),
        Hand.Paper => nameof(Hand.Paper),
        _ => nameof(Hand.Scissors)
    };

    public static string GetHandSymbol(Hand hand)
    {
        if (OperatingSystem.IsWindows())
            return GetHandName(hand);

        return hand switch
        {
            Hand.Rock => "\ud83e\udea8",
            Hand.Paper => "\ud83d\udcdc",
            _ => "\u2702\ufe0f"
        };
    }
}