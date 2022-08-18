using DDDKHostAPI.Configurations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DDDKHostAPI.Models.Data
{
    public class DatabaseContext : IdentityDbContext<IdentityUser>
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        { }

        public DbSet<Location> Locations { get; set; }
        public DbSet<DonationEvent> DonationEvents { get; set; }
        public DbSet<Donation> Donations { get; set; }
        public DbSet<BloodType> BloodTypes { get; set; }
        public DbSet<Donator> Donators { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new RoleConfiguration());
            builder.ApplyConfiguration(new BloodTypeConfiguration());
            builder.ApplyConfiguration(new LocationConfiguration());
            builder.ApplyConfiguration(new DonationEventConfiguration());
            builder.ApplyConfiguration(new DonatorConfiguration());
            builder.ApplyConfiguration(new DonationConfiguration());
        }
    }
}
