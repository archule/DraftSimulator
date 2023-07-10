using Microsoft.AspNetCore.Mvc;
using madden.Models;
namespace madden.Controllers;
using Microsoft.AspNetCore.Identity;


/*
 * This file contains actions that handle requests to endpoints
 * 
 * routing systen sekects endpoint for HTTP Request
 * A route --> a rule used to decide how a request is handled 
 * 
 * for MVC: / /Home /Home/Index --> Index()
 * 
 * 
 */
[ApiController]
[Route("[controller]")]
/* Controller --> has Views
   ControllerBase --> no views */
public class RoomsController : Controller/*Base*/
{

    private readonly UserManager<IdentityUser> _userManager;
    private readonly SignInManager<IdentityUser> _signInManager;

    public RoomsController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

    [HttpGet]
    // IActionResult
    public async Task<IActionResult> Get()
    {
        Console.WriteLine("HEY");
            
        if (await this.userIsLoggedIn())
        {
            return View("Room");
        } else {
            return RedirectToAction("RegisterForm", "Views");
        }
        //Room room = new Room("Get Request");
        //return room;
        
    }

    private async Task<bool> userIsLoggedIn()
    { 
        var user = await _userManager.GetUserAsync(User);
        Console.WriteLine(user?.UserName);
        return user != null;
    }



    [HttpPost]
    // IActionResult
    public string GetPost()
    {      
        return "";
        //Room room = new Room("post request");
        //return room;
    }
 
    [HttpPut]
    // IActionResult
    public string GetPut()
    {
        return "";
        //Room room = new Room("put request");
        //return room;
    }

    [HttpDelete]
    // IActionResult
    public string GetDelete()
    {
        return "";
        //Room room = new Room("delete request");
        //return room;
    }

    [HttpPatch]
    // IActionResult
    public string GetPatch()
    {
        return "";
        //Room room = new Room("patch request");
        //return room;
    }


}