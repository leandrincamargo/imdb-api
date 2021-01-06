using IMDb.Application.Interfaces.Services.Domain;
using IMDb.Domain.DTOs.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace IMDb.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : BaseController
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public IActionResult Authenticate([FromBody] UserLoginDto dto)
        {
            try
            {
                string error;
                var token = _authenticationService.Authenticate(dto, out error);

                if (!string.IsNullOrWhiteSpace(error))
                    return NotFound(new { message = error });

                return Ok(new { token = token });
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
