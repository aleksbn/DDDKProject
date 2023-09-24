using System.ComponentModel.DataAnnotations;

namespace DDDKHostAPI.Models.DTOs
{
    public class CreateDonationEventDTO
    {
        [Required]
        public DateTime EventDate { get; set; }
        [Required]
        public int LocationId { get; set; }
        public string Description { get; set; }
    }

    public class DonationEventDTO: CreateDonationEventDTO
    {
        public int Id { get; set; }
        public string LocationName { get; set; }
    }

    public class UpdateDonationEventDTO: DonationEventDTO
    {

    }
}
