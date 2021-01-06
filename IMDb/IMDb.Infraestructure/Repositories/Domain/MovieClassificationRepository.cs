using IMDb.Domain.Entities;
using IMDb.Domain.Utility;
using IMDb.Infraestructure.DBConfiguration;
using IMDb.Infraestructure.Interfaces.Repositories.Domain;
using IMDb.Infraestructure.Repositories.Domain.Standard;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace IMDb.Infraestructure.Repositories.Domain
{
    public class MovieClassificationRepository : DomainRepository<MovieClassification>, IMovieClassificationRepository
    {
        public MovieClassificationRepository(ApplicationContext dbContext) : base(dbContext) { }

        public async Task<IEnumerable<MovieClassification>> GetByFiltersAsync(Expression<Func<MovieClassification, bool>> predicate,
           params Expression<Func<MovieClassification, object>>[] include)
        {
            return await GenerateQuery(predicate, null, include).ToListAsync();
        }
    }
}
