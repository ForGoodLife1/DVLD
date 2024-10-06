using DVLD.Data.Entities;
using DVLD.Data.Enums;
using DVLD.Infrastructure.Abstracts;
using DVLD.Service.Abstracts;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace DVLD.Service.Implementations
{
    public class ApplicationService : IApplicationService
    {
        private readonly IApplicationRepository _applicationRepository;

        public ApplicationService(IApplicationRepository applicationRepository)
        {
            _applicationRepository=applicationRepository;
        }

        public async Task<string> AddAsync(Application application)
        {
            await _applicationRepository.AddAsync(application);
            return "Success";
        }

        public async Task<string> DeleteAsync(Application application)
        {
            var trans = _applicationRepository.BeginTransaction();
            try
            {
                await _applicationRepository.DeleteAsync(application);
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

        public async Task<string> EditAsync(Application application)
        {
            await _applicationRepository.UpdateAsync(application);
            return "Success";
        }



        public async Task<Application> GetByIDAsync(int id)
        {
            var application = await _applicationRepository.GetByIdAsync(id);
            return application;
        }

        public async Task<Application> GetApplicationByIDWithIncludeAsync(int id)
        {
            var application = _applicationRepository.GetTableNoTracking()
                                         .Include(x => x.ApplicantPerson)
                                         .Where(x => x.ApplicationId.Equals(id))
                                         .FirstOrDefault();
            return application;
        }

        public IQueryable<Application> GetApplicationsByApplicantPersonIDQuerable(int DID)
        {
            return _applicationRepository.GetTableNoTracking().Where(x => x.ApplicantPerson.PersonId.Equals(DID)).AsQueryable();
        }

        public async Task<List<Application>> GetApplicationsListAsync()
        {
            return await _applicationRepository.GetApplicationsListAsync();
        }

        public IQueryable<Application> GetApplicationsQuerable()
        {
            return _applicationRepository.GetTableNoTracking().Include(x => x.ApplicantPerson).AsQueryable();
        }

        public async Task<bool> IsNameArExist(string nameAr)
        {
            /* var Application = _applicationRepository.GetTableNoTracking().Where(x => x.NameAr.Equals(nameAr)).FirstOrDefault();
             if (Application==null) return false;
             return true;*/
            throw new NotImplementedException();
        }

        public async Task<bool> IsNameArExistExcludeSelf(string nameAr, int id)
        {/*
            var Application = await _applicationRepository.GetTableNoTracking().Where(x => x.NameAr.Equals(nameAr) & !x.ApplicationId.Equals(id)).FirstOrDefaultAsync();
            if (Application == null) return false;
            return true;*/
            throw new NotImplementedException();
        }

        public async Task<bool> IsNameEnExist(string nameEn)
        {
            /*var Application = _applicationRepository.GetTableNoTracking().Where(x => x.NameEn.Equals(nameEn)).FirstOrDefault();
            if (Application==null) return false;
            return true;*/
            throw new NotImplementedException();
        }

        public async Task<bool> IsNameEnExistExcludeSelf(string nameEn, int id)
        {
            /* var Application = await _applicationRepository.GetTableNoTracking().Where(x => x.NameEn.Equals(nameEn) & !x.ApplicationId.Equals(id)).FirstOrDefaultAsync();
             if (Application == null) return false;
             return true;*/
            throw new NotImplementedException();

        }

        public IQueryable<Application> FilterApplicationPaginatedQuerable(ApplicationOrderingEnum applicantPersoningEnum, int search)
        {
            var querable = _applicationRepository.GetTableNoTracking().Include(x => x.ApplicantPerson).AsQueryable();
            if (search != null)
            {
                querable = querable.Where(x => x.ApplicantPersonId==search || x.ApplicationId==search);
            }
            switch (applicantPersoningEnum)
            {
                case ApplicationOrderingEnum.ApplicationId:
                    querable = querable.OrderBy(x => x.ApplicationId);
                    break;
                case ApplicationOrderingEnum.ApplicationDate:
                    querable = querable.OrderBy(x => x.ApplicationDate);
                    break;
                case ApplicationOrderingEnum.ApplicationStatus:
                    querable = querable.OrderBy(x => x.ApplicationStatus);
                    break;
                case ApplicationOrderingEnum.ApplicantPersonId:
                    querable = querable.OrderBy(x => x.ApplicantPersonId);
                    break;


            }

            return querable;
        }


    }
}
