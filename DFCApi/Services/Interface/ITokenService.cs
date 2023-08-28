using API.Models;

namespace API.Services.Interface
{
    public interface ITokenService
    {
        Task<string> GenerateToken(Login login);
    }
}