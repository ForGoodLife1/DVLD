using DVLD.Data.Entities;

namespace DVLD.Service.Abstracts
{
    public interface IPersonService
    {
        public Task<List<Person>> GetPersonsListAsync();
        // public Task<Person> GetPersonByIDWithIncludeAsync(int id);
        public Task<Person> GetByIDAsync(int id);
        public Task<string> AddAsync(Person Person);

        public Task<string> EditAsync(Person Person);
        public Task<string> DeleteAsync(Person Person);
        public IQueryable<Person> GetPersonsQuerable();
        public IQueryable<Person> GetPersonsByOrderIDQuerable(int DID);
    }
}

