using DVLD.Data.Entities;

namespace DVLD.Service.Abstracts
{
    public interface ILocalDrivingLicenseApplicationsViewService
    {
        public Task<List<LocalDrivingLicenseApplicationsView>> GetLocalDrivingLicenseApplicationsViewsListAsync();
        // public Task<LocalDrivingLicenseApplicationsView> GetLocalDrivingLicenseApplicationsViewByIDWithIncludeAsync(int id);
        public Task<LocalDrivingLicenseApplicationsView> GetByIDAsync(int id);
        public Task<string> AddAsync(LocalDrivingLicenseApplicationsView LocalDrivingLicenseApplicationsView);

        public Task<string> EditAsync(LocalDrivingLicenseApplicationsView LocalDrivingLicenseApplicationsView);
        public Task<string> DeleteAsync(LocalDrivingLicenseApplicationsView LocalDrivingLicenseApplicationsView);
        public IQueryable<LocalDrivingLicenseApplicationsView> GetLocalDrivingLicenseApplicationsViewsQuerable();
        public IQueryable<LocalDrivingLicenseApplicationsView> GetLocalDrivingLicenseApplicationsViewsByOrderIDQuerable(int DID);
    }
}

