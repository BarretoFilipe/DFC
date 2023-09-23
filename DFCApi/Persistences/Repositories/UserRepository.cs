using API.Applications.Commands;
using API.Models;
using API.Persistences.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace API.Persistences.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;

        public UserRepository(SignInManager<User> signInManager, UserManager<User> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public async Task<SignInResult> Authenticate(UserLoginCommand userLogin)
        {
            var result = await _signInManager.PasswordSignInAsync(userLogin.UserName, userLogin.Password, false, true);

            return result;
        }

        public async Task<User> getByUserName(string userName)
        {
            var identity = await _userManager.FindByNameAsync(userName);
            return identity;
        }
    }
}