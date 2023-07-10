using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using madden.Models;

namespace YourNamespace.Controllers
{
    // removes view support [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller//Base
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public UserController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromForm] RegisterModel model)
        {


        Console.WriteLine("info: " + model.Password + model.Username);
        if (ModelState.IsValid)
        {
            Console.WriteLine("State was valid");
        }
        else
        {
            Console.WriteLine("State was NOT valid");
            var errors = ModelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage));
        
            foreach (var error in errors)
            {
            // You can log, display, or handle each error message as needed
            // For example, you can use a logger to log the errors:
            Console.WriteLine(error);
            }
            return View("RegisterForm");
        }
            var user = new IdentityUser { UserName = model.Username} ;
            var result = await _userManager.CreateAsync(user, model.Password);
            Console.WriteLine("User successfully");
            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, isPersistent: false);
                Console.WriteLine("User created successfully");
                return Ok();
            }
            Console.WriteLine("created successfully");
            return View("RegisterForm");
            return BadRequest(result.Errors);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromForm] LoginModel model)
        {
            var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password, isPersistent: false, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                return Ok();
            }

            return BadRequest("Invalid login attempt.");
        }
    
        [Route("login")]
        [HttpGet]
        public ViewResult LoginForm()
        {
            return View();
        }

        [Route("register")]
        [HttpGet]
        public ViewResult RegisterForm()
        {
            return View();
        }

        [HttpGet("me")]
        public async Task<IActionResult> GetCurrentUser()
        {
            var user = await _userManager.GetUserAsync(User);
            
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPost("unregister")]
        public async Task<IActionResult> Unregister()
        {
            var user = await _userManager.GetUserAsync(User);

            if (user != null)
            {
                var result = await _userManager.DeleteAsync(user);

                if (result.Succeeded)
                {
                    await _signInManager.SignOutAsync();
                    return Ok();
                }

                return BadRequest(result.Errors);
            }

            return NotFound();
        }
    }

}

