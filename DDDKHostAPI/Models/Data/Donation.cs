using System.ComponentModel.DataAnnotations.Schema;

namespace DDDKHostAPI.Models.Data
{
    public class Donation
    {
        public int Id { get; set; }

        [ForeignKey(nameof(Donator))]
        public int DonatorId { get; set; }
        public Donator Donator { get; set; }

        [ForeignKey(nameof(DonationEvent))]
        public int DonationEventId { get; set; }
        public DonationEvent DonationEvent { get; set; }
    }
}
