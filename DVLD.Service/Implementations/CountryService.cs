using DVLD.Data.Entities;
using DVLD.Infrastructure.Abstracts;
using DVLD.Service.Abstracts;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace DVLD.Service.Implementations
{
    public class CountryService : ICountryService
    {
        private readonly ICountryRepository _CountryRepository;

        public CountryService(ICountryRepository CountryRepository)
        {
            _CountryRepository=CountryRepository;
        }

        public async Task<string> AddAsync(Country Country)
        {
            await _CountryRepository.AddAsync(Country);
            return "Success";
        }

        public async Task<string> DeleteAsync(Country Country)
        {
            var trans = _CountryRepository.BeginTransaction();
            try
            {
                await _CountryRepository.DeleteAsync(Country);
                await trans.CommitAsync();
                return "Success";
            }
            catch (Exception ex)
            {
                await trans.RollbackAsync();
                Log.Error(ex.Message);
                return "Falied";
            }
        }

        public async Task<string> EditAsync(Country Country)
        {
            await _CountryRepository.UpdateAsync(Country);
            return "Success";
        }



        public async Task<Country> GetByIDAsync(int id)
        {
            var Country = await _CountryRepository.GetByIdAsync(id);
            return Country;
        }

        public async Task<Country> GetCountryByIDWithIncludeAsync(int id)
        {
            var Country = _CountryRepository.GetTableNoTracking()
                                         .Include(x => x.Drivers)
                                         .Where(x => x.CountryId.Equals(id))
                                         .FirstOrDefault();
            return Country;
        }

        public IQueryable<Country> GetCountrysByOrderIDQuerable(int DID)
        {
            throw new NotImplementedException();
        }

        /* public IQueryable<Country> GetCountrysByDriverIDQuerable(int DID)
         {
             return _CountryRepository.GetTableNoTracking().Where(x => x.Drivers.DriverId.Equals(DID)).AsQueryable();
         }*/

        public async Task<List<Country>> GetCountrysListAsync()
        {
            return await _CountryRepository.GetTableNoTracking().Include(x => x.Drivers)
                                           .ToListAsync();
        }

        public IQueryable<Country> GetCountrysQuerable()
        {
            return _CountryRepository.GetTableNoTracking().Include(x => x.Drivers).AsQueryable();
        }





    }
}
