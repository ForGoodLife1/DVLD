using DVLD.Data.Entities;
using DVLD.Infarastructure.InfrastructureBases;
using DVLD.Infrastructure.Abstracts;
using DVLD.Infrastructure.DvldDbContext;
using Microsoft.EntityFrameworkCore;

namespace DVLD.Infrastructure.Implementations
{
    public class ApplicationTypeRepository : GenericRepositoryAsync<ApplicationType>, IApplicationTypeRepository
    {
        private DbSet<ApplicationType> _ApplicationTypes;
        public ApplicationTypeRepository(DvldContext dbContext) : base(dbContext)
        {
            _ApplicationTypes=dbContext.Set<ApplicationType>();
        }



    }
}
