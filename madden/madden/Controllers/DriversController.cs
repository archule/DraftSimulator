using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using madden.Models;

namespace madden.Controllers
{
[ApiController]
[Route("[controller]")]
public class DriversController : ControllerBase {

    
    private static List<Driver> drivers = new List<Driver>();
    [HttpPost]
    public IActionResult AddDriver(Driver driver) {
    if(ModelState.IsValid) {
        drivers.Add(driver);
        return CreatedAtAction("GetDriver", new {id = driver.Id}, driver);
    }   

    return BadRequest();
    }

    [HttpGet]
    public IActionResult GetDriver(Guid id) {
        var driver = drivers.Find(d => d.Id == id);
        if(driver == null) {
            return NotFound();
        }
        return Ok(driver);
    }

    [HttpDelete]
    public IActionResult DeleteDriver(Guid id) {    
        var driver = drivers.Find(d => d.Id == id);
        if(driver == null) {
            return NotFound();
        }
        driver.Status = 0;
        //drivers.Remove(driver);
        //return Ok();
        return NoContent();
    }

}
    }






