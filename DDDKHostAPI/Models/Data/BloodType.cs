namespace DDDKHostAPI.Models.Data
{
    public class BloodType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhFactor { get; set; }

        public virtual IList<Donator> Donators { get; set; }
    }
}
