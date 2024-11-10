using DVLD.Data.Entities;
using DVLD.Infarastructure.InfrastructureBases;
using DVLD.Infrastructure.Abstracts;
using DVLD.Infrastructure.DvldDbContext;
using Microsoft.EntityFrameworkCore;

namespace DVLD.Infrastructure.Implementations
{
    public class CountryRepository : GenericRepositoryAsync<Country>, ICountryRepository
    {
        private DbSet<Country> _Countrys;
        public CountryRepository(DvldContext dbContext) : base(dbContext)
        {
            _Countrys=dbContext.Set<Country>();
        }



    }
}
