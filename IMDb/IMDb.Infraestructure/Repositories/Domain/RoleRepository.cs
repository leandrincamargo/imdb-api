using IMDb.Domain.Entities;
using IMDb.Infraestructure.DBConfiguration;
using IMDb.Infraestructure.Interfaces.Repositories.Domain;
using IMDb.Infraestructure.Repositories.Domain.Standard;

namespace IMDb.Infraestructure.Repositories.Domain
{
    public class RoleRepository : DomainRepository<Role>, IRoleRepository
    {
        public RoleRepository(ApplicationContext dbContext) : base(dbContext) { }
    }
}
