using DDDKHostAPI.Models.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DDDKHostAPI.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                new IdentityRole
                {
                    Name = "Admin",
                    NormalizedName = "ADMINISTRATOR"
                },
                new IdentityRole
                {
                    Name = "Mod",
                    NormalizedName = "MODERATOR"
                });
        }
    }
    public class LocationConfiguration : IEntityTypeConfiguration<Location>
    {
        public void Configure(EntityTypeBuilder<Location> builder)
        {
            builder.HasData(
                new Location
                {
                    Id = 1,
                    Name = "Donje Crnjelovo",
                    Description = "Škola u Donjem Crnjelovu"
                },
                new Location
                {
                    Id = 2,
                    Name = "Magnojević",
                    Description = "Dom omladine"
                },
                new Location
                {
                    Id = 3,
                    Name = "Bijeljina - Dašnjica 1",
                    Description = "OŠ Knez Ivo od Semberije"
                }
                );
        }
    }
    public class BloodTypeConfiguration : IEntityTypeConfiguration<BloodType>
    {
        public void Configure(EntityTypeBuilder<BloodType> builder)
        {
            builder.HasData(
                new BloodType
                {
                    Id = 1,
                    Name = "A",
                    PhFactor = "+"
                },
                new BloodType
                {
                    Id = 2,
                    Name = "A",
                    PhFactor = "-"
                },
                new BloodType
                {
                    Id = 3,
                    Name = "B",
                    PhFactor = "+"
                },
                new BloodType
                {
                    Id = 4,
                    Name = "B",
                    PhFactor = "-"
                },
                new BloodType
                {
                    Id = 5,
                    Name = "AB",
                    PhFactor = "+"
                },
                new BloodType
                {
                    Id = 6,
                    Name = "AB",
                    PhFactor = "-"
                },
                new BloodType
                {
                    Id = 7,
                    Name = "0",
                    PhFactor = "+"
                },
                new BloodType
                {
                    Id = 8,
                    Name = "0",
                    PhFactor = "-"
                }
                );
        }
    }
    public class DonationConfiguration : IEntityTypeConfiguration<Donation>
    {
        public void Configure(EntityTypeBuilder<Donation> builder)
        {
            builder.HasData(
                new Donation
                {
                    Id = 1,
                    DonatorId = 3,
                    DonationEventId = 1
                },
                new Donation
                {
                    Id = 2,
                    DonatorId = 1,
                    DonationEventId = 1
                },
                new Donation
                {
                    Id = 3,
                    DonatorId = 1,
                    DonationEventId = 2
                },
                new Donation
                {
                    Id = 4,
                    DonatorId = 2,
                    DonationEventId = 1
                },
                new Donation
                {
                    Id = 5,
                    DonatorId = 2,
                    DonationEventId = 2
                }
                );
        }
    }
    public class DonationEventConfiguration : IEntityTypeConfiguration<DonationEvent>
    {
        public void Configure(EntityTypeBuilder<DonationEvent> builder)
        {
            builder.HasData(
                new DonationEvent
                {
                    Id = 1,
                    EventDate = new DateTime(2021, 5, 22),
                    LocationId = 2,
                    Description = "Akcija dobrovoljnog darovanja krvi u D. Crnjelovu 2021"
                },
                new DonationEvent
                {
                    Id = 2,
                    EventDate = new DateTime(2022, 1, 3),
                    LocationId = 3,
                    Description = "Akcija dobrovoljnog darovanja krvi u Magnojevicu 2022"
                });
        }
    }
    public class DonatorConfiguration : IEntityTypeConfiguration<Donator>
    {
        public void Configure(EntityTypeBuilder<Donator> builder)
        {
            builder.HasData(
                new Donator
                {
                    ID = 1,
                    FirstName = "Aleksandar",
                    LastName = "Matic",
                    Email = "aleksbn417@gmail.com",
                    BirthDate = new DateTime(1986, 12, 9),
                    Address = "Dusana Baranina 1/C/10, Bijeljina",
                    PhoneNumber = "065/417-302",
                    BloodTypeId = 7,
                    PreviousDonations = 5
                },
                new Donator
                {
                    ID = 2,
                    FirstName = "Petar",
                    LastName = "Peric",
                    Email = "pperic@gmail.com",
                    BirthDate = new DateTime(1958, 7, 22),
                    Address = "Vrulja bb, Donje Crnjelovo",
                    PhoneNumber = "065/257-417",
                    BloodTypeId = 5,
                    PreviousDonations = 89
                },
                new Donator
                {
                    ID = 3,
                    FirstName = "Ivana",
                    LastName = "Stevic",
                    Email = "ivanas@gmail.com",
                    BirthDate = new DateTime(2000, 1, 19),
                    Address = "Gavrila Principa 14/22, Bijeljina",
                    PhoneNumber = "065/741-956",
                    BloodTypeId = 5,
                    PreviousDonations = 1
                },
                new Donator
                {
                    ID = 4,
                    FirstName = "Maja",
                    LastName = "Gobeljic",
                    Email = "majag@gmail.com",
                    BirthDate = new DateTime(2001, 4, 10),
                    Address = "Mala Obarska BB",
                    PhoneNumber = "065/778-332",
                    BloodTypeId = 6,
                    PreviousDonations = 2
                }
                );
        }
    }
}
