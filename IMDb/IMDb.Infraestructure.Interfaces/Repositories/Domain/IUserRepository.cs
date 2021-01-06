using IMDb.Domain.Entities;
using IMDb.Domain.Utility;
using IMDb.Infraestructure.Interfaces.Repositories.Domain.Standard;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace IMDb.Infraestructure.Interfaces.Repositories.Domain
{
    public interface IUserRepository : IDomainRepository<User>
    {
        Task<Pagination<User>> GetUsersIncludingRoleWithPaginationAsync(Expression<Func<User, bool>> predicate, int pageNumber, int pageSize);
        User GetUserWithFilter(Expression<Func<User, bool>> predicate);
        Task<bool> ValidatePasswordAsync(string email, string password);
    }
}
