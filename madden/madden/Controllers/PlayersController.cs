using madden.Services;
using Microsoft.AspNetCore.Mvc;
using madden.Models;
using AutoMapper;
using madden.Dtos;
using madden.Data;

namespace madden.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlayersController : Controller
    {


        private readonly IPlayerRepo _repository;
        private readonly IMapper _mapper;

        public PlayersController(IPlayerRepo repo, IMapper mapper)
        {
            _repository = repo;
            _mapper = mapper;
            
        }

        [HttpGet]
        public ActionResult<IEnumerable<PlayerReadDto>> Get()
        {
            var players = _repository.GetAllPlayers();
            Console.WriteLine("Action Result");

            return Ok(_mapper.Map<IEnumerable<PlayerReadDto>>(players));
            //return View(players);
        }

        [HttpPost]
        public IActionResult GetPost()
        {
            return Content("Post Request");
        }
    }
}

