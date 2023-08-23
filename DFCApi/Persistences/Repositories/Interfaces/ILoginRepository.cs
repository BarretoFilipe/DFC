using API.Applications.Commands;
using API.Models;

namespace API.Persistences.Repositories.Interfaces
{
    public interface ILoginRepository
    {
        Task<Login?> Authenticate(UserLoginCommand userLogin);
    }
}