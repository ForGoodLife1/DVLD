using DVLD.Service.Abstracts;
using DVLD.Service.AuthServices.Implementations;
using DVLD.Service.AuthServices.Interfaces;
using DVLD.Service.Implementations;
using Microsoft.Extensions.DependencyInjection;

namespace DVLD.Service
{
    public static class ModuleServiceDependencies
    {
        public static IServiceCollection AddServiceDependencies(this IServiceCollection services)
        {
            services.AddTransient<IApplicationService, ApplicationService>();
            services.AddTransient<IApplicationUserService, ApplicationUserService>();
            services.AddTransient<IAuthenticationService, AuthenticationService>();
            services.AddTransient<ICurrentUserService, CurrentUserService>();
            services.AddTransient<IAuthorizationService, AuthorizationService>();
            services.AddTransient<IEmailsService, EmailsService>();
            services.AddTransient<IFileService, FileService>();
            return services;

        }

    }
}
