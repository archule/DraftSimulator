namespace madden.Models;
using System.ComponentModel.DataAnnotations;

public class RegisterModel
{
    public string Username { get; set; }
    
    //[RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*\W).{8,}$",
    //ErrorMessage = "The password must contain at least 1 uppercase character, 1 lowercase character, 1 digit, and 1 non-alphanumeric character.")]
    public string Password { get; set; }
}