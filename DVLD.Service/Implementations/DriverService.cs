using DVLD.Data.Entities;
using DVLD.Infrastructure.Abstracts;
using DVLD.Service.Abstracts;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace DVLD.Service.Implementations
{
    public class DriverService : IDriverService
    {
        private readonly IDriverRepository _DriverRepository;

        public DriverService(IDriverRepository DriverRepository)
        {
            _DriverRepository=DriverRepository;
        }

        public async Task<string> AddAsync(Driver Driver)
        {
            await _DriverRepository.AddAsync(Driver);
            return "Success";
        }

        public async Task<string> DeleteAsync(Driver Driver)
        {
            var trans = _DriverRepository.BeginTransaction();
            try
            {
                await _DriverRepository.DeleteAsync(Driver);
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

        public async Task<string> EditAsync(Driver Driver)
        {
            await _DriverRepository.UpdateAsync(Driver);
            return "Success";
        }



        public async Task<Driver> GetByIDAsync(int id)
        {
            var Driver = await _DriverRepository.GetByIdAsync(id);
            return Driver;
        }

        public async Task<Driver> GetDriverByIDWithIncludeAsync(int id)
        {
            var Driver = _DriverRepository.GetTableNoTracking()
                                         .Include(x => x.Drivers)
                                         .Where(x => x.DriverId.Equals(id))
                                         .FirstOrDefault();
            return Driver;
        }

        public IQueryable<Driver> GetDriversByOrderIDQuerable(int DID)
        {
            throw new NotImplementedException();
        }

        /* public IQueryable<Driver> GetDriversByDriverIDQuerable(int DID)
         {
             return _DriverRepository.GetTableNoTracking().Where(x => x.Drivers.DriverId.Equals(DID)).AsQueryable();
         }*/

        public async Task<List<Driver>> GetDriversListAsync()
        {
            return await _DriverRepository.GetTableNoTracking().Include(x => x.Drivers)
                                           .ToListAsync();
        }

        public IQueryable<Driver> GetDriversQuerable()
        {
            return _DriverRepository.GetTableNoTracking().Include(x => x.Drivers).AsQueryable();
        }





    }
}
