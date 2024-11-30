using DVLD.Data.Entities;
using DVLD.Infarastructure.InfrastructureBases;
using DVLD.Infrastructure.Abstracts;
using DVLD.Infrastructure.DvldDbContext;
using Microsoft.EntityFrameworkCore;

namespace DVLD.Infrastructure.Implementations
{
    public class TestAppointmentsViewRepository : GenericRepositoryAsync<TestAppointmentsView>, ITestAppointmentsViewRepository
    {
        private DbSet<TestAppointmentsView> _TestAppointmentsViews;
        public TestAppointmentsViewRepository(DvldContext dbContext) : base(dbContext)
        {
            _TestAppointmentsViews=dbContext.Set<TestAppointmentsView>();
        }



    }
}
