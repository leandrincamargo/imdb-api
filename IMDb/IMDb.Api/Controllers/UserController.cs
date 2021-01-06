using IMDb.Application.Interfaces.Services.Domain;
using IMDb.Domain.DTOs.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace IMDb.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> AddUserAsync([FromBody] NewUserDto dto)
        {
            var errors = GetErrorListFromModelState();
            if (errors.Any())
                return BadRequest(errors);

            await _userService.AddAsync(dto);
            return Ok();
        }

        [HttpPut]
        [Authorize]
        [Route("Update")]
        public async Task<IActionResult> UpdateUserAsync([FromBody] EditUserDto dto)
        {
            var errors = GetErrorListFromModelState();
            if (errors.Any())
                return BadRequest(errors);

            await _userService.UpdateAsync(dto);
            return Ok();
        }

        [HttpPatch]
        [Authorize]
        [Route("Deactivate")]
        public async Task<IActionResult> DeactivateUser(Guid id)
        {
            await _userService.ChangeStatusAsync(id, false);
            return Ok();
        }

        [HttpPatch]
        [Authorize]
        [Route("Activate")]
        public async Task<IActionResult> ActivateUserAsync(Guid id)
        {
            await _userService.ChangeStatusAsync(id, true);
            return Ok();
        }

        [HttpGet]
        [Authorize(Roles = "41361f47-53bf-4084-965f-cabc95532565")]
        [Route("GetNonActiveCommonUsers")]
        public async Task<IActionResult> GetNonActiveCommonUsersAsync(int pageNumber = 1, int pageSize = 10)
        {
            var usersPagination = await _userService.GetNonActiveCommonUsersAsync(pageNumber, pageSize);
            return Ok(usersPagination);
        }
    }
}
