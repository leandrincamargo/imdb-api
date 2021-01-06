using IMDb.Domain.Entities;
using IMDb.Infraestructure.Interfaces.Repositories.Domain.Standard;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace IMDb.Infraestructure.Interfaces.Repositories.Domain
{
    public interface IMovieClassificationRepository : IDomainRepository<MovieClassification>
    {
        Task<IEnumerable<MovieClassification>> GetByFiltersAsync(Expression<Func<MovieClassification, bool>> predicate,
           params Expression<Func<MovieClassification, object>>[] include);
    }
}
