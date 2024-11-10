using DVLD.Data.Entities;

namespace DVLD.Service.Abstracts
{
    public interface ILicenseService
    {
        public Task<List<License>> GetLicensesListAsync();
        // public Task<License> GetLicenseByIDWithIncludeAsync(int id);
        public Task<License> GetByIDAsync(int id);
        public Task<string> AddAsync(License License);

        public Task<string> EditAsync(License License);
        public Task<string> DeleteAsync(License License);
        public IQueryable<License> GetLicensesQuerable();
        public IQueryable<License> GetLicensesByOrderIDQuerable(int DID);
    }
}

