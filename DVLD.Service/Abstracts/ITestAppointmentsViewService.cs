using DVLD.Data.Entities;

namespace DVLD.Service.Abstracts
{
    public interface ITestAppointmentsViewService
    {
        public Task<List<TestAppointmentsView>> GetTestAppointmentsViewsListAsync();
        // public Task<TestAppointmentsView> GetTestAppointmentsViewByIDWithIncludeAsync(int id);
        public Task<TestAppointmentsView> GetByIDAsync(int id);
        public Task<string> AddAsync(TestAppointmentsView TestAppointmentsView);

        public Task<string> EditAsync(TestAppointmentsView TestAppointmentsView);
        public Task<string> DeleteAsync(TestAppointmentsView TestAppointmentsView);
        public IQueryable<TestAppointmentsView> GetTestAppointmentsViewsQuerable();
        public IQueryable<TestAppointmentsView> GetTestAppointmentsViewsByOrderIDQuerable(int DID);
    }
}

