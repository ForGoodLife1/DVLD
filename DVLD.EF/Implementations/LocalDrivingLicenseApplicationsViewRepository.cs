using DVLD.Data.Entities;
using DVLD.Infarastructure.InfrastructureBases;
using DVLD.Infrastructure.Abstracts;
using DVLD.Infrastructure.DvldDbContext;
using Microsoft.EntityFrameworkCore;

namespace DVLD.Infrastructure.Implementations
{
    public class LocalDrivingLicenseApplicationsViewRepository : GenericRepositoryAsync<LocalDrivingLicenseApplicationsView>, ILocalDrivingLicenseApplicationsViewRepository
    {
        private DbSet<LocalDrivingLicenseApplicationsView> _LocalDrivingLicenseApplicationsViews;
        public LocalDrivingLicenseApplicationsViewRepository(DvldContext dbContext) : base(dbContext)
        {
            _LocalDrivingLicenseApplicationsViews=dbContext.Set<LocalDrivingLicenseApplicationsView>();
        }



    }
}
