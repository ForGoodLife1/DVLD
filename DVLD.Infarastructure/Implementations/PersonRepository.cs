using DVLD.Data.Entities;
using DVLD.Infarastructure.InfrastructureBases;
using DVLD.Infrastructure.Abstracts;
using DVLD.Infrastructure.DvldDbContext;
using Microsoft.EntityFrameworkCore;

namespace DVLD.Infrastructure.Implementations
{
    public class PersonRepository : GenericRepositoryAsync<Person>, IPersonRepository
    {
        private DbSet<Person> _Persons;
        public PersonRepository(DvldContext dbContext) : base(dbContext)
        {
            _Persons=dbContext.Set<Person>();
        }



    }
}
