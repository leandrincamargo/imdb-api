using IMDb.Domain.Entities;
using IMDb.Domain.Utility;
using IMDb.Infraestructure.DBConfiguration;
using IMDb.Infraestructure.Interfaces.Repositories.Domain;
using IMDb.Infraestructure.Repositories.Domain.Standard;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace IMDb.Infraestructure.Repositories.Domain
{
    public class UserRepository : DomainRepository<User>, IUserRepository
    {
        public UserRepository(ApplicationContext dbContext) : base(dbContext) { }

        public async Task<Pagination<User>> GetUsersIncludingRoleWithPaginationAsync(Expression<Func<User, bool>> predicate, int pageNumber, int pageSize)
        {
            IQueryable<User> query = await Task.FromResult(GenerateQuery(filter: predicate,
                                                                         orderBy: x => x.OrderBy(y => y.FirstName),
                                                                         include: x => x.Role));

            var skipNumber = Pagination<User>.CalculateSkipNumber(pageNumber, pageSize);
            var totalItemCount = await query.CountAsync();
            var users = await query.Skip(skipNumber).Take(pageSize).ToListAsync();

            return new Pagination<User>
                (
                    items: users,
                    totalItemCount: totalItemCount,
                    pageSize: pageSize,
                    currentPage: pageNumber
                );
        }

        public User GetUserWithFilter(Expression<Func<User, bool>> predicate)
        {
            IQueryable<User> query = GenerateQuery(filter: predicate,
                                                    orderBy: x => x.OrderBy(y => y.FirstName),
                                                    include: x => x.Role);
            var user = query.FirstOrDefault();

            return user;
        }

        public async Task<bool> ValidatePasswordAsync(string email, string password)
        {
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
                return false;

            return await dbContext.Set<User>().AnyAsync(x => x.Email.ToLower().Equals(email.ToLower()) && x.Password.Equals(password));
        }
    }
}
