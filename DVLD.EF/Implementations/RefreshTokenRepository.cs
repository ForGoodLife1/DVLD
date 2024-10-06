using DVLD.Data.Entities.Identity;
using DVLD.Infarastructure.InfrastructureBases;
using DVLD.Infrastructure.DvldDbContext;
using DVLD.Infrustructure.Abstracts;
using Microsoft.EntityFrameworkCore;

namespace DVLD.Infrustructure.Repositories
{
    public class RefreshTokenRepository : GenericRepositoryAsync<UserRefreshToken>, IRefreshTokenRepository
    {
        #region Fields
        private DbSet<UserRefreshToken> userRefreshToken;
        #endregion

        #region Constructors
        public RefreshTokenRepository(DvldContext dbContext) : base(dbContext)
        {
            userRefreshToken=dbContext.Set<UserRefreshToken>();
        }
        #endregion

        #region Handle Functions

        #endregion
    }
}
