using API.Applications.Commands;
using API.Models;
using Microsoft.AspNetCore.Identity;

namespace API.Persistences.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<SignInResult> Authenticate(UserLoginCommand userLogin);
        Task<User> getByUserName(string userName);
    }
}