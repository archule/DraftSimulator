using Microsoft.EntityFrameworkCore;

namespace madden.Models
{
    public class PlayerDbContext : DbContext
    {
        public PlayerDbContext(DbContextOptions<PlayerDbContext> options) : base(options)
        {
        }

        public DbSet<Player> Players { get; set; }
        public DbSet<Team> Teams { get; set; }

        public DbSet<Room> Rooms { get; set; }
    }
}