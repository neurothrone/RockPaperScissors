using RockPaperScissors.CLI.Client.Services;
using RockPaperScissors.CLI.Client.Utils;

namespace RockPaperScissors.CLI.Client.Domain;

class History
{
    private const string HistoryFilePath = "/Users/zane/history.json";

    private readonly StorageService _storageService = new();
    private List<GameOutcome> _history = [];

    private bool HasHistory() => _history.Count != 0;

    public void AddToHistory(GameOutcome outcome)
    {
        _history.Add(outcome);
    }

    public void PrintHistory()
    {
        if (!HasHistory())
        {
            ConsoleHelper.WriteLine("No history available yet.", ConsoleColor.Yellow);
            ConsoleHelper.WriteDividerLine(ConsoleColor.Yellow);
            return;
        }

        ConsoleHelper.WriteLine("History", ConsoleColor.Yellow);
        ConsoleHelper.WriteDividerLine(ConsoleColor.Yellow);
        foreach (var outcome in _history)
            Console.WriteLine(outcome);
        ConsoleHelper.WriteDividerLine(ConsoleColor.Yellow);
    }

    public void SaveToFile()
    {
        if (HasHistory())
            _storageService.WriteToJsonFile(HistoryFilePath, _history);
    }

    public void LoadFromFile()
    {
        var history = _storageService.ReadFromJsonFile<List<GameOutcome>>(HistoryFilePath);
        if (history is not null)
            _history = history;
    }
}