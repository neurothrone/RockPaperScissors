using RockPaperScissors.Console.Client.Domain;
using RockPaperScissors.Console.Client.Utils;
using RockPaperScissors.Core;
using RockPaperScissors.Core.Domain;
using RockPaperScissors.Core.Utils;

namespace RockPaperScissors.Console.Client;

public class ConsoleApp
{
    private readonly Game _game = new();
    private readonly History _history = new();
    private readonly Menu _menu = new();

    public void Run()
    {
        _history.LoadFromFile();

        while (true)
        {
            _menu.PrintMainMenu();

            switch (_menu.ReadMainMenuInput())
            {
                case MainMenuSelection.Play:
                    Play();
                    break;
                case MainMenuSelection.Leaderboard:
                    DisplayHistory();
                    break;
                case MainMenuSelection.Quit:
                default:
                    System.Console.WriteLine("Terminating program...");
                    return;
            }
        }
    }

    private string GetGameInput()
    {
        System.Console.WriteLine("Select your hand: (1) {0}, (2) {1}, (3) {2} or (0) to Quit.",
            HandHelper.GetHandSymbol(Hand.Rock),
            HandHelper.GetHandSymbol(Hand.Paper),
            HandHelper.GetHandSymbol(Hand.Scissors));

        return System.Console.ReadLine() ?? string.Empty;
    }

    private GameSelection ConvertToGameSelection(string input)
    {
        return input switch
        {
            "0" => GameSelection.Quit,
            "1" => GameSelection.Rock,
            "2" => GameSelection.Paper,
            "3" => GameSelection.Scissors,
            _ => GameSelection.Invalid
        };
    }

    private void Play()
    {
        _menu.PrintGameMenu();

        while (true)
        {
            var input = GetGameInput();
            switch (ConvertToGameSelection(input))
            {
                case GameSelection.Quit:
                    return;
                case GameSelection.Invalid:
                    System.Console.WriteLine("Invalid input.");
                    continue;
                case GameSelection.Rock:
                case GameSelection.Paper:
                case GameSelection.Scissors:
                default:
                    PlayRound(input);
                    break;
            }

            if (!_game.HasWinner())
                continue;

            ProcessEndGame();
            break;
        }
    }

    private void PlayRound(string handInput)
    {
        var hand = HandHelper.GetHand(handInput);
        var currentRound = _game.PlayRound(hand);
        ProcessRound(currentRound);
    }

    private void ProcessRound(Round round)
    {
        System.Console.WriteLine("Score:\nPlayer {0} - {1} Computer", _game.PlayerScore, _game.ComputerScore);

        switch (round.GetWinner())
        {
            case Winner.Player:
                System.Console.WriteLine("Player prevails with {0} over Computer with {1}",
                    HandHelper.GetHandSymbol(round.PlayerHand),
                    HandHelper.GetHandSymbol(round.ComputerHand));
                break;
            case Winner.Computer:
                System.Console.WriteLine("Computer prevails with {0} over Player with {1}",
                    HandHelper.GetHandSymbol(round.ComputerHand),
                    HandHelper.GetHandSymbol(round.PlayerHand));
                break;
            case Winner.None:
            default:
                System.Console.WriteLine("Draw! Are you even trying?");
                break;
        }
    }

    private void ProcessEndGame()
    {
        var gameOutcome = new GameOutcome
        {
            PlayerScore = _game.PlayerScore,
            ComputerScore = _game.ComputerScore
        };

        if (gameOutcome.Winner.Equals(Winner.Player))
            ConsoleHelper.WriteLine("Player wins!", ConsoleColor.Green);
        else
            ConsoleHelper.WriteLine("Computer wins!", ConsoleColor.Red);

        _history.AddToHistory(gameOutcome);
        _history.SaveToFile();
    }

    private void DisplayHistory()
    {
        _history.PrintHistory();
    }
}