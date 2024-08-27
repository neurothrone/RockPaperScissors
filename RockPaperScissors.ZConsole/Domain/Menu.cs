namespace RockPaperScissors.ZConsole.Domain;

class Menu
{
    public void PrintMainMenu()
    {
        Console.WriteLine("1. Play");
        Console.WriteLine("2. Leaderboard");
        Console.WriteLine("0. Quit");
        Console.WriteLine("-----------------");
    }

    public void PrintGameMenu()
    {
        Console.WriteLine("Playing Rock Paper Scissors!");
        Console.WriteLine("1. Rock");
        Console.WriteLine("2. Paper");
        Console.WriteLine("3. Scissor");
        Console.WriteLine("0. Quit");
        Console.WriteLine("-----------------");
    }

    public MainMenuChoice ReadMainMenuChoice()
    {
        while (true)
        {
            if (Enum.TryParse(Console.ReadLine(), out MainMenuChoice selection) &&
                Enum.IsDefined(typeof(MainMenuChoice), selection))
                return selection;

            Console.WriteLine("Invalid input, try again.");
        }
    }
}