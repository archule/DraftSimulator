using Microsoft.AspNetCore.Mvc;
using madden.Models;
using madden.Dtos;
using madden.Data;
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
public class RoomController : Controller/*Base*/
{

    private readonly UserManager<IdentityUser> _userManager;
    private readonly SignInManager<IdentityUser> _signInManager;
   private readonly RoomRepo _repository;
    public RoomController(RoomRepo repository,UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _repository = repository;
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
            return RedirectToHomepage();
        }
        //Room room = new Room("Get Request");
        //return room;
        
    }

    private  ActionResult RedirectToHomepage()
    {
        return RedirectToAction("Index", "Views");
    }
 

    private async Task<bool> userIsLoggedIn()
    { 
        var user = await _userManager.GetUserAsync(User);
        Console.WriteLine(user?.UserName);
        return user != null;
    }

        private async Task<IdentityUser> getUser()
    { 
        var user = await _userManager.GetUserAsync(User);
        Console.WriteLine(user?.UserName);
        return user;
    }


    [HttpPost]
    public async Task<IActionResult> Create(RoomCreateDto RoomDto)
    {   
        IdentityUser User = await getUser();
        _repository.CreateRoom(RoomDto, User);
        return Ok();
    }



   
    

        
        [HttpGet]
        [Route("Rooms")]
        public IEnumerable<Room> GetAllRooms() {
            var rooms = _repository.GetAllRooms();
            return rooms;
        }



}