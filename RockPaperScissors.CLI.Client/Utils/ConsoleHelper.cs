namespace RockPaperScissors.CLI.Client.Utils;

public static class ConsoleHelper
{
    private const string Divider = "-----------------------------";

    public static void WriteLine(string line, ConsoleColor foregroundColor)
    {
        Console.ForegroundColor = foregroundColor;
        Console.WriteLine(line);
        Console.ResetColor();
    }

    public static void WriteDividerLine(ConsoleColor? foregroundColor = null)
    {
        if (foregroundColor is not null)
        {
            WriteLine(Divider, foregroundColor.Value);
            return;
        }

        Console.WriteLine(Divider);
    }
}