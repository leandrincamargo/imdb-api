using IMDb.Application.Interfaces.Services.Domain;
using IMDb.Application.Services.Standard;
using IMDb.Domain.DTOs.User;
using IMDb.Domain.Entities;
using IMDb.Domain.Utility;
using IMDb.Infraestructure.Interfaces.Repositories.Domain;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace IMDb.Application.Services.Domain
{
    public class UserService : ServiceBase<User>, IUserService
    {
        private readonly IUserRepository _repository;
        private readonly ISecurityService _securityService;

        public UserService(IUserRepository repository, ISecurityService securityService) : base(repository)
        {
            _repository = repository;
            _securityService = securityService;
        }

        public async Task AddAsync(NewUserDto dto)
        {
            var newUser = dto.DtoToEntity();
            newUser.Password = _securityService.Encrypt(newUser.Password, newUser.Email);
            await _repository.AddAsync(newUser);
        }

        public async Task ChangeStatusAsync(Guid userId, bool status)
        {
            var user = await _repository.GetByIdAsync(userId);
            user.Status = status;
            await _repository.UpdateAsync(user);
        }

        public async Task<Pagination<UserDto>> GetNonActiveCommonUsersAsync(int pageNumber, int pageSize)
        {
            var paginationUser = await _repository.GetUsersIncludingRoleWithPaginationAsync(x => x.RoleId == RoleIdentify.Common.Id && x.Status, pageNumber, pageSize);
            var paginationUserDto = new Pagination<UserDto>(paginationUser.Items.Select(x => new UserDto(x)), paginationUser.TotalItemCount, paginationUser.PageSize, paginationUser.CurrentPage);
            return paginationUserDto;
        }

        public async Task UpdateAsync(EditUserDto dto)
        {
            var user = await _repository.GetByIdAsync(dto.Id);
            user.FirstName = dto.FirstName;
            user.SecondName = dto.SecondName;
            user.Email = dto.Email;
            user.Password = !string.IsNullOrWhiteSpace(dto.Password) ? _securityService.Encrypt(dto.Password, dto.Email) : user.Password;

            await _repository.UpdateAsync(user);
        }
    }
}
