namespace IMDb.Application.Interfaces.Services.Domain
{
    public interface ISecurityService
    {
        string Encrypt(string value, string salt);
    }
}
