using DVLD.Data.Entities;
using DVLD.Infarastructure.InfrastructureBases;
using DVLD.Infrastructure.Abstracts;
using DVLD.Infrastructure.DvldDbContext;
using Microsoft.EntityFrameworkCore;

namespace DVLD.Infrastructure.Implementations
{
    public class LocalDrivingLicenseApplicationRepository : GenericRepositoryAsync<LocalDrivingLicenseApplication>, ILocalDrivingLicenseApplicationRepository
    {
        private DbSet<LocalDrivingLicenseApplication> _LocalDrivingLicenseApplications;
        public LocalDrivingLicenseApplicationRepository(DvldContext dbContext) : base(dbContext)
        {
            _LocalDrivingLicenseApplications=dbContext.Set<LocalDrivingLicenseApplication>();
        }



    }
}
