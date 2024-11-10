using DVLD.Data.Entities;

namespace DVLD.Service.Abstracts
{
    public interface IDriverService
    {
        public Task<List<Driver>> GetDriversListAsync();
        // public Task<Driver> GetDriverByIDWithIncludeAsync(int id);
        public Task<Driver> GetByIDAsync(int id);
        public Task<string> AddAsync(Driver Driver);

        public Task<string> EditAsync(Driver Driver);
        public Task<string> DeleteAsync(Driver Driver);
        public IQueryable<Driver> GetDriversQuerable();
        public IQueryable<Driver> GetDriversByOrderIDQuerable(int DID);
    }
}

