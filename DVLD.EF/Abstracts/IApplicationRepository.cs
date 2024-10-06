using DVLD.Data.Entities;
using DVLD.Infarastructure.InfrastructureBases;


namespace DVLD.Infrastructure.Abstracts
{
    public interface IApplicationRepository: IGenericRepositoryAsync<Application>
    {
        public Task<List<Application>> GetApplicationsListAsync();
    }
}
