using DVLD.Data.Entities;
using DVLD.Infrastructure.Abstracts;
using DVLD.Service.Abstracts;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace DVLD.Service.Implementations
{
    public class TestService : ITestService
    {
        private readonly ITestRepository _TestRepository;

        public TestService(ITestRepository TestRepository)
        {
            _TestRepository=TestRepository;
        }

        public async Task<string> AddAsync(Test Test)
        {
            await _TestRepository.AddAsync(Test);
            return "Success";
        }

        public async Task<string> DeleteAsync(Test Test)
        {
            var trans = _TestRepository.BeginTransaction();
            try
            {
                await _TestRepository.DeleteAsync(Test);
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

        public async Task<string> EditAsync(Test Test)
        {
            await _TestRepository.UpdateAsync(Test);
            return "Success";
        }


        public async Task<Test> GetByIDAsync(int id)
        {
            var Test = await _TestRepository.GetByIdAsync(id);
            return Test;
        }

        public async Task<Test> GetTestByIDWithIncludeAsync(int id)
        {
            var Test = _TestRepository.GetTableNoTracking()
                                         .Include(x => x.Drivers)
                                         .Where(x => x.TestId.Equals(id))
                                         .FirstOrDefault();
            return Test;
        }

        public IQueryable<Test> GetTestsByOrderIDQuerable(int DID)
        {
            throw new NotImplementedException();
        }

        /* public IQueryable<Test> GetTestsByDriverIDQuerable(int DID)
         {
             return _TestRepository.GetTableNoTracking().Where(x => x.Drivers.DriverId.Equals(DID)).AsQueryable();
         }*/

        public async Task<List<Test>> GetTestsListAsync()
        {
            return await _TestRepository.GetTableNoTracking().Include(x => x.Drivers)
                                           .ToListAsync();
        }

        public IQueryable<Test> GetTestsQuerable()
        {
            return _TestRepository.GetTableNoTracking().Include(x => x.Drivers).AsQueryable();
        }





    }
}
