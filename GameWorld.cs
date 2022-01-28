using System;
using System.Collections.Generic;

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
