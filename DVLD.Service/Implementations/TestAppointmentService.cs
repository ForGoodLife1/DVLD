using DVLD.Data.Entities;
using DVLD.Infrastructure.Abstracts;
using DVLD.Service.Abstracts;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace DVLD.Service.Implementations
{
    public class TestAppointmentService : ITestAppointmentService
    {
        private readonly ITestAppointmentRepository _TestAppointmentRepository;

        public TestAppointmentService(ITestAppointmentRepository TestAppointmentRepository)
        {
            _TestAppointmentRepository=TestAppointmentRepository;
        }

        public async Task<string> AddAsync(TestAppointment TestAppointment)
        {
            await _TestAppointmentRepository.AddAsync(TestAppointment);
            return "Success";
        }

        public async Task<string> DeleteAsync(TestAppointment TestAppointment)
        {
            var trans = _TestAppointmentRepository.BeginTransaction();
            try
            {
                await _TestAppointmentRepository.DeleteAsync(TestAppointment);
                await trans.CommitAsync();
                return "Success";
            }
            catch (Exception ex)
            {
                await trans.RollbackAsync();
                Log.Error(ex.Message);
                return "Falied";
            }
        }

        public async Task<string> EditAsync(TestAppointment TestAppointment)
        {
            await _TestAppointmentRepository.UpdateAsync(TestAppointment);
            return "Success";
        }



        public async Task<TestAppointment> GetByIDAsync(int id)
        {
            var TestAppointment = await _TestAppointmentRepository.GetByIdAsync(id);
            return TestAppointment;
        }

        public async Task<TestAppointment> GetTestAppointmentByIDWithIncludeAsync(int id)
        {
            var TestAppointment = _TestAppointmentRepository.GetTableNoTracking()
                                         .Include(x => x.Drivers)
                                         .Where(x => x.TestAppointmentId.Equals(id))
                                         .FirstOrDefault();
            return TestAppointment;
        }

        public IQueryable<TestAppointment> GetTestAppointmentsByOrderIDQuerable(int DID)
        {
            throw new NotImplementedException();
        }

        /* public IQueryable<TestAppointment> GetTestAppointmentsByDriverIDQuerable(int DID)
         {
             return _TestAppointmentRepository.GetTableNoTracking().Where(x => x.Drivers.DriverId.Equals(DID)).AsQueryable();
         }*/

        public async Task<List<TestAppointment>> GetTestAppointmentsListAsync()
        {
            return await _TestAppointmentRepository.GetTableNoTracking().Include(x => x.Drivers)
                                           .ToListAsync();
        }

        public IQueryable<TestAppointment> GetTestAppointmentsQuerable()
        {
            return _TestAppointmentRepository.GetTableNoTracking().Include(x => x.Drivers).AsQueryable();
        }





    }
}
