namespace madden.Models;
using System.ComponentModel.DataAnnotations;

public class RegisterModel
{
    [Key]
    public string Username { get; set; }
    
    [Required]
    [MinLength(8, ErrorMessage = "The password must be at least 8 characters long.")]
    [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*\W).*$", ErrorMessage = "The password must have at least one uppercase letter, one lowercase letter, one digit, and one special character.")]
    public string Password { get; set; }

}