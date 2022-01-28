using System;

public class DisplaySystem
{
    public static void DisplayIntro1()
    {
        Console.WriteLine("Welcome to GemQuest! GemQuest is a text based RPG that is played with a keyboard. You will be provided information" +
            " on screen and prompted for your response. Then, type your desired command and press Enter. Type \"Help\" at any time to bring up a command menu.");
        Console.WriteLine();
    }

    public static void DisplayIntro2()
    {
        Console.WriteLine("You have just stepped into the Cave of Gems. There is an entrance behind you, and light shines in, revealing the outside world. You cannot leave until your quest is complete. ");
        Console.WriteLine();
    }

    public static string RequestMovementFromPlayer()
    {
        Console.WriteLine("What direction would you like to move in? (Enter N, E, S, W to move in one of the cardinal directions.");
        Console.WriteLine();
        return (Console.ReadLine()).ToLower(); ;
    }
    public static Player PlayerCustomization()
    {
        string playerChosenName;
        string playerChosenClass;
        InventorySystem inventorySystem = new InventorySystem();
        Position playerPosition = new Position(0, 0);

        Console.WriteLine("Please enter your character's name: ");
        while (true)
        {
            string playerEntry = Convert.ToString(Console.ReadLine());

            if (playerEntry.Length > 20)
            {
                Console.WriteLine("Please enter a name no longer than 20 characters.");
            }
            else
            {
                playerChosenName = playerEntry;
                Console.WriteLine();
                break;
            }
        }

        Console.WriteLine("Please type \"fighter\" or \"knight\" to choose a class. A fighter starts with higher Strength but lower Health, while a knight starts with " +
            "higher Health, but lower Strength.");
        while (true)
        {
            string playerEntry = Convert.ToString(Console.ReadLine());
            playerEntry = playerEntry.ToLower();

            if (playerEntry == "fighter")
            {
                playerChosenClass = "Fighter";
                Console.WriteLine();
                break;
            }
            if (playerEntry == "knight")
            {
                playerChosenClass = "Knight";
                Console.WriteLine();
                break;
            }
            else
            {
                Console.WriteLine("Sorry, I did not understand that. Please try again.");
            }
        }

        Console.WriteLine($"{playerChosenName}, you are a {playerChosenClass}.");
        Console.WriteLine();
        if (playerChosenClass == "Fighter")
        {
            return new Player(playerChosenName, "Fighter", 5, 7, inventorySystem, playerPosition);
        }
        else
        {
            return new Player(playerChosenName, "Knight", 10, 4, inventorySystem, playerPosition);
        }

    }

    public static void DisplayHelp()
    {
        Console.WriteLine("HELP:");
        Console.WriteLine("\"inventory\" - Brings up player inventory");
        Console.WriteLine("\"exit\" - Exits game");
    }
}
