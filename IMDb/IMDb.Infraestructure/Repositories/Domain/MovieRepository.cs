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
    public class MovieRepository : DomainRepository<Movie>, IMovieRepository
    {
        public MovieRepository(ApplicationContext dbContext) : base(dbContext) { }

        public async Task<Movie> GetByIdIncludingCastAsync(Guid id)
        {
            return await dbContext.Set<Movie>()
                            .Include(x => x.CastOfMovies).ThenInclude(x => x.Cast)
                            .AsNoTracking()
                            .FirstOrDefaultAsync(x => x.Id.Equals(id));
        }

        public async Task<IEnumerable<Movie>> GetIncludingCastAsync(Expression<Func<Movie, bool>> predicate)
        {
            IQueryable<Movie> query = dbContext.Set<Movie>()
                                        .Include(x => x.CastOfMovies).ThenInclude(x => x.Cast)
                                        .Include(x => x.MoviesClassification)
                                        .AsNoTracking();

            return await query.Where(predicate).ToListAsync();
        }

        public async Task<Pagination<Movie>> GetIncludingCastWithPaginationAsync(Expression<Func<Movie, bool>> predicate, int pageNumber, int pageSize)
        {
            var query = dbContext.Set<Movie>()
                            .Include(x => x.CastOfMovies).ThenInclude(x => x.Cast)
                            .Include(x => x.MoviesClassification)
                            .OrderByDescending(x => x.MoviesClassification.Count()).ThenBy(x => x.Name)
                            .AsNoTracking();

            var skipNumber = Pagination<Movie>.CalculateSkipNumber(pageNumber, pageSize);
            var totalItemCount = await query.CountAsync();
            var movies = await query.Skip(skipNumber).Take(pageSize).ToListAsync();

            return new Pagination<Movie>
            (
                items: movies,
                totalItemCount: totalItemCount,
                pageSize: pageSize,
                currentPage: pageNumber
            );
        }
    }
}
