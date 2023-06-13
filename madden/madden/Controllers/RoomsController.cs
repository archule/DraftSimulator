using Microsoft.AspNetCore.Mvc;
using Madden.Models.Room;
namespace madden.Controllers;


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

    [HttpGet]
    // IActionResult
    public Room Get()
    {
        Room room = new Room("Get Request");
        return room;
    }

    [HttpPost]
    // IActionResult
    public Room GetPost()
    {
        Room room = new Room("post request");
        return room;
    }
 
    [HttpPut]
    // IActionResult
    public Room GetPut()
    {
        Room room = new Room("put request");
        return room;
    }

    [HttpDelete]
    // IActionResult
    public Room GetDelete()
    {
        Room room = new Room("delete request");
        return room;
    }

    [HttpPatch]
    // IActionResult
    public Room GetPatch()
    {
        Room room = new Room("patch request");
        return room;
    }


}