using DVLD.Data.Entities;

namespace DVLD.Service.Abstracts
{
    public interface ILocalDrivingLicenseApplicationService
    {
        public Task<List<LocalDrivingLicenseApplication>> GetLocalDrivingLicenseApplicationsListAsync();
        // public Task<LocalDrivingLicenseApplication> GetLocalDrivingLicenseApplicationByIDWithIncludeAsync(int id);
        public Task<LocalDrivingLicenseApplication> GetByIDAsync(int id);
        public Task<string> AddAsync(LocalDrivingLicenseApplication LocalDrivingLicenseApplication);

        public Task<string> EditAsync(LocalDrivingLicenseApplication LocalDrivingLicenseApplication);
        public Task<string> DeleteAsync(LocalDrivingLicenseApplication LocalDrivingLicenseApplication);
        public IQueryable<LocalDrivingLicenseApplication> GetLocalDrivingLicenseApplicationsQuerable();
        public IQueryable<LocalDrivingLicenseApplication> GetLocalDrivingLicenseApplicationsByOrderIDQuerable(int DID);
    }
}

