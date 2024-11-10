using DVLD.Data.Entities;
using DVLD.Infrastructure.Abstracts;
using DVLD.Service.Abstracts;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace DVLD.Service.Implementations
{
    public class LocalDrivingLicenseApplicationService : ILocalDrivingLicenseApplicationService
    {
        private readonly ILocalDrivingLicenseApplicationRepository _LocalDrivingLicenseApplicationRepository;

        public LocalDrivingLicenseApplicationService(ILocalDrivingLicenseApplicationRepository LocalDrivingLicenseApplicationRepository)
        {
            _LocalDrivingLicenseApplicationRepository=LocalDrivingLicenseApplicationRepository;
        }

        public async Task<string> AddAsync(LocalDrivingLicenseApplication LocalDrivingLicenseApplication)
        {
            await _LocalDrivingLicenseApplicationRepository.AddAsync(LocalDrivingLicenseApplication);
            return "Success";
        }

        public async Task<string> DeleteAsync(LocalDrivingLicenseApplication LocalDrivingLicenseApplication)
        {
            var trans = _LocalDrivingLicenseApplicationRepository.BeginTransaction();
            try
            {
                await _LocalDrivingLicenseApplicationRepository.DeleteAsync(LocalDrivingLicenseApplication);
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

        public async Task<string> EditAsync(LocalDrivingLicenseApplication LocalDrivingLicenseApplication)
        {
            await _LocalDrivingLicenseApplicationRepository.UpdateAsync(LocalDrivingLicenseApplication);
            return "Success";
        }



        public async Task<LocalDrivingLicenseApplication> GetByIDAsync(int id)
        {
            var LocalDrivingLicenseApplication = await _LocalDrivingLicenseApplicationRepository.GetByIdAsync(id);
            return LocalDrivingLicenseApplication;
        }

        public async Task<LocalDrivingLicenseApplication> GetLocalDrivingLicenseApplicationByIDWithIncludeAsync(int id)
        {
            var LocalDrivingLicenseApplication = _LocalDrivingLicenseApplicationRepository.GetTableNoTracking()
                                         .Include(x => x.Drivers)
                                         .Where(x => x.LocalDrivingLicenseApplicationId.Equals(id))
                                         .FirstOrDefault();
            return LocalDrivingLicenseApplication;
        }

        public IQueryable<LocalDrivingLicenseApplication> GetLocalDrivingLicenseApplicationsByOrderIDQuerable(int DID)
        {
            throw new NotImplementedException();
        }

        /* public IQueryable<LocalDrivingLicenseApplication> GetLocalDrivingLicenseApplicationsByDriverIDQuerable(int DID)
         {
             return _LocalDrivingLicenseApplicationRepository.GetTableNoTracking().Where(x => x.Drivers.DriverId.Equals(DID)).AsQueryable();
         }*/

        public async Task<List<LocalDrivingLicenseApplication>> GetLocalDrivingLicenseApplicationsListAsync()
        {
            return await _LocalDrivingLicenseApplicationRepository.GetTableNoTracking().Include(x => x.Drivers)
                                           .ToListAsync();
        }

        public IQueryable<LocalDrivingLicenseApplication> GetLocalDrivingLicenseApplicationsQuerable()
        {
            return _LocalDrivingLicenseApplicationRepository.GetTableNoTracking().Include(x => x.Drivers).AsQueryable();
        }





    }
}
