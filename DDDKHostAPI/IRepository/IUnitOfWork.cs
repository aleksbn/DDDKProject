using DDDKHostAPI.Models.Data;

namespace DDDKHostAPI.IRepository
{
    public interface IUnitOfWork: IDisposable
    {
        IGenericRepository<BloodType> BloodTypes { get; }
        IGenericRepository<Donation> Donations { get; }
        IGenericRepository<DonationEvent> DonationEvents { get; }
        IGenericRepository<Donator> Donators { get; }
        IGenericRepository<Location> Locations { get; }
        Task Save();
    }
}
