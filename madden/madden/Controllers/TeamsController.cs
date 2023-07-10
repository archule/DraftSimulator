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
    public class TeamsController : Controller
    {


        private readonly ITeamRepo _repository;
        private readonly IMapper _mapper;

        public TeamsController(ITeamRepo repo, IMapper mapper)
        {
            _repository = repo;
            _mapper = mapper;
            
        }

        [HttpGet]
        public ActionResult<IEnumerable<PlayerReadDto>> Get()
        {
            var teams = _repository.GetAllTeams();
            Console.WriteLine("Action Result");

            return Ok(_mapper.Map<IEnumerable<TeamReadDto>>(teams));
            //return View(players);
        }
    }
}

