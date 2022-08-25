using System.ComponentModel.DataAnnotations;

namespace DDDKHostAPI.Models.DTOs
{
    public class CreateLocationDTO
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class LocationDTO: CreateLocationDTO
    {
        public int Id { get; set; }
        public virtual IList<DonationEventDTO> DonationEvents { get; set; }
    }

    public class UpdateLocationDTO: CreateLocationDTO
    {
        
    }
}
