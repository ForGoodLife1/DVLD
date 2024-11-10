using DVLD.Data.Entities;

namespace DVLD.Service.Abstracts
{
    public interface ITestService
    {
        public Task<List<Test>> GetTestsListAsync();
        // public Task<Test> GetTestByIDWithIncludeAsync(int id);
        public Task<Test> GetByIDAsync(int id);
        public Task<string> AddAsync(Test Test);

        public Task<string> EditAsync(Test Test);
        public Task<string> DeleteAsync(Test Test);
        public IQueryable<Test> GetTestsQuerable();
        public IQueryable<Test> GetTestsByOrderIDQuerable(int DID);

    }
}

