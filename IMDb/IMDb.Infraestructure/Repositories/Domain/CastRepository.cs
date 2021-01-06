using IMDb.Domain.Entities;
using IMDb.Infraestructure.DBConfiguration;
using IMDb.Infraestructure.Interfaces.Repositories.Domain;
using IMDb.Infraestructure.Repositories.Domain.Standard;

namespace IMDb.Infraestructure.Repositories.Domain
{
    public class CastRepository : DomainRepository<Cast>, ICastRepository
    {
        public CastRepository(ApplicationContext dbContext) : base(dbContext) { }
    }
}
