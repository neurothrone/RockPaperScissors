using RockPaperScissors.ZConsole.Utils;

namespace RockPaperScissors.ZConsole.Domain;

class History
{
    private readonly List<string> _history = [];

    private bool HasHistory() => _history.Count != 0;

    public void AddToHistory(string item)
    {
        _history.Add(item);
    }

    public void PrintHistory()
    {
        if (!HasHistory())
        {
            ConsoleHelper.WriteLine("No history available yet...\n----------------", ConsoleColor.Yellow);
            return;
        }

        ConsoleHelper.WriteLine("History\n----------------", ConsoleColor.Yellow);
        for (int i = 0; i < _history.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_history[i]}");
        }
        ConsoleHelper.WriteLine("----------------", ConsoleColor.Yellow);
    }
}