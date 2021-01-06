using IMDb.Application.Interfaces.Services.Standard;
using IMDb.Domain.DTOs.User;
using IMDb.Domain.Entities;
using IMDb.Domain.Utility;
using System;
using System.Threading.Tasks;

namespace IMDb.Application.Interfaces.Services.Domain
{
    public interface IUserService : IServiceBase<User>
    {
        Task AddAsync(NewUserDto dto);
        Task UpdateAsync(EditUserDto dto);
        Task ChangeStatusAsync(Guid userId, bool status);
        Task<Pagination<UserDto>> GetNonActiveCommonUsersAsync(int pageNumber, int pageSize);
    }
}
