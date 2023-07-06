namespace madden.Models;


public class Team
{
    /*
     * Set the properties for the class
     * ? means nullable
     */
    public string? Name { get; set; }
    public List<int>? teamPicks { get; set;}
}