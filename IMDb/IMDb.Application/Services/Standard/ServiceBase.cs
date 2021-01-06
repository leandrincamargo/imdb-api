using IMDb.Application.Interfaces.Services.Standard;
using IMDb.Domain.Entities;
using IMDb.Infraestructure.Interfaces.Repositories.Standard;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IMDb.Application.Services.Standard
{
    public class ServiceBase<TEntity> : IServiceBase<TEntity> where TEntity : class, IIdentityEntity
    {
        protected readonly IRepositoryAsync<TEntity> repository;

        public ServiceBase(IRepositoryAsync<TEntity> repository)
        {
            this.repository = repository;
        }

        public async virtual Task<TEntity> AddAsync(TEntity obj)
        {
            return await repository.AddAsync(obj);
        }

        public async virtual Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await repository.GetAllAsync();
        }

        public async virtual Task<TEntity> GetByIdAsync(object id)
        {
            return await repository.GetByIdAsync(id);
        }

        public async virtual Task<bool> RemoveAsync(object id)
        {
            return await repository.RemoveAsync(id);
        }

        public async virtual Task RemoveAsync(TEntity obj)
        {
            await repository.RemoveAsync(obj);
        }

        public async virtual Task UpdateAsync(TEntity obj)
        {
            await repository.UpdateAsync(obj);
        }
    }
}
