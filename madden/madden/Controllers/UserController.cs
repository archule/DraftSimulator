using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using madden.Models;

namespace madden.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
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

            if (!ModelState.IsValid)
            {
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
            } else {

                var errors = result.Errors;
                List<string> errorMessages = new List<string>();
                foreach(var error in errors) {
                    errorMessages.Add(error.Description);
                    Console.WriteLine(error.Description);
                    ModelState.AddModelError(error.Code, error.Description);
                }
                
                return View("RegisterForm");
            }
        
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

