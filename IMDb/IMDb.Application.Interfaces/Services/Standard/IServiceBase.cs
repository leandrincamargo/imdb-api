using System.Collections.Generic;
using System.Threading.Tasks;

namespace IMDb.Application.Interfaces.Services.Standard
{
    public interface IServiceBase<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(object id);

        Task<TEntity> AddAsync(TEntity obj);
        Task UpdateAsync(TEntity obj);

        Task<bool> RemoveAsync(object id);
        Task RemoveAsync(TEntity obj);
    }
}
