using DVLD.Data.Entities;
using DVLD.Infarastructure.InfrastructureBases;
using DVLD.Infrastructure.Abstracts;
using DVLD.Infrastructure.DvldDbContext;
using Microsoft.EntityFrameworkCore;

namespace DVLD.Infrastructure.Implementations
{
    public class ApplicationRepository : GenericRepositoryAsync<Application>, IApplicationRepository
    {
        private DbSet<Application> _applications;
        public ApplicationRepository(DvldContext dbContext) : base(dbContext)
        {
            _applications=dbContext.Set<Application>();
        }

        public async Task<List<Application>> GetApplicationsListAsync()
        {
            return await _applications.Include(x => x.ApplicationTypeId).ToListAsync();

        }

    }
}
