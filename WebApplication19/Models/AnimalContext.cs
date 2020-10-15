using Microsoft.EntityFrameworkCore;

namespace WebApplication19.Models
{
    public class AnimalContext : DbContext
    {
        public DbSet<Animal> Animals { get; set; }
        public DbSet<Order> Orders { get; set; }

        public AnimalContext(DbContextOptions<AnimalContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
