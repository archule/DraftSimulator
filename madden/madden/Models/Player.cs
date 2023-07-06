/*(Domain Model define the domain of the app through 
 * real-world object representations
 * 
 * Domain Objects 
 */

using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace madden.Models
{
    public class Player
    {
        [Key]
        [JsonPropertyName("id")]
        [Required]
        public int Id { get; set; }

        [JsonPropertyName("first_name")]
        public string? FirstName { get; set; }

        [JsonPropertyName("last_name")]
        public string? LastName { get; set; }

        [JsonPropertyName("img")]
        public string? Image { get; set; }

        [JsonPropertyName("age")]
        public int? Age { get; set; }

        [JsonPropertyName("college")]
        public string? College { get; set; }

        [JsonPropertyName("height")]
        public string? Height { get; set; }

        [JsonPropertyName("weight")]
        public double? Weight { get; set; }

        [JsonPropertyName("position")]
        public string? Position { get; set; }

        [JsonPropertyName("rating")]
        public double? Rating { get; set; }

        [JsonPropertyName("arms")]
        public string? Arms { get; set; }

        [JsonPropertyName("hands")]
        public string? Hands { get; set; }

        [JsonPropertyName("bench")]
        public double Bench { get; set; }

        [JsonPropertyName("vertical_jump")]
        public double? VerticalJump { get; set; }

        [JsonPropertyName("broad_jump")]
        public double? BroadJump { get; set; }

        [JsonPropertyName("three_cone")]
        public double? ThreeCone { get; set; }

        [JsonPropertyName("twenty_yard_shuttle")]
        public double? TwentyYardShuttle { get; set; }

        [JsonPropertyName("sixty_yard_shuttle")]
        public double? SixtyYardShuttle { get; set; }

        [JsonPropertyName("scout_report")]
        public string? ScoutReport { get; set; }

        [JsonPropertyName("year")]
        public string? Year { get; set; }

        [JsonPropertyName("class")]
        public string? Class { get; set; }

        [JsonPropertyName("player_info")]
        public string? PlayerInfo { get; set; }

        public override string ToString()
        {
            return JsonSerializer.Serialize<Player>(this);
        }
    }
}
