using DVLD.Data.Entities;
using DVLD.Infrastructure.Abstracts;
using DVLD.Service.Abstracts;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace DVLD.Service.Implementations
{
    public class LicenseClassService : ILicenseClassService
    {
        private readonly ILicenseClassRepository _LicenseClassRepository;

        public LicenseClassService(ILicenseClassRepository LicenseClassRepository)
        {
            _LicenseClassRepository=LicenseClassRepository;
        }

        public async Task<string> AddAsync(LicenseClass LicenseClass)
        {
            await _LicenseClassRepository.AddAsync(LicenseClass);
            return "Success";
        }

        public async Task<string> DeleteAsync(LicenseClass LicenseClass)
        {
            var trans = _LicenseClassRepository.BeginTransaction();
            try
            {
                await _LicenseClassRepository.DeleteAsync(LicenseClass);
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

        public async Task<string> EditAsync(LicenseClass LicenseClass)
        {
            await _LicenseClassRepository.UpdateAsync(LicenseClass);
            return "Success";
        }


        public async Task<LicenseClass> GetByIDAsync(int id)
        {
            var LicenseClass = await _LicenseClassRepository.GetByIdAsync(id);
            return LicenseClass;
        }

        public async Task<LicenseClass> GetLicenseClassByIDWithIncludeAsync(int id)
        {
            var LicenseClass = _LicenseClassRepository.GetTableNoTracking()
                                         .Include(x => x.Drivers)
                                         .Where(x => x.LicenseClassId.Equals(id))
                                         .FirstOrDefault();
            return LicenseClass;
        }

        public IQueryable<LicenseClass> GetLicenseClasssByOrderIDQuerable(int DID)
        {
            throw new NotImplementedException();
        }

        /* public IQueryable<LicenseClass> GetLicenseClasssByDriverIDQuerable(int DID)
         {
             return _LicenseClassRepository.GetTableNoTracking().Where(x => x.Drivers.DriverId.Equals(DID)).AsQueryable();
         }*/

        public async Task<List<LicenseClass>> GetLicenseClasssListAsync()
        {
            return await _LicenseClassRepository.GetTableNoTracking().Include(x => x.Drivers)
                                           .ToListAsync();
        }

        public IQueryable<LicenseClass> GetLicenseClasssQuerable()
        {
            return _LicenseClassRepository.GetTableNoTracking().Include(x => x.Drivers).AsQueryable();
        }





    }
}
