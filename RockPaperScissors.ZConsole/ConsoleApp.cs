using RockPaperScissors.Core;
using RockPaperScissors.Core.Domain;
using RockPaperScissors.Core.Utils;
using RockPaperScissors.ZConsole.Domain;
using RockPaperScissors.ZConsole.Utils;

namespace RockPaperScissors.ZConsole;

public class ConsoleApp
{
    private readonly Menu _menu = new();
    private readonly History _history = new();

    public void Run()
    {
        while (true)
        {
            _menu.PrintMainMenu();
            
            var choice = _menu.ReadMainMenuChoice();
            switch (choice)
            {
                case MainMenuChoice.Play:
                    Play();
                    break;
                case MainMenuChoice.Leaderboard:
                    DisplayHistory();
                    break;
                case MainMenuChoice.Quit:
                default:
                    Console.WriteLine("Terminating program...");
                    return;
            }
        }
    }


    private void Play()
    {
        _menu.PrintGameMenu();
        var game = new Game();
        string[] validInput = ["1", "2", "3"];

        while (true)
        {
            Console.WriteLine("Select your hand: (1) {0}, (2) {1}, (3) {2} or (0) to Quit.",
                HandHelper.GetHandSymbol(Hand.Rock),
                HandHelper.GetHandSymbol(Hand.Paper),
                HandHelper.GetHandSymbol(Hand.Scissors));

            var input = Console.ReadLine() ?? string.Empty;
            if (input.Equals("0"))
                return;

            if (!validInput.Any(s => s.Equals(input)))
            {
                Console.WriteLine("Invalid input, try again.");
                continue;
            }

            var hand = HandHelper.GetHand(input);
            var currentRound = game.PlayRound(hand);

            var winner = currentRound.GetWinner();
            switch (winner)
            {
                case Winner.Player:
                    Console.WriteLine("Player prevails with {0} over Computer with {1}",
                        HandHelper.GetHandSymbol(currentRound.PlayerHand),
                        HandHelper.GetHandSymbol(currentRound.ComputerHand));
                    break;
                case Winner.Computer:
                    Console.WriteLine("Computer prevails with {0} over Player with {1}",
                        HandHelper.GetHandSymbol(currentRound.ComputerHand),
                        HandHelper.GetHandSymbol(currentRound.PlayerHand));
                    break;
                case Winner.None:
                default:
                    Console.WriteLine("Draw! Are you even trying?");
                    break;
            }

            Console.WriteLine("Score:\nPlayer {0} - {1} Computer", game.PlayerScore, game.ComputerScore);

            if (!game.HasWinner())
                continue;

            string item;
            if (winner.Equals(Winner.Player))
            {
                ConsoleHelper.WriteLine("Player wins!", ConsoleColor.Green);
                item = $"Player glassed computer {game.PlayerScore} - {game.ComputerScore}";
            }
            else
            {
                ConsoleHelper.WriteLine("Computer wins!", ConsoleColor.Red);
                item = $"Computer annihilated computer {game.PlayerScore} - {game.ComputerScore}";
            }

            _history.AddToHistory(item);
            break;
        }
    }

    private void DisplayHistory()
    {
        _history.PrintHistory();
    }
}