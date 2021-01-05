using IMDb.Domain.Entities;
using IMDb.Infraestructure.Interfaces.Repositories.Standard;

namespace IMDb.Infraestructure.Interfaces.Repositories.Domain.Standard
{
    public interface IDomainRepository<TEntity> : IRepositoryAsync<TEntity> where TEntity : class, IIdentityEntity
    {
    }
}
