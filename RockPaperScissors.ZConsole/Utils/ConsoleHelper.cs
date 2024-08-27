namespace RockPaperScissors.ZConsole.Utils;

public static class ConsoleHelper
{
    public static void WriteLine(string line, ConsoleColor foregroundColor)
    {
        Console.ForegroundColor = foregroundColor;
        Console.WriteLine(line);
        Console.ResetColor();
    }
}