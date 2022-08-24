using AutoMapper;
using DDDKHostAPI.Models.Data;
using DDDKHostAPI.Models.DTOs;
using Microsoft.AspNetCore.Identity;

namespace DDDKHostAPI.Configurations
{
    public class MapperInitializer: Profile
    {
        public MapperInitializer()
        {
            CreateMap<BloodType, BloodTypeDTO>().ReverseMap();
            CreateMap<Donator, DonatorDTO>().ReverseMap();
            CreateMap<Donation, DonationDTO>().ReverseMap();
            CreateMap<Donation, CreateDonationDTO>().ReverseMap();
            CreateMap<DonationEvent, DonationEventDTO>().ReverseMap();
            CreateMap<Location, LocationDTO>().ReverseMap();
            CreateMap<Donator, CreateDonatorDTO>().ReverseMap();
            CreateMap<Donation, CreateDonationDTO>().ReverseMap();
            CreateMap<DonationEvent, CreateDonationEventDTO>().ReverseMap();
            CreateMap<Location, CreateLocationDTO>().ReverseMap();
            CreateMap<IdentityUser, RegisterDTO>().ReverseMap();
        }
    }
}
