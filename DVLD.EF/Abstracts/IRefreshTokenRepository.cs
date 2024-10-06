using DVLD.Data.Entities.Identity;
using DVLD.Infarastructure.InfrastructureBases;

namespace DVLD.Infrustructure.Abstracts
{
    public interface IRefreshTokenRepository : IGenericRepositoryAsync<UserRefreshToken>
    {

    }
}
