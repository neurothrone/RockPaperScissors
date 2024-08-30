using RockPaperScissors.CLI.Client.Utils;

namespace RockPaperScissors.CLI.Client.Domain;

class Menu
{
    public void PrintMainMenu()
    {
        Console.WriteLine("1. Play");
        Console.WriteLine("2. Leaderboard");
        Console.WriteLine("0. Quit");
        ConsoleHelper.WriteDividerLine();
    }

    public MainMenuSelection ReadMainMenuInput()
    {
        while (true)
        {
            if (Enum.TryParse(Console.ReadLine(), out MainMenuSelection selection) &&
                Enum.IsDefined(typeof(MainMenuSelection), selection))
                return selection;

            Console.WriteLine("Invalid input, try again.");
        }
    }
}