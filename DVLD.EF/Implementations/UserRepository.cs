using DVLD.Data.Entities;
using DVLD.Infarastructure.InfrastructureBases;
using DVLD.Infrastructure.Abstracts;
using DVLD.Infrastructure.DvldDbContext;
using Microsoft.EntityFrameworkCore;

namespace DVLD.Infrastructure.Implementations
{
    public class UserRepository : GenericRepositoryAsync<User>, IUserRepository
    {
        private DbSet<User> _Users;
        public UserRepository(DvldContext dbContext) : base(dbContext)
        {
            _Users=dbContext.Set<User>();
        }



    }
}
