using System.Collections.Generic;
using madden.Models;
using madden.Services;

namespace madden.Data
{
    public class TeamRepo : ITeamRepo
    {
        public JsonFilePlayersService TeamsService { get; }
        private readonly PlayerDbContext _context;

        public TeamRepo(PlayerDbContext context,
                JsonFilePlayersService teamService)
        {
            _context = context;
            this.TeamsService = teamService;
            this.generateTeams();

        }

        private void generateTeams()
        {
            
            var teams = TeamsService.GetTeams();

            _context.Teams.AddRange(teams);
            _context.SaveChanges();


        }

        public IEnumerable<Team> GetAllTeams()
        {

            var teams = _context.Teams.ToList();


            return teams;
        }


        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

    }  
}