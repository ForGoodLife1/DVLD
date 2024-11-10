using DVLD.Data.Entities;

namespace DVLD.Service.Abstracts
{
    public interface IApplicationTypeService
    {
        public Task<List<ApplicationType>> GetApplicationTypesListAsync();
        // public Task<ApplicationType> GetApplicationTypeByIDWithIncludeAsync(int id);
        public Task<ApplicationType> GetByIDAsync(int id);
        public Task<string> AddAsync(ApplicationType ApplicationType);

        public Task<string> EditAsync(ApplicationType ApplicationType);
        public Task<string> DeleteAsync(ApplicationType ApplicationType);
        public IQueryable<ApplicationType> GetApplicationTypesQuerable();
        public IQueryable<ApplicationType> GetApplicationTypesByApplicationQuerable(int DID);
    }
}

