/*(Domain Model define the domain of the app through 
 * real-world object representations
 * 
 * Domain Objects 
 */

public class Player
{


    /*
     * Set the properties for the class
     * ? means nullable
     */
    public string? Name { get; set; }
    public int? Age { get; set; }
    public string? College { get; set; }
    public int? Height { get; set; }
    public int? Weight { get; set; }
    public string? Position { get; set; }
    public string? Rating { get; set; }
    public SpecialTraits? traits { get; set; }

}