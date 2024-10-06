using DVLD.Infarastructure.InfrastructureBases;
using DVLD.Infrastructure.Abstracts;
using DVLD.Infrastructure.Implementations;
using DVLD.Infrustructure.Abstracts;
using DVLD.Infrustructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace DVLD.Infrastructure
{
    public static class ModuleInfrastructureDependencies
    {
        public static IServiceCollection AddInfrastructureDependencies(this IServiceCollection services)
        {
            services.AddTransient<IApplicationRepository, ApplicationRepository>();
            services.AddTransient<IApplicationTypeRepository, ApplicationTypeRepository>();
            services.AddTransient<ICountryRepository, CountryRepository>();
            services.AddTransient<IDriverRepository, DriverRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IPersonRepository, PersonRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IRefreshTokenRepository, RefreshTokenRepository>();
            services.AddTransient(typeof(IGenericRepositoryAsync<>), typeof(GenericRepositoryAsync<>));
            return services;

        }
    }
}
