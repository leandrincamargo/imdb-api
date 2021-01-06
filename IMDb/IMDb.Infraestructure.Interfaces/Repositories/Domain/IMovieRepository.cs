using IMDb.Domain.Entities;
using IMDb.Domain.Utility;
using IMDb.Infraestructure.Interfaces.Repositories.Domain.Standard;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace IMDb.Infraestructure.Interfaces.Repositories.Domain
{
    public interface IMovieRepository : IDomainRepository<Movie>
    {
        Task<Movie> GetByIdIncludingCastAsync(Guid id);
        Task<IEnumerable<Movie>> GetIncludingCastAsync(Expression<Func<Movie, bool>> predicate);
        Task<Pagination<Movie>> GetIncludingCastWithPaginationAsync(Expression<Func<Movie, bool>> predicate, int pageNumber, int pageSize);
    }
}
