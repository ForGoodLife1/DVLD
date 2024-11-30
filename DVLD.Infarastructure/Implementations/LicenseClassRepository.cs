using DVLD.Data.Entities;
using DVLD.Infarastructure.InfrastructureBases;
using DVLD.Infrastructure.Abstracts;
using DVLD.Infrastructure.DvldDbContext;
using Microsoft.EntityFrameworkCore;

namespace DVLD.Infrastructure.Implementations
{
    public class LicenseClassRepository : GenericRepositoryAsync<LicenseClass>, ILicenseClassRepository
    {
        private DbSet<LicenseClass> _LicenseClasss;
        public LicenseClassRepository(DvldContext dbContext) : base(dbContext)
        {
            _LicenseClasss=dbContext.Set<LicenseClass>();
        }



    }
}
