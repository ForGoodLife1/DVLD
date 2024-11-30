using DVLD.Data.Entities;
using DVLD.Infarastructure.InfrastructureBases;
using DVLD.Infrastructure.Abstracts;
using DVLD.Infrastructure.DvldDbContext;
using Microsoft.EntityFrameworkCore;

namespace DVLD.Infrastructure.Implementations
{
    public class TestRepository : GenericRepositoryAsync<Test>, ITestRepository
    {
        private DbSet<Test> _Tests;
        public TestRepository(DvldContext dbContext) : base(dbContext)
        {
            _Tests=dbContext.Set<Test>();
        }



    }
}
