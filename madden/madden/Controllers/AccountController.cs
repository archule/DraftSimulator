using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using madden.Models;

[ApiController]
[Route("api/[controller]")]
public class AccountController : ControllerBase
{
    private readonly UserManager<ApplicationUser> _userManager;

    public AccountController(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    [HttpGet("signup/{username}")]
    public async Task<IActionResult> GetPassword(string username)
    {
        var user = await _userManager.FindByNameAsync(username);

        if (user == null)
        {
            return NotFound(); // User not found
        }

        var passwordHash = user.PasswordHash;

        return Ok(passwordHash);
    }

    [HttpPost("signup")]
    public async Task<IActionResult> SignUp([FromBody] SignUpModel model)
    {
        var user = new ApplicationUser
        {
            UserName = model.Username
        };

        var result = await _userManager.CreateAsync(user, model.Password);

        if (result.Succeeded)
        {
            // User created successfully
            return Ok();
        }
        else
        {
            // Handle failed user creation
            // ...
            return BadRequest(result.Errors);
        }
    }
}

public class SignUpModel
{
    public string Username { get; set; }
    public string Password { get; set; }
}
