using DVLD.Data.Entities;
using DVLD.Infarastructure.InfrastructureBases;
using DVLD.Infrastructure.Abstracts;
using DVLD.Infrastructure.DvldDbContext;
using Microsoft.EntityFrameworkCore;

namespace DVLD.Infrastructure.Implementations
{
    public class TestTypeRepository : GenericRepositoryAsync<TestType>, ITestTypeRepository
    {
        private DbSet<TestType> _TestTypes;
        public TestTypeRepository(DvldContext dbContext) : base(dbContext)
        {
            _TestTypes=dbContext.Set<TestType>();
        }



    }
}
