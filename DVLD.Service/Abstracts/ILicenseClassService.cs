using DVLD.Data.Entities;

namespace DVLD.Service.Abstracts
{
    public interface ILicenseClassService
    {
        public Task<List<LicenseClass>> GetLicenseClasssListAsync();
        // public Task<LicenseClass> GetLicenseClassByIDWithIncludeAsync(int id);
        public Task<LicenseClass> GetByIDAsync(int id);
        public Task<string> AddAsync(LicenseClass LicenseClass);

        public Task<string> EditAsync(LicenseClass LicenseClass);
        public Task<string> DeleteAsync(LicenseClass LicenseClass);
        public IQueryable<LicenseClass> GetLicenseClasssQuerable();
        public IQueryable<LicenseClass> GetLicenseClasssByOrderIDQuerable(int DID);
        // public IQueryable<LicenseClass> FilterLicenseClassPaginatedQuerable(LicenseClassOrderingEnum orderingEnum, string search);
    }
}

