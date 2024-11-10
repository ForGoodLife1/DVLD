using DVLD.Data.Entities;

namespace DVLD.Service.Abstracts
{
    public interface ITestAppointmentService
    {
        public Task<List<TestAppointment>> GetTestAppointmentsListAsync();
        // public Task<TestAppointment> GetTestAppointmentByIDWithIncludeAsync(int id);
        public Task<TestAppointment> GetByIDAsync(int id);
        public Task<string> AddAsync(TestAppointment TestAppointment);

        public Task<string> EditAsync(TestAppointment TestAppointment);
        public Task<string> DeleteAsync(TestAppointment TestAppointment);
        public IQueryable<TestAppointment> GetTestAppointmentsQuerable();
        public IQueryable<TestAppointment> GetTestAppointmentsByOrderIDQuerable(int DID);
    }
}

