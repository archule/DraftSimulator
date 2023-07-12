
namespace madden.Models;
using Microsoft.EntityFrameworkCore;
public class FireDbContext : DbContext
{
    public FireDbContext(DbContextOptions<FireDbContext> options) : base(options) { }

    // Define your entity sets
}
