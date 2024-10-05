using W6_assignment_template.Interfaces;

namespace W6_assignment_template.Data;

public interface IRoomFactory
{
    IRoom CreateRoom(string roomType);
}
