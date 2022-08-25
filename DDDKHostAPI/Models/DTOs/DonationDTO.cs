using System.ComponentModel.DataAnnotations;

namespace DDDKHostAPI.Models.DTOs
{
    public class CreateDonationDTO
    {
        [Required]
        public int DonatorId { get; set; }
        public int DonationEventId { get; set; }
    }

    public class DonationDTO: CreateDonationDTO
    {
        public int Id { get; set; }
        public DonatorDTO Donator { get; set; }
        public DonationEventDTO DonationEvent { get; set; }
    }

    public class UpdateDonationDTO: DonationDTO
    {

    }
}
