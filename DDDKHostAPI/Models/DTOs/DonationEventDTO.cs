namespace DDDKHostAPI.Models.DTOs
{
    public class CreateDonationEventDTO
    {
        
        public DateTime EventDate { get; set; }
        public int LocationId { get; set; }
        public string Description { get; set; }
    }

    public class DonationEventDTO: CreateDonationEventDTO
    {
        public int Id { get; set; }
        public LocationDTO Location { get; set; }
    }

    public class UpdateDonationEventDTO: DonationEventDTO
    {

    }
}
