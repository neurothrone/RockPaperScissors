namespace RockPaperScissors.Console.Client.Domain;

class Menu
{
    public void PrintMainMenu()
    {
        System.Console.WriteLine("1. Play");
        System.Console.WriteLine("2. Leaderboard");
        System.Console.WriteLine("0. Quit");
        System.Console.WriteLine("-----------------");
    }

    public void PrintGameMenu()
    {
        System.Console.WriteLine("Playing Rock Paper Scissors!");
        System.Console.WriteLine("1. Rock");
        System.Console.WriteLine("2. Paper");
        System.Console.WriteLine("3. Scissor");
        System.Console.WriteLine("0. Quit");
        System.Console.WriteLine("-----------------");
    }

    public MainMenuSelection ReadMainMenuInput()
    {
        while (true)
        {
            if (Enum.TryParse(System.Console.ReadLine(), out MainMenuSelection selection) &&
                Enum.IsDefined(typeof(MainMenuSelection), selection))
                return selection;

            System.Console.WriteLine("Invalid input, try again.");
        }
    }
}