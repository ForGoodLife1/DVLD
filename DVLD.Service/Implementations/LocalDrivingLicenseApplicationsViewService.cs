using DVLD.Data.Entities;
using DVLD.Infrastructure.Abstracts;
using DVLD.Service.Abstracts;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace DVLD.Service.Implementations
{
    public class LocalDrivingLicenseApplicationsViewService : ILocalDrivingLicenseApplicationsViewService
    {
        private readonly ILocalDrivingLicenseApplicationsViewRepository _LocalDrivingLicenseApplicationsViewRepository;

        public LocalDrivingLicenseApplicationsViewService(ILocalDrivingLicenseApplicationsViewRepository LocalDrivingLicenseApplicationsViewRepository)
        {
            _LocalDrivingLicenseApplicationsViewRepository=LocalDrivingLicenseApplicationsViewRepository;
        }

        public async Task<string> AddAsync(LocalDrivingLicenseApplicationsView LocalDrivingLicenseApplicationsView)
        {
            await _LocalDrivingLicenseApplicationsViewRepository.AddAsync(LocalDrivingLicenseApplicationsView);
            return "Success";
        }

        public async Task<string> DeleteAsync(LocalDrivingLicenseApplicationsView LocalDrivingLicenseApplicationsView)
        {
            var trans = _LocalDrivingLicenseApplicationsViewRepository.BeginTransaction();
            try
            {
                await _LocalDrivingLicenseApplicationsViewRepository.DeleteAsync(LocalDrivingLicenseApplicationsView);
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

        public async Task<string> EditAsync(LocalDrivingLicenseApplicationsView LocalDrivingLicenseApplicationsView)
        {
            await _LocalDrivingLicenseApplicationsViewRepository.UpdateAsync(LocalDrivingLicenseApplicationsView);
            return "Success";
        }



        public async Task<LocalDrivingLicenseApplicationsView> GetByIDAsync(int id)
        {
            var LocalDrivingLicenseApplicationsView = await _LocalDrivingLicenseApplicationsViewRepository.GetByIdAsync(id);
            return LocalDrivingLicenseApplicationsView;
        }

        public async Task<LocalDrivingLicenseApplicationsView> GetLocalDrivingLicenseApplicationsViewByIDWithIncludeAsync(int id)
        {
            var LocalDrivingLicenseApplicationsView = _LocalDrivingLicenseApplicationsViewRepository.GetTableNoTracking()
                                         .Include(x => x.Drivers)
                                         .Where(x => x.LocalDrivingLicenseApplicationsViewId.Equals(id))
                                         .FirstOrDefault();
            return LocalDrivingLicenseApplicationsView;
        }

        public IQueryable<LocalDrivingLicenseApplicationsView> GetLocalDrivingLicenseApplicationsViewsByOrderIDQuerable(int DID)
        {
            throw new NotImplementedException();
        }

        /* public IQueryable<LocalDrivingLicenseApplicationsView> GetLocalDrivingLicenseApplicationsViewsByDriverIDQuerable(int DID)
         {
             return _LocalDrivingLicenseApplicationsViewRepository.GetTableNoTracking().Where(x => x.Drivers.DriverId.Equals(DID)).AsQueryable();
         }*/

        public async Task<List<LocalDrivingLicenseApplicationsView>> GetLocalDrivingLicenseApplicationsViewsListAsync()
        {
            return await _LocalDrivingLicenseApplicationsViewRepository.GetTableNoTracking().Include(x => x.Drivers)
                                           .ToListAsync();
        }

        public IQueryable<LocalDrivingLicenseApplicationsView> GetLocalDrivingLicenseApplicationsViewsQuerable()
        {
            return _LocalDrivingLicenseApplicationsViewRepository.GetTableNoTracking().Include(x => x.Drivers).AsQueryable();
        }





    }
}
