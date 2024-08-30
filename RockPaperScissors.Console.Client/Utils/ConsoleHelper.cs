namespace RockPaperScissors.Console.Client.Utils;

public static class ConsoleHelper
{
    public static void WriteLine(string line, ConsoleColor foregroundColor)
    {
        System.Console.ForegroundColor = foregroundColor;
        System.Console.WriteLine(line);
        System.Console.ResetColor();
    }
}