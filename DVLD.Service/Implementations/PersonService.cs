using DVLD.Data.Entities;
using DVLD.Infrastructure.Abstracts;
using DVLD.Service.Abstracts;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace DVLD.Service.Implementations
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _PersonRepository;

        public PersonService(IPersonRepository PersonRepository)
        {
            _PersonRepository=PersonRepository;
        }

        public async Task<string> AddAsync(Person Person)
        {
            await _PersonRepository.AddAsync(Person);
            return "Success";
        }

        public async Task<string> DeleteAsync(Person Person)
        {
            var trans = _PersonRepository.BeginTransaction();
            try
            {
                await _PersonRepository.DeleteAsync(Person);
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

        public async Task<string> EditAsync(Person Person)
        {
            await _PersonRepository.UpdateAsync(Person);
            return "Success";
        }



        public async Task<Person> GetByIDAsync(int id)
        {
            var Person = await _PersonRepository.GetByIdAsync(id);
            return Person;
        }

        public async Task<Person> GetPersonByIDWithIncludeAsync(int id)
        {
            var Person = _PersonRepository.GetTableNoTracking()
                                         .Include(x => x.Drivers)
                                         .Where(x => x.PersonId.Equals(id))
                                         .FirstOrDefault();
            return Person;
        }

        public IQueryable<Person> GetPersonsByOrderIDQuerable(int DID)
        {
            throw new NotImplementedException();
        }

        /* public IQueryable<Person> GetPersonsByDriverIDQuerable(int DID)
         {
             return _PersonRepository.GetTableNoTracking().Where(x => x.Drivers.DriverId.Equals(DID)).AsQueryable();
         }*/

        public async Task<List<Person>> GetPersonsListAsync()
        {
            return await _PersonRepository.GetTableNoTracking().Include(x => x.Drivers)
                                           .ToListAsync();
        }

        public IQueryable<Person> GetPersonsQuerable()
        {
            return _PersonRepository.GetTableNoTracking().Include(x => x.Drivers).AsQueryable();
        }





    }
}
