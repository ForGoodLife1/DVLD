using DVLD.Data.Entities;
using DVLD.Infarastructure.InfrastructureBases;
using DVLD.Infrastructure.Abstracts;
using DVLD.Infrastructure.DvldDbContext;
using Microsoft.EntityFrameworkCore;

namespace DVLD.Infrastructure.Implementations
{
    public class TestAppointmentRepository : GenericRepositoryAsync<TestAppointment>, ITestAppointmentRepository
    {
        private DbSet<TestAppointment> _TestAppointments;
        public TestAppointmentRepository(DvldContext dbContext) : base(dbContext)
        {
            _TestAppointments=dbContext.Set<TestAppointment>();
        }



    }
}
