using IMDb.Infraestructure.DBConfiguration;
using Microsoft.Extensions.Configuration;

namespace IMDb.Infraestructure.IoC
{
    internal class ResolveConfiguration
    {
        public static IConfiguration GetConnectionSettings(IConfiguration configuration)
        {
            return configuration ?? DatabaseConnection.ConnectionConfiguration;
        }
    }
}
