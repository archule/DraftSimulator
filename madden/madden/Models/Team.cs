namespace madden.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Serialization;
public class Team
{
    /*
     * Set the properties for the class
     * ? means nullable
     */
    [Key]
    [JsonPropertyName("team")]
    public string? Name { get; set; }

    [JsonPropertyName("picks")]
    public List<int>? teamPicks { get; set;}
    
}