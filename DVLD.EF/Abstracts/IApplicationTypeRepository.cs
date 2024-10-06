using DVLD.Data.Entities;
using DVLD.Infarastructure.InfrastructureBases;


namespace DVLD.Infrastructure.Abstracts
{
    public interface IApplicationTypeRepository: IGenericRepositoryAsync<ApplicationType>
    {
        public Task<List<ApplicationType>> GetApplicationTypesListAsync();
    }
}
