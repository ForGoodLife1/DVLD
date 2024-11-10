using DVLD.Data.Entities;
using DVLD.Infrastructure.Abstracts;
using DVLD.Service.Abstracts;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace DVLD.Service.Implementations
{
    public class TestTypeService : ITestTypeService
    {
        private readonly ITestTypeRepository _TestTypeRepository;

        public TestTypeService(ITestTypeRepository TestTypeRepository)
        {
            _TestTypeRepository=TestTypeRepository;
        }

        public async Task<string> AddAsync(TestType TestType)
        {
            await _TestTypeRepository.AddAsync(TestType);
            return "Success";
        }

        public async Task<string> DeleteAsync(TestType TestType)
        {
            var trans = _TestTypeRepository.BeginTransaction();
            try
            {
                await _TestTypeRepository.DeleteAsync(TestType);
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

        public async Task<string> EditAsync(TestType TestType)
        {
            await _TestTypeRepository.UpdateAsync(TestType);
            return "Success";
        }


        public async Task<TestType> GetByIDAsync(int id)
        {
            var TestType = await _TestTypeRepository.GetByIdAsync(id);
            return TestType;
        }

        public async Task<TestType> GetTestTypeByIDWithIncludeAsync(int id)
        {
            var TestType = _TestTypeRepository.GetTableNoTracking()
                                         .Include(x => x.Drivers)
                                         .Where(x => x.TestTypeId.Equals(id))
                                         .FirstOrDefault();
            return TestType;
        }

        public IQueryable<TestType> GetTestTypesByOrderIDQuerable(int DID)
        {
            throw new NotImplementedException();
        }

        /* public IQueryable<TestType> GetTestTypesByDriverIDQuerable(int DID)
         {
             return _TestTypeRepository.GetTableNoTracking().Where(x => x.Drivers.DriverId.Equals(DID)).AsQueryable();
         }*/

        public async Task<List<TestType>> GetTestTypesListAsync()
        {
            return await _TestTypeRepository.GetTableNoTracking().Include(x => x.Drivers)
                                           .ToListAsync();
        }

        public IQueryable<TestType> GetTestTypesQuerable()
        {
            return _TestTypeRepository.GetTableNoTracking().Include(x => x.Drivers).AsQueryable();
        }





    }
}
