using System.ComponentModel.DataAnnotations;

namespace DDDKHostAPI.Models.DTOs
{
    public class CreateDonationDTO
    {
        [Required]
        public int DonatorId { get; set; }
        [Required]
        public int DonationEventId { get; set; }
    }

    public class DonationDTO: CreateDonationDTO
    {
        [Required]
        public int Id { get; set; }
    }

    public class UpdateDonationDTO: DonationDTO
    {

    }
}
