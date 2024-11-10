using DVLD.Data.Entities;
using DVLD.Infarastructure.InfrastructureBases;
using DVLD.Infrastructure.Abstracts;
using DVLD.Infrastructure.DvldDbContext;
using Microsoft.EntityFrameworkCore;

namespace DVLD.Infrastructure.Implementations
{
    public class InternationalLicenseRepository : GenericRepositoryAsync<InternationalLicense>, IInternationalLicenseRepository
    {
        private DbSet<InternationalLicense> _InternationalLicenses;
        public InternationalLicenseRepository(DvldContext dbContext) : base(dbContext)
        {
            _InternationalLicenses=dbContext.Set<InternationalLicense>();
        }



    }
}
