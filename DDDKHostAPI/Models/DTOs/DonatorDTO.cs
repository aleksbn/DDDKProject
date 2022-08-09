namespace DDDKHostAPI.Models.DTOs
{
    public class CreateDonatorDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public int PreviousDonations { get; set; }
    }

    public class DonatorDTO: CreateDonatorDTO
    {
        public int Id { get; set; }
        public IList<DonationDTO> Donations { get; set; }
    }
}
