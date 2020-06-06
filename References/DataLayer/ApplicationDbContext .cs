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
            optionsBuilder.UseSqlServer(@"Data Source=.; database=QuarantineMeDB; Integrated Security=True;");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Patient>().HasOne(p => p.Enum_NationalityCountry)
            //             .WithOne(k => k.Key);
                //HasMany<Enum_Country>().WithOne().OnDelete(DeleteBehavior.Cascade);
           // modelBuilder.Entity<Patient>().
                       // .HasOne<Enum_Country>().
        }

        public DbSet<Enum_Organization> Enum_Organizations { get; set; }
        public DbSet<Enum_Department> Enum_Departments { get; set; }
        public DbSet<Enum_Role> Enum_Roles { get; set; }
        public DbSet<Enum_IdType> Enum_IdTypes { get; set; }
        public DbSet<Enum_Province> Enum_Provinces { get; set; }
        public DbSet<Enum_Country> Enum_Countries { get; set; }
        public DbSet<Enum_Town> Enum_Towns { get; set; }
        public DbSet<Enum_PortOfEntry> Enum_PortOfEntries { get; set; }
        public DbSet<Enum_CovidStatus> Enum_CovidStatuses { get; set; }
        public DbSet<Enum_HIVStatus> Enum_HIVStatuses { get; set; }
        public DbSet<Enum_PatientStatus> Enum_PatientStatuses { get; set; }
        public DbSet<Enum_Sex> Enum_Sexes { get; set; }
        //non-enums
        //public DbSet<ProvinceTown> ProvinceTowns { get; set; }
        public DbSet<TestCentre> TestCentres { get; set; }
        public DbSet<User> Users { get; set; }
        //public DbSet<UserRole> UserRoles { get; set; }
        // change here patient is one to one with the following tables
        public DbSet<Patient> Patients { get; set; }
        public DbSet<NextOfKin> NextOfKins { get; set; }
        public DbSet<Centre> Centres { get; set; }
        public DbSet<PortOfEntry> PortOfEntries { get; set; }
        public DbSet<CaptureHistory> CaptureHistories { get; set; }
        public DbSet<CentreHistory> CentreHistories { get; set; }

    }
}
