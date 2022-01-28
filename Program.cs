using System;

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

public enum RoomType
{
    Empty,
    Gem,
    Monster,
    PitFall,
    Entrance
}