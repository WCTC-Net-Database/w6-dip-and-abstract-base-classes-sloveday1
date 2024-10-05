namespace W6_assignment_template.Interfaces;

public interface IRoom
{
    string Name { get; set; }
    string Description { get; set; }
    
    IRoom North { get; set; }
    IRoom South { get; set; }
    IRoom East { get; set; }
    IRoom West { get; set; }
}
