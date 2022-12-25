using DDDKHostAPI.Configurations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DDDKHostAPI.Models.Data
{
    public class DatabaseContext : IdentityDbContext<IdentityUser>
    {
        //2.1.5	Popunjavamo DatabaseContext klasu (konstruktor i DbSets)
        public DatabaseContext(DbContextOptions options) : base(options)
        { }

        public DbSet<Location> Locations { get; set; }
        public DbSet<DonationEvent> DonationEvents { get; set; }
        public DbSet<Donation> Donations { get; set; }
        public DbSet<BloodType> BloodTypes { get; set; }
        public DbSet<Donator> Donators { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //2.2.1
            base.OnModelCreating(builder);
            //4.3.3 Pozivanje konstruktora klasa koje ce unijeti random podatke
            builder.ApplyConfiguration(new RoleConfiguration());
            builder.ApplyConfiguration(new BloodTypeConfiguration());
            builder.ApplyConfiguration(new LocationConfiguration());
            builder.ApplyConfiguration(new DonationEventConfiguration());
            builder.ApplyConfiguration(new DonatorConfiguration());
            builder.ApplyConfiguration(new DonationConfiguration());
        }
    }
}
