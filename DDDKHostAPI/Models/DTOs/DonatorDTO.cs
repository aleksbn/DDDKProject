using DDDKHostAPI.Models.Data;
using System.ComponentModel.DataAnnotations.Schema;

namespace DDDKHostAPI.Models.DTOs
{
    public class CreateDonatorDTO: Person
    {
        public int BloodTypeId { get; set; }
        public int PreviousDonations { get; set; }
    }

    public class DonatorDTO: CreateDonatorDTO
    {
        public int Id { get; set; }
        public IList<DonationDTO> Donations { get; set; }
        public BloodTypeDTO BloodType { get; set; }
    }
}
