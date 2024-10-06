using DVLD.Data.Entities;
using DVLD.Infarastructure.InfrastructureBases;


namespace DVLD.Infrastructure.Abstracts
{
    public interface IDriverRepository: IGenericRepositoryAsync<Driver>
    {
        public Task<List<Driver>> GetDriversListAsync();
    }
}
