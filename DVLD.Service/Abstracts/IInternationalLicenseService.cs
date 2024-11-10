using DVLD.Data.Entities;

namespace DVLD.Service.Abstracts
{
    public interface IInternationalLicenseService
    {
        public Task<List<InternationalLicense>> GetInternationalLicensesListAsync();
        // public Task<InternationalLicense> GetInternationalLicenseByIDWithIncludeAsync(int id);
        public Task<InternationalLicense> GetByIDAsync(int id);
        public Task<string> AddAsync(InternationalLicense InternationalLicense);

        public Task<string> EditAsync(InternationalLicense InternationalLicense);
        public Task<string> DeleteAsync(InternationalLicense InternationalLicense);
        public IQueryable<InternationalLicense> GetInternationalLicensesQuerable();
        public IQueryable<InternationalLicense> GetInternationalLicensesByOrderIDQuerable(int DID);
    }
}

