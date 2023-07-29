using DDDKHostAPI.Models.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DDDKHostAPI.Configurations
{
    //4.3.1 Za svaku tabelu iz baze podataka unosimo podatke preko ove klase prilikom prvog startovanja
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
    //2.2.3 Pravimo klasu i metodu za konfigurisanje svake od tabela sa podacima
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
                },
                new Location
                {
                    Id = 4,
                    Name = "Bijeljina - Vuk Karadzic skola",
                    Description = "OŠ Vuk Karadžić"
                },
                new Location
                {
                    Id = 5,
                    Name = "Dvorovi - škola",
                    Description = "OŠ Sveti Sava"
                },
                new Location
                {
                    Id = 6,
                    Name = "Velika Obarska",
                    Description = "Dom Omladine Velika Obarska"
                },
                new Location
                {
                    Id = 7,
                    Name = "Batković",
                    Description = "Sala Osnovne škole"
                },
                new Location
                {
                    Id = 8,
                    Name = "Branjevo",
                    Description = "Ambulanta Branjevo"
                },
                new Location
                {
                    Id = 9,
                    Name = "Patkovača",
                    Description = "OŠ Jovan Dučić Patkovača"
                },
                new Location
                {
                    Id = 10,
                    Name = "Dvorovi - Banja",
                    Description = "Banja Dvorovi"
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
            Random r = new Random();
            Donation[] allDonations = new Donation[200];
            for(int i=0; i<200; i++)
            {
                allDonations[i] = new Donation
                {
                    Id = i + 1,
                    DonatorId = r.Next(1, 31),
                    DonationEventId = r.Next(1, 21)
                };
            }
            builder.HasData(allDonations);
        }
    }
    public class DonationEventConfiguration : IEntityTypeConfiguration<DonationEvent>
    {
        private DonationEvent[] sveAkcije = new DonationEvent[20];
        Random r = new Random();
        
        public void Configure(EntityTypeBuilder<DonationEvent> builder)
        {
            for (int i = 0; i < 20; i++)
            {
                sveAkcije[i] = new DonationEvent
                {
                    Id = i + 1,
                    LocationId = r.Next(1, 11),
                    EventDate = new DateTime(r.Next(2015, 2022), r.Next(1, 13), r.Next(1, 29)),
                    Description = "Akcija dobrovoljnog darovanja krvi br. " + i
                };
            }
            builder.HasData(sveAkcije);
        }
    }
    public class DonatorConfiguration : IEntityTypeConfiguration<Donator>
    {
        Random r = new Random();
        public string[] imena = new string[]
        {
            "Aleksandar", "Petar", "Ivana", "Mitar", "Bojan", "Slavica", "Mirko", "Dejan", "Zeljka", "Nikola", "Natasa", "Nevena", "Jovana", "Aleksandra", "Ivan", "Nemanja", "Nikolina", "Uros",
            "Slavko", "Marica", "Marija", "Marko", "Sandra", "Neven", "Miroslav"
        };
        public string[] prezimena = new string[]
        {
            "Matic", "Ilic", "Jovic", "Petrovic", "Becic", "Mitrovic", "Jankovic", "Jokanovic", "Aleksic", "Tanaskovic", "Popovic", "Ivkovic", "Lalic", "Rodic", "Milovanovic", "Bojic", "Markovic", 
            "Simic", "Djordjevic", "Djurickovic", "Stojkovic", "Tadic", "Stevanovic", "Stevic", "Stanic"
        };
        public string[] ulice = new string[]
        {
            "Petra Kocica", "Sime Matavulja", "Ive Andrica", "Svetog Save", "Nikole Tesle", "Jovana Ducica", "Gavrila Principa", "Dusana Baranina", "Mihajla Pupina", "Patrijarha Pavla", 
            "Danila Kisa", "Dusana Silnog", "Kralja Petra I Karadjordjevica", "Dinastije Obrenovic", "Masarikova", "Svetozara Markovica", "Mihaila Petrovica Alasa"
        };
        public Donator[] sviDonatori = new Donator[30];
        private string generisanoIme;
        private string generisanoPrezime;
        private string generisaniEmail;
        private DateTime generisaniDatumRodjenja;
        private string generisanaAdresa;
        private string generisaniBrojTelefona;
        public void Configure(EntityTypeBuilder<Donator> builder)
        {
            for (int i = 0; i < 30; i++)
            {
                generisanoIme = imena[r.Next(0, imena.Length - 1)];
                generisanoPrezime = prezimena[r.Next(0, prezimena.Length - 1)];
                generisaniEmail = generisanoIme + generisanoPrezime + r.Next() + "@gmail.com";
                generisaniDatumRodjenja = new DateTime(r.Next(1950, 2000), r.Next(1, 13), r.Next(1, 29));
                generisanaAdresa = ulice[r.Next(0, ulice.Length - 1)] + " " + r.Next(1, 201);
                generisaniBrojTelefona = "065/" + r.Next(100, 1000) + "-" + r.Next(100, 1000);
                sviDonatori[i] = new Donator
                {
                    Id = i + 1,
                    FirstName = generisanoIme,
                    LastName = generisanoPrezime,
                    Email = generisaniEmail,
                    BirthDate = generisaniDatumRodjenja,
                    Address = generisanaAdresa,
                    PhoneNumber = generisaniBrojTelefona,
                    BloodTypeId = r.Next(1,9),
                    PreviousDonations = r.Next(1, 21)
                };
            }
            builder.HasData(sviDonatori);
        }
    }
}
