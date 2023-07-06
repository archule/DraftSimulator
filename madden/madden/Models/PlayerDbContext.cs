using Microsoft.EntityFrameworkCore;

namespace madden.Models
{
    public class PlayerDbContext : DbContext
    {
        public PlayerDbContext(DbContextOptions<PlayerDbContext> options) : base(options)
        {
        }

        public DbSet<Player> Players { get; set; }
    }
}