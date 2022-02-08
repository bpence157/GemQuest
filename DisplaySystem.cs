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

        Console.WriteLine("Please type \"fighter\", \"knight\", \"mage\", or \"rogue\" to choose a class. A fighter starts with higher Strength but lower Health, while a knight starts with " +
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
            if (playerEntry == "mage")
            {
                playerChosenClass = "Mage";
                Console.WriteLine();
                break;
            }
            if (playerEntry == "rogue")
            {
                playerChosenClass = "Rogue";
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
            return new Player(playerChosenName, "Fighter", 5, 7, 5, 6, inventorySystem, playerPosition);
        }
        if (playerChosenClass == "Knight")
        {
            return new Player(playerChosenName, "Knight", 10, 5, 6, 3, inventorySystem, playerPosition);
        }
        if (playerChosenClass == "Mage")
        {
            return new Player(playerChosenName, "Mage", 4, 3, 8, 7, inventorySystem, playerPosition);
        }
        if (playerChosenClass == "Rogue")
        {
            return new Player(playerChosenName, "Rogue", 5, 4, 6, 8, inventorySystem, playerPosition);
        }
        else
        {
            return null;
        }

    }

    public static void DisplayHelp()
    {
        Console.WriteLine("HELP:");
        Console.WriteLine("\"inventory\" - Brings up player inventory.");
        Console.WriteLine("\"exit\" - Exits help menu.");
        Console.WriteLine("\"stats\" - Display player stats.");
    }

    public static void DisplayPlayerStats(Player player)
    {
        Console.WriteLine();
        Console.WriteLine(player.PlayerName);
        Console.WriteLine("---------");
        Console.WriteLine("Player Class: " + player.PlayerClass);
        Console.WriteLine("Player Health: " + player.PlayerHealth);
        Console.WriteLine("---------");
        Console.WriteLine("Player Strength: " + player.PlayerStrength);
        Console.WriteLine("Player Intelligence: " + player.PlayerIntelligence);
        Console.WriteLine("Player Agility: " + player.PlayerAgility);
        Console.WriteLine("---------");
        Console.WriteLine($"Player Position: ({player.PlayerPosition.XCoordinates}, {player.PlayerPosition.YCoordinates})");
        Console.WriteLine();
    }
    public static void DisplayPlayerInventory(Player player)
    {

    }
}
