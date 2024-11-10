using DVLD.Data.Entities;

namespace DVLD.Service.Abstracts
{
    public interface ITestTypeService
    {
        public Task<List<TestType>> GetTestTypesListAsync();
        // public Task<TestType> GetTestTypeByIDWithIncludeAsync(int id);
        public Task<TestType> GetByIDAsync(int id);
        public Task<string> AddAsync(TestType TestType);

        public Task<string> EditAsync(TestType TestType);
        public Task<string> DeleteAsync(TestType TestType);
        public IQueryable<TestType> GetTestTypesQuerable();
        public IQueryable<TestType> GetTestTypesByOrderIDQuerable(int DID);
    }
}

