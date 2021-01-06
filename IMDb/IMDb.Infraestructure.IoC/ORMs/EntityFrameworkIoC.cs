using IMDb.Infraestructure.DBConfiguration;
using IMDb.Infraestructure.Interfaces.Repositories.Domain;
using IMDb.Infraestructure.Interfaces.Repositories.Standard;
using IMDb.Infraestructure.Repositories.Domain;
using IMDb.Infraestructure.Repositories.Standard;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IMDb.Infraestructure.IoC.ORMs
{
    public class EntityFrameworkIoC : OrmTypes
    {
        internal override IServiceCollection AddOrm(IServiceCollection services, IConfiguration configuration = null)
        {
            IConfiguration dbConnectionSettings = ResolveConfiguration.GetConnectionSettings(configuration);
            string conn = dbConnectionSettings.GetConnectionString("DefaultConnection");
            services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(conn));

            services.AddScoped(typeof(IRepositoryAsync<>), typeof(RepositoryAsync<>));
            services.AddScoped<ICastOfMovieRepository, CastOfMovieRepository>();
            services.AddScoped<ICastRepository, CastRepository>();
            services.AddScoped<IMovieClassificationRepository, MovieClassificationRepository>();
            services.AddScoped<IMovieRepository, MovieRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}
