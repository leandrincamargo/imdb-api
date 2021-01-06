using IMDb.Domain.DTOs.User;

namespace IMDb.Application.Interfaces.Services.Domain
{
    public interface IAuthenticationService
    {
        string Authenticate(UserLoginDto dto, out string error);
    }
}
