using System.Collections.Generic;
using madden.Models;
using madden.Services;

namespace madden.Data
{
    public class PlayerRepo : IPlayerRepo
    {
        public JsonFilePlayersService PlayersService { get; }
        private readonly PlayerDbContext _context;

        public PlayerRepo(PlayerDbContext context,
                JsonFilePlayersService playerService)
        {
            _context = context;
            this.PlayersService = playerService;
            this.generatePlayers();
        }

        private void generatePlayers()
        {
                var players = PlayersService.GetPlayers();
                _context.Players.AddRange(players);
        }

        public IEnumerable<Player> GetAllPlayers()
        {
                return _context.Players.ToList();
        }

        public Player GetPlayerById(int id)
        {
            return _context.Players.FirstOrDefault(p => p.Id == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

    }
}