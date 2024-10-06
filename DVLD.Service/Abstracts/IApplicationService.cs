using DVLD.Data.Entities;
using DVLD.Data.Enums;

namespace DVLD.Service.Abstracts
{
    public interface IApplicationService
    {
        public Task<List<Application>> GetApplicationsListAsync();
        public Task<Application> GetApplicationByIDWithIncludeAsync(int id);
        public Task<Application> GetByIDAsync(int id);
        public Task<string> AddAsync(Application application);
        public Task<bool> IsNameArExist(string nameAr);
        public Task<bool> IsNameEnExist(string nameEn);
        public Task<bool> IsNameArExistExcludeSelf(string nameAr, int id);
        public Task<bool> IsNameEnExistExcludeSelf(string nameEn, int id);
        public Task<string> EditAsync(Application application);
        public Task<string> DeleteAsync(Application application);
        public IQueryable<Application> GetApplicationsQuerable();
        public IQueryable<Application> GetApplicationsByApplicantPersonIDQuerable(int DID);
        public IQueryable<Application> FilterApplicationPaginatedQuerable(ApplicationOrderingEnum applicantPersoningEnum, int search);
    }
}

