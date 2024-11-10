using DVLD.Data.Entities;

namespace DVLD.Service.Abstracts
{
    public interface ICountryService
    {
        public Task<List<Country>> GetCountrysListAsync();
        // public Task<Country> GetCountryByIDWithIncludeAsync(int id);
        public Task<Country> GetByIDAsync(int id);
        public Task<string> AddAsync(Country Country);

        public Task<string> EditAsync(Country Country);
        public Task<string> DeleteAsync(Country Country);
        public IQueryable<Country> GetCountrysQuerable();
        public IQueryable<Country> GetCountrysByOrderIDQuerable(int DID);
    }
}

