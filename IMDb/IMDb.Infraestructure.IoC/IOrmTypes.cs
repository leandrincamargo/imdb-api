using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IMDb.Infraestructure.IoC
{
    public interface IOrmTypes
    {
        IServiceCollection ResolveOrm(IServiceCollection services, IConfiguration configuration = null);
    }
}
