using RockPaperScissors.Core.Domain;

namespace RockPaperScissors.CLI.Client.Domain;

class GameOutcome
{
    public int PlayerScore { get; init; }
    public int ComputerScore { get; init; }
    public DateOnly PlayedDate { get; init; } = DateOnly.FromDateTime(DateTime.Now);

    public Winner Winner => PlayerScore > ComputerScore ? Winner.Player : Winner.Computer;

    public override string ToString() => $"[{PlayedDate}] - " + (PlayerScore > ComputerScore
        ? $"Player glassed computer {PlayerScore} to {ComputerScore}"
        : $"Computer annihilated computer {PlayerScore} to {ComputerScore}");
}