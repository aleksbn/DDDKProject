using System.ComponentModel.DataAnnotations.Schema;

namespace DDDKHostAPI.Models.Data
{
    public class Location
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual IList<DonationEvent> DonationEvents { get; set; }
    }
}
