using Microsoft.EntityFrameworkCore;

namespace DataLayer
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public ApplicationDbContext() : base()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=.; database=FlickerProjectDB; Integrated Security=True;");
        }

        public DbSet<Location> Locations { get; set; }
        public DbSet<Landmark> Landmarks { get; set; }
        public DbSet<UserLocation> UserLocations { get; set; }
        public DbSet<User> Users { get; set; }

    }
}
