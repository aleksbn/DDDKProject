using DDDKHostAPI.IRepository;
using DDDKHostAPI.Models.Data;
using Microsoft.EntityFrameworkCore;

namespace DDDKHostAPI.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        //2.3.9 Postavljamo instancu DbContext klase za dependency injection
        private readonly DatabaseContext _dbContext;
        private IGenericRepository<BloodType> _bloodTypeRepository;
        private IGenericRepository<Donation> _donationRepository;
        private IGenericRepository<DonationEvent> _donationEventRepository;
        private IGenericRepository<Donator> _donatorRepository;
        private IGenericRepository<Location> _locationRepository;

        public UnitOfWork(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }
        //Ovaj dupli upitnik znaci "ako je null, uradi sljedece:"
        public IGenericRepository<BloodType> BloodTypes => _bloodTypeRepository ??= new GenericRepository<BloodType>(_dbContext);
        public IGenericRepository<Donation> Donations => _donationRepository ??= new GenericRepository<Donation>(_dbContext);
        public IGenericRepository<DonationEvent> DonationEvents => _donationEventRepository ??= new GenericRepository<DonationEvent>(_dbContext);
        public IGenericRepository<Donator> Donators => _donatorRepository ??= new GenericRepository<Donator>(_dbContext);
        public IGenericRepository<Location> Locations => _locationRepository ??= new GenericRepository<Location>(_dbContext);

        public void Dispose()
        {
            _dbContext.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task Save()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
