using DVLD.Data.Entities;
using DVLD.Infrastructure.Abstracts;
using DVLD.Service.Abstracts;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace DVLD.Service.Implementations
{
    public class LicenseService : ILicenseService
    {
        private readonly ILicenseRepository _LicenseRepository;

        public LicenseService(ILicenseRepository LicenseRepository)
        {
            _LicenseRepository=LicenseRepository;
        }

        public async Task<string> AddAsync(License License)
        {
            await _LicenseRepository.AddAsync(License);
            return "Success";
        }

        public async Task<string> DeleteAsync(License License)
        {
            var trans = _LicenseRepository.BeginTransaction();
            try
            {
                await _LicenseRepository.DeleteAsync(License);
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

        public async Task<string> EditAsync(License License)
        {
            await _LicenseRepository.UpdateAsync(License);
            return "Success";
        }


        public async Task<License> GetByIDAsync(int id)
        {
            var License = await _LicenseRepository.GetByIdAsync(id);
            return License;
        }

        public async Task<License> GetLicenseByIDWithIncludeAsync(int id)
        {
            var License = _LicenseRepository.GetTableNoTracking()
                                         .Include(x => x.Drivers)
                                         .Where(x => x.LicenseId.Equals(id))
                                         .FirstOrDefault();
            return License;
        }

        public IQueryable<License> GetLicensesByOrderIDQuerable(int DID)
        {
            throw new NotImplementedException();
        }

        /* public IQueryable<License> GetLicensesByDriverIDQuerable(int DID)
         {
             return _LicenseRepository.GetTableNoTracking().Where(x => x.Drivers.DriverId.Equals(DID)).AsQueryable();
         }*/

        public async Task<List<License>> GetLicensesListAsync()
        {
            return await _LicenseRepository.GetTableNoTracking().Include(x => x.Drivers)
                                           .ToListAsync();
        }

        public IQueryable<License> GetLicensesQuerable()
        {
            return _LicenseRepository.GetTableNoTracking().Include(x => x.Drivers).AsQueryable();
        }





    }
}
