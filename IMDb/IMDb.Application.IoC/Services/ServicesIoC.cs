using IMDb.Application.Interfaces.Services.Domain;
using IMDb.Application.Interfaces.Services.Standard;
using IMDb.Application.Services.Domain;
using IMDb.Application.Services.Standard;
using Microsoft.Extensions.DependencyInjection;

namespace IMDb.Application.IoC.Services
{
    public static class ServicesIoC
    {
        public static void ApplicationServicesIoC(this IServiceCollection services)
        {
            services.AddScoped(typeof(IServiceBase<>), typeof(ServiceBase<>));

            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<IMovieService, MovieService>();
            services.AddScoped<ISecurityService, SecurityService>();
            services.AddScoped<IUserService, UserService>();
        }
    }
}
