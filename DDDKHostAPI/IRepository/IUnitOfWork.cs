using DDDKHostAPI.Models.Data;

namespace DDDKHostAPI.IRepository
{
    public interface IUnitOfWork: IDisposable
    {
        //2.3.7 Pripremamo polje za svaku tabelu iz baze
        IGenericRepository<BloodType> BloodTypes { get; }
        IGenericRepository<Donation> Donations { get; }
        IGenericRepository<DonationEvent> DonationEvents { get; }
        IGenericRepository<Donator> Donators { get; }
        IGenericRepository<Location> Locations { get; }
        Task Save();
    }
}
