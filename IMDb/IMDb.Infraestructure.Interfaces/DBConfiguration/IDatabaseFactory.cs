using System.Data;

namespace IMDb.Infraestructure.Interfaces.DBConfiguration
{
    public interface IDatabaseFactory
    {
        IDbConnection GetDbConnection { get; }
    }
}
