using DVLD.Data.Entities;
using DVLD.Infrastructure.Abstracts;
using DVLD.Service.Abstracts;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace DVLD.Service.Implementations
{
    public class ApplicationTypeService : IApplicationTypeService
    {
        private readonly IApplicationTypeRepository _ApplicationTypeRepository;

        public ApplicationTypeService(IApplicationTypeRepository ApplicationTypeRepository)
        {
            _ApplicationTypeRepository=ApplicationTypeRepository;
        }

        public async Task<string> AddAsync(ApplicationType ApplicationType)
        {
            await _ApplicationTypeRepository.AddAsync(ApplicationType);
            return "Success";
        }

        public async Task<string> DeleteAsync(ApplicationType ApplicationType)
        {
            var trans = _ApplicationTypeRepository.BeginTransaction();
            try
            {
                await _ApplicationTypeRepository.DeleteAsync(ApplicationType);
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

        public async Task<string> EditAsync(ApplicationType ApplicationType)
        {
            await _ApplicationTypeRepository.UpdateAsync(ApplicationType);
            return "Success";
        }



        public async Task<ApplicationType> GetByIDAsync(int id)
        {
            var ApplicationType = await _ApplicationTypeRepository.GetByIdAsync(id);
            return ApplicationType;
        }

        public async Task<ApplicationType> GetApplicationTypeByIDWithIncludeAsync(int id)
        {
            var ApplicationType = _ApplicationTypeRepository.GetTableNoTracking()
                                         .Where(x => x.ApplicationTypeId.Equals(id))
                                         .FirstOrDefault();
            return ApplicationType;
        }


        /* public IQueryable<ApplicationType> GetApplicationTypesByDriverIDQuerable(int DID)
         {
             return _ApplicationTypeRepository.GetTableNoTracking().Where(x => x.Drivers.DriverId.Equals(DID)).AsQueryable();
         }*/

        public async Task<List<ApplicationType>> GetApplicationTypesListAsync()
        {
            return await _ApplicationTypeRepository.GetTableNoTracking()
                                           .ToListAsync();
        }

        public IQueryable<ApplicationType> GetApplicationTypesQuerable()
        {
            return _ApplicationTypeRepository.GetTableNoTracking().AsQueryable();
        }

        public IQueryable<ApplicationType> GetApplicationTypesByApplicationQuerable(int DID)
        {
            throw new NotImplementedException();
        }
    }
}
