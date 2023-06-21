using System.Diagnostics;
namespace Madden.Models.Room;

public class Room
{
    /*
     * Set the properties for the class
     * ? means nullable
     */
    public string? Name { get; set; }
    public int Id { get; set; }
    public string Code { get; set; }
    public int NumberOfPicks { get; set; }
    public List<Team> Teams { get; set; }
    public ApplicationUser Creator { get; set; }
    public List<ApplicationUser> Players { get; set; }
    public Dictionary<Team, ApplicationUser> Mapping { get; set; }
}