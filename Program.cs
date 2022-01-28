using System;
using System.Collections.Generic;

//Gameworld initilization
GameWorld gameWorld = GameWorld.CreateStandardWorld();

//Info presented to player
DisplaySystem.DisplayIntro1();

//Player customization
Player player = DisplaySystem.PlayerCustomization();

//Info presented to player
DisplaySystem.DisplayIntro2();

//Game logic
while (true)
{
    Console.WriteLine($"You are currently at position ({player.PlayerPosition.XCoordinates}, {player.PlayerPosition.YCoordinates})");

    //Player movement
    string userEntry = DisplaySystem.RequestMovementFromPlayer();
    if(userEntry == "help")
    {
        DisplaySystem.DisplayHelp();
    }
    else if(userEntry == "n")
    {
        if((player.PlayerPosition.YCoordinates + 1) > 9)
        {
            Console.WriteLine("You cannot move any further in that direction.");
        }
        else
        {
            player.PlayerPosition.YCoordinates++;
        }
    }
    else if (userEntry == "e")
    {
        if ((player.PlayerPosition.XCoordinates + 1) > 9)
        {
            Console.WriteLine("You cannot move any further in that direction.");
        }
        else
        {
            player.PlayerPosition.XCoordinates++;
        }
    }
    else if (userEntry == "s")
    {
        if ((player.PlayerPosition.YCoordinates - 1) < 0)
        {
            Console.WriteLine("You cannot move any further in that direction.");
        }
        else
        {
            player.PlayerPosition.YCoordinates--;
        }
    }
    else if (userEntry == "w")
    {
        if ((player.PlayerPosition.XCoordinates - 1) < 0)
        {
            Console.WriteLine("You cannot move any further in that direction.");
        }
        else
        {
            player.PlayerPosition.XCoordinates--;
        }
    }
    else
    {
        Console.WriteLine("Sorry, I did not understand that. Please try again.");
        Console.WriteLine();
    }

    //Player interaction with environment
    Room enteredRoom = gameWorld.Rooms.Find(Room => Room.RoomPosition.XCoordinates == player.PlayerPosition.XCoordinates && Room.RoomPosition.YCoordinates == player.PlayerPosition.YCoordinates);
    if (enteredRoom.RoomType == RoomType.Gem)
    {
        Console.WriteLine("You have found the gem!");
        gameWorld.GameWin = true;
        break;
    }
    else if (enteredRoom.RoomType == RoomType.PitFall)
    {
        Console.WriteLine("You have fallen into a pit! Game over!");
        break;
    }
    else if (enteredRoom.RoomType == RoomType.Monster)
    {
        Console.WriteLine("You have been attacked by a monster! Game over!");
        break;
    }
    else
    {
        Console.WriteLine("You have entered an empty room.");
    }
}

public class Player
{
    string PlayerName { get; set; }
    string PlayerClass { get; set; }
    int PlayerHealth { get; set; }
    int PlayerStrength { get; set; }
    InventorySystem PlayerInventory { get; set; }
    public Position PlayerPosition { get; set; }

    public Player(string playerName, string playerClass, int playerHealth, int playerStrength, InventorySystem playerInventory, Position playerPosition)
    {
        PlayerName = playerName;
        PlayerClass = playerClass;
        PlayerHealth = playerHealth;
        PlayerStrength = playerStrength;
        PlayerInventory = playerInventory;
        PlayerPosition = playerPosition;
    }

}

public class InventorySystem
{
    List<Items> Inventory;
}

public class Items
{

}

public class Position
{
    public int XCoordinates { get; set; }
    public int YCoordinates { get; set; }

    public Position(int xCoordinates, int yCoordinates)
    {
        XCoordinates = xCoordinates;
        YCoordinates = yCoordinates;
    }

}

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

public class Room
{
    public RoomType RoomType { get; private set; }
    public Position RoomPosition { get; set; }

    public Room(RoomType roomType, Position position)
    {
        RoomType = roomType;
        RoomPosition = position;
    }

    public bool EventPresent()
    {
        if (this.RoomType == RoomType.Gem)
        {
            return true;
        }
        else if (this.RoomType == RoomType.Monster)
        {
            return true;
        }
        else if (this.RoomType == RoomType.PitFall)
        {
            return true;
        }
        else
            return false;
    }

}

public class GameWorld
{
   public List<Room> Rooms { get; set; }
   public bool GameWin { get; set; }

    public GameWorld(List<Room> rooms)
    {
        Rooms = rooms;
    }
    public static GameWorld CreateStandardWorld()
    {
        List<Room> rooms = new List<Room>();
        int yAxis = 0;
        int xAxis = 0;

        //Populate list of rooms by coordinates
        while (xAxis < 10)
        {
            while (yAxis < 10)
            {
                //Populate event rooms
                if (xAxis == 0 && yAxis == 0) rooms.Add(new Room(RoomType.Entrance, new Position(xAxis, yAxis)));
                if (xAxis == 2 && yAxis == 1) rooms.Add(new Room(RoomType.Monster, new Position(xAxis, yAxis)));
                if (xAxis == 7 && yAxis == 1) rooms.Add(new Room(RoomType.PitFall, new Position(xAxis, yAxis)));
                if (xAxis == 3 && yAxis == 3) rooms.Add(new Room(RoomType.PitFall, new Position(xAxis, yAxis)));
                if (xAxis == 8 && yAxis == 3) rooms.Add(new Room(RoomType.Monster, new Position(xAxis, yAxis)));
                if (xAxis == 0 && yAxis == 5) rooms.Add(new Room(RoomType.Monster, new Position(xAxis, yAxis)));
                if (xAxis == 6 && yAxis == 5) rooms.Add(new Room(RoomType.PitFall, new Position(xAxis, yAxis)));
                if (xAxis == 8 && yAxis == 6) rooms.Add(new Room(RoomType.Gem, new Position(xAxis, yAxis)));
                if (xAxis == 2 && yAxis == 7) rooms.Add(new Room(RoomType.PitFall, new Position(xAxis, yAxis)));
                if (xAxis == 3 && yAxis == 7) rooms.Add(new Room(RoomType.PitFall, new Position(xAxis, yAxis)));
                if (xAxis == 5 && yAxis == 7) rooms.Add(new Room(RoomType.Monster, new Position(xAxis, yAxis)));
                if (xAxis == 8 && yAxis == 8) rooms.Add(new Room(RoomType.PitFall, new Position(xAxis, yAxis)));

                //Populate empty rooms
                else
                {
                    rooms.Add(new Room(RoomType.Empty, new Position(xAxis, yAxis)));
                }

                yAxis++;
            }

            xAxis++;
            yAxis = 0;
        }

        return new GameWorld(rooms);
    }

    public void DisplayAllRooms()
    {
        foreach (Room room in Rooms)
        {
            Console.WriteLine($"{room.RoomPosition.XCoordinates}, {room.RoomPosition.YCoordinates}, {room.RoomType}");
        }
    }
}

public enum RoomType
{
    Empty,
    Gem,
    Monster,
    PitFall,
    Entrance
}