using System.ComponentModel.DataAnnotations;

namespace madden.Dtos
{
    public class PlayerReadDto
    {
        [Key]
        [Required]
        public int Id { get; set; }


        public string? FirstName { get; set; }


        public string? LastName { get; set; }


        public string? Image { get; set; }

        public int? Age { get; set; }

        public string? College { get; set; }

        public string? Height { get; set; }

     
        public double? Weight { get; set; }

        
        public string? Position { get; set; }

        public double? Rating { get; set; }

        public string? Arms { get; set; }

        public string? Hands { get; set; }

        public double Bench { get; set; }

        public double? VerticalJump { get; set; }

        public double? BroadJump { get; set; }

        public double? ThreeCone { get; set; }


        public double? TwentyYardShuttle { get; set; }

        public double? SixtyYardShuttle { get; set; }

        public string? ScoutReport { get; set; }

        public string? Year { get; set; }

        public string? Class { get; set; }


    }
}