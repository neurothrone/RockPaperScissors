using RockPaperScissors.Core.Domain;

namespace RockPaperScissors.Core;

public class Round
{
    public Hand PlayerHand { get; init; }
    public Hand ComputerHand { get; init; }

    public Winner GetWinner()
    {
        if (PlayerHand.Equals(ComputerHand))
            return Winner.None;

        return this is
            { PlayerHand: Hand.Rock, ComputerHand: Hand.Scissors } or
            { PlayerHand: Hand.Paper, ComputerHand: Hand.Rock } or
            { PlayerHand: Hand.Scissors, ComputerHand: Hand.Paper }
            ? Winner.Player
            : Winner.Computer;
    }
}