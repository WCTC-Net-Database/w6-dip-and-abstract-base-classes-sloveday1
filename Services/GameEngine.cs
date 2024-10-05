using W6_assignment_template.Data;
using W6_assignment_template.Interfaces;
using W6_assignment_template.Models;

namespace W6_assignment_template.Services
{
    public class GameEngine
    {
        private readonly IContext _context;
        private readonly Player _player;
        private readonly Goblin _goblin;
        private readonly IRoomFactory _roomFactory;

        public GameEngine(IContext context, IRoomFactory roomFactory)
        {
            _context = context;
            _player = context.Characters.OfType<Player>().FirstOrDefault();
            _goblin = _context.Characters.OfType<Goblin>().FirstOrDefault();
            _roomFactory = roomFactory;
        }

        public void Run()
        {
            if (_player == null || _goblin == null)
            {
                Console.WriteLine("Failed to initialize game characters.");
                return;
            }

            var startingRoom = SetupRoom();
            _player.MoveToRoom(startingRoom);
            
            Console.WriteLine($"Player Gold: {_player.Gold}");

            _goblin.Move();
            _goblin.Attack(_player);

            _player.Move();
            _player.Attack(_goblin);

            Console.WriteLine($"Player Gold: {_player.Gold}");
            
            _player.MoveToRoom(startingRoom.East);
            
            // Example CRUD operations for Goblin
            var newGoblin = new Goblin("New Goblin", "Goblin", 1, 30, "None");
            _context.AddCharacter(newGoblin);

            newGoblin.Level = 2;
            _context.UpdateCharacter(newGoblin);

            _context.DeleteCharacter("New Goblin");
        }
        
        public IRoom SetupRoom()
        {
            var entrance = _roomFactory.CreateRoom("Entrance");
            var livingRoom = _roomFactory.CreateRoom("Living Room");
            var office = _roomFactory.CreateRoom("Office");
            var parlor = _roomFactory.CreateRoom("Parlor");
            var mystery = _roomFactory.CreateRoom("Mystery");
            var hallway = _roomFactory.CreateRoom("Hallway");
            var hallway2 = _roomFactory.CreateRoom("Hallway");

            entrance.East = hallway;
            entrance.West = hallway2;
            hallway.West = entrance;
            hallway2.East = entrance;
            hallway.South = livingRoom;
            livingRoom.North = hallway;
            office.East = livingRoom;
            livingRoom.West = office;
            parlor.North = hallway2;
            hallway2.South = parlor;
            parlor.West = mystery;
            mystery.East = parlor;
        
            return entrance;
        }
    }
}
