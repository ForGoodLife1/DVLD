using DVLD.Data.Entities;
using DVLD.Infarastructure.InfrastructureBases;


namespace DVLD.Infrastructure.Abstracts
{
    public interface IPersonRepository: IGenericRepositoryAsync<Person>
    {
        public Task<List<Person>> GetPersonsListAsync();
    }
}
