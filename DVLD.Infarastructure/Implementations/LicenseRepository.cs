using DVLD.Data.Entities;
using DVLD.Infarastructure.InfrastructureBases;
using DVLD.Infrastructure.Abstracts;
using DVLD.Infrastructure.DvldDbContext;
using Microsoft.EntityFrameworkCore;

namespace DVLD.Infrastructure.Implementations
{
    public class LicenseRepository : GenericRepositoryAsync<License>, ILicenseRepository
    {
        private DbSet<License> _Licenses;
        public LicenseRepository(DvldContext dbContext) : base(dbContext)
        {
            _Licenses=dbContext.Set<License>();
        }



    }
}
