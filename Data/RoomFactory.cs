using W6_assignment_template.Interfaces;
using W6_assignment_template.Models;

namespace W6_assignment_template.Data;

public class RoomFactory : IRoomFactory
{
    public IRoom CreateRoom(string roomType)
    {
        switch (roomType)
        {
            case "Entrance":
                return new Room("Entrance", "Entrance room with a mysterious door"); 
            case "Living Room":
                return new Room("Living Room", "Room with a fireplace and a bookshelf next to it");
            case "Office":
                return new Room("Office", "A room with a desk and some suspicious cheese");
            case "Parlor":
                return new Room("Parlor Room", "A big room with a nice piano");
            case "Mystery":
                return new Room("Mysterious Room", "A mysterious room with weirdly placed chairs");
            case "Hallway":
                return new Room("Hallway", "A hallway leading to a door");
            default:
                return new Room();
        }
    }
}
