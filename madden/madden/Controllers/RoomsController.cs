using Microsoft.AspNetCore.Mvc;
using madden.Models;
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
    public string Get()
    {
        Console.WriteLine("HEY");
        return "";
        //Room room = new Room("Get Request");
        //return room;
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