using DDDKHostAPI.Configurations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DDDKHostAPI.Models.Data
{
    //4.1.1	Mijenjamo klasu koja se nasljeđuje, iz DbContext u IdentityDbContext
    public class DatabaseContext : IdentityDbContext<IdentityUser> //Ovdje se prvobitno nasljedjuje klasa DbContext, ali se kasnije, zbog logovanja, dodaje IdentityDbContext
    {
        //2.1.5	Popunjavamo DatabaseContext klasu (konstruktor i DbSets)
        public DatabaseContext(DbContextOptions options) : base(options)
        { }

        public DbSet<Location> Locations { get; set; }
        public DbSet<DonationEvent> DonationEvents { get; set; }
        public DbSet<Donation> Donations { get; set; }
        public DbSet<BloodType> BloodTypes { get; set; }
        public DbSet<Donator> Donators { get; set; }

        //2.2.2 Dodajemo metodu za kreiranje podataka prilikom startovanja aplikacije prvi put
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            //4.3.2 Pozivanje konstruktora klasa koje ce unijeti random podatke
            builder.ApplyConfiguration(new RoleConfiguration());
            //2.2.4 Pozivamo svaku od klasa i metoda za popunjavanje tabele
            builder.ApplyConfiguration(new BloodTypeConfiguration());
            builder.ApplyConfiguration(new LocationConfiguration());
            builder.ApplyConfiguration(new DonationEventConfiguration());
            builder.ApplyConfiguration(new DonatorConfiguration());
            builder.ApplyConfiguration(new DonationConfiguration());
        }
    }
}
