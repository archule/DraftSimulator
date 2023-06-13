using System.Diagnostics;
namespace Madden.Models.Room;

public class Room
{

    public Room(string name) {
        this.Name = name;
    }

    /*
     * Set the properties for the class
     * ? means nullable
     */
    public string? Name { get; set; }
}