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
