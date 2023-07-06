using madden.Services;
using Microsoft.AspNetCore.Mvc;
using madden.Models;

namespace madden.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlayersController : Controller
    {

        [HttpGet]
        public IEnumerable<Player> Get()
        {
            var players = PlayersService.GetPlayers();
            return players;
            //return View(players);
        }

        [HttpPost]
        public IActionResult GetPost()
        {
            return Content("Post Request");
        }
    }
}

