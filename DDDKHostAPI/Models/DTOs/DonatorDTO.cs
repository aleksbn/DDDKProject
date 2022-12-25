using DDDKHostAPI.Models.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DDDKHostAPI.Models.DTOs
{
    public class DonatorDTO
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
        [Required]
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        [Required]
        public int BloodTypeId { get; set; }
        public int PreviousDonations { get; set; } = 0;

        public IList<DonationDTO> Donations { get; set; }
    }

    public class CreateDonatorDTO: DonatorDTO
    {
        public int Id { get; set; }
    }

    public class UpdateDonatorDTO: DonatorDTO
    {

    }
}
