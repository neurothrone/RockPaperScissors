using RockPaperScissors.Core.Domain;
using RockPaperScissors.Core.Utils;

namespace RockPaperScissors.Core;

public class Game
{
    private const int MaxScore = 3;

    public int PlayerScore { get; private set; } = 0;

    public int ComputerScore { get; private set; } = 0;

    public Round PlayRound(Hand playerHand)
    {
        var currentRound = new Round { PlayerHand = playerHand, ComputerHand = HandHelper.GetRandomHand() };
        ProcessWinner(currentRound);

        return currentRound;
    }

    private void ProcessWinner(Round round)
    {
        switch (round.GetWinner())
        {
            case Winner.Player:
                PlayerScore++;
                break;
            case Winner.Computer:
                ComputerScore++;
                break;
            case Winner.None:
            default:
                break;
        }
    }

    public bool HasWinner() => PlayerScore.Equals(MaxScore) || ComputerScore.Equals(MaxScore);

    public void Restart()
    {
        PlayerScore = 0;
        ComputerScore = 0;
    }
}