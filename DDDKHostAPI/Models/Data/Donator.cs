using System.ComponentModel.DataAnnotations.Schema;

namespace DDDKHostAPI.Models.Data
{
    public class Donator: Person
    {
        [ForeignKey(nameof(BloodType))]
        public int BloodTypeId { get; set; }
        public BloodType BloodType { get; set; }

        public int PreviousDonations { get; set; }

        public virtual IList<Donation> Donations { get; set; }
    }
}
