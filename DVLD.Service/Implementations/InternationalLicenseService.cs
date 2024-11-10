using DVLD.Data.Entities;
using DVLD.Infrastructure.Abstracts;
using DVLD.Service.Abstracts;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace DVLD.Service.Implementations
{
    public class InternationalLicenseService : IInternationalLicenseService
    {
        private readonly IInternationalLicenseRepository _InternationalLicenseRepository;

        public InternationalLicenseService(IInternationalLicenseRepository InternationalLicenseRepository)
        {
            _InternationalLicenseRepository=InternationalLicenseRepository;
        }

        public async Task<string> AddAsync(InternationalLicense InternationalLicense)
        {
            await _InternationalLicenseRepository.AddAsync(InternationalLicense);
            return "Success";
        }

        public async Task<string> DeleteAsync(InternationalLicense InternationalLicense)
        {
            var trans = _InternationalLicenseRepository.BeginTransaction();
            try
            {
                await _InternationalLicenseRepository.DeleteAsync(InternationalLicense);
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

        public async Task<string> EditAsync(InternationalLicense InternationalLicense)
        {
            await _InternationalLicenseRepository.UpdateAsync(InternationalLicense);
            return "Success";
        }



        public async Task<InternationalLicense> GetByIDAsync(int id)
        {
            var InternationalLicense = await _InternationalLicenseRepository.GetByIdAsync(id);
            return InternationalLicense;
        }

        public async Task<InternationalLicense> GetInternationalLicenseByIDWithIncludeAsync(int id)
        {
            var InternationalLicense = _InternationalLicenseRepository.GetTableNoTracking()
                                         .Include(x => x.Drivers)
                                         .Where(x => x.InternationalLicenseId.Equals(id))
                                         .FirstOrDefault();
            return InternationalLicense;
        }

        public IQueryable<InternationalLicense> GetInternationalLicensesByOrderIDQuerable(int DID)
        {
            throw new NotImplementedException();
        }

        /* public IQueryable<InternationalLicense> GetInternationalLicensesByDriverIDQuerable(int DID)
         {
             return _InternationalLicenseRepository.GetTableNoTracking().Where(x => x.Drivers.DriverId.Equals(DID)).AsQueryable();
         }*/

        public async Task<List<InternationalLicense>> GetInternationalLicensesListAsync()
        {
            return await _InternationalLicenseRepository.GetTableNoTracking().Include(x => x.Drivers)
                                           .ToListAsync();
        }

        public IQueryable<InternationalLicense> GetInternationalLicensesQuerable()
        {
            return _InternationalLicenseRepository.GetTableNoTracking().Include(x => x.Drivers).AsQueryable();
        }





    }
}
