using System.ComponentModel.DataAnnotations.Schema;

namespace DDDKHostAPI.Models.Data
{
    public class Donator
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }

        [ForeignKey(nameof(BloodType))]
        public int BloodTypeId { get; set; }
        public BloodType BloodType { get; set; }

        public int PreviousDonations { get; set; }

        public virtual IList<Donation> Donations { get; set; }
    }
}
