using DVLD.Data.Entities;
using DVLD.Infarastructure.InfrastructureBases;
using DVLD.Infrastructure.Abstracts;
using DVLD.Infrastructure.DvldDbContext;
using Microsoft.EntityFrameworkCore;

namespace DVLD.Infrastructure.Implementations
{
    public class DriverRepository : GenericRepositoryAsync<Driver>, IDriverRepository
    {
        private DbSet<Driver> _Drivers;
        public DriverRepository(DvldContext dbContext):base(dbContext)
        {
            _Drivers=dbContext.Set<Driver>();
        }

        public async Task<List<Driver>> GetDriversListAsync()
        {
            return await _Drivers.ToListAsync();

        }
          
    }
}
