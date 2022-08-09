using System.ComponentModel.DataAnnotations.Schema;

namespace DDDKHostAPI.Models.Data
{
    public class DonationEvent
    {
        public int Id { get; set; }
        public DateTime EventDate { get; set; }

        [ForeignKey(nameof(Location))]
        public int LocationId { get; set; }
        public Location Location { get; set; }

        public string Description { get; set; }
    }
}
