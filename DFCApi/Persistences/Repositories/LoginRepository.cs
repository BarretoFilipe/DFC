using API.Applications.Commands;
using API.Models;
using API.Persistences.Repositories.Interfaces;

namespace API.Persistences.Repositories
{
    public class LoginRepository : ILoginRepository
    {
        private static IList<Login> _users => new List<Login>
            {
                new Login("game", "dynamik"),
            };

        public async Task<Login?> Authenticate(UserLoginCommand userLogin)
        {
            var user = _users
                .FirstOrDefault(
                    u => u.Username == userLogin.Username.ToLower()
                    && u.Password == userLogin.Password
                );
            return await Task.FromResult(user);
        }
    }
}