using API.Applications.Commands;
using API.Applications.ViewModels;
using API.Controllers.Base;
using API.Persistences.Repositories.Interfaces;
using API.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/v1/account")]
    public class AccountController : BaseController
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;

        public AccountController(ITokenService tokenService, IUserRepository userRepository)
        {
            _tokenService = tokenService;
            _userRepository = userRepository;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<UserLoginViewModel>> Login([FromBody] UserLoginCommand userLogin)
        {
            var result = await _userRepository.Authenticate(userLogin);

            if (result.Succeeded)
            {
                var user = await _userRepository.getByUserName(userLogin.UserName);
                var token = await _tokenService.GenerateToken(user);
                var userLoginViewModel = new UserLoginViewModel(token);

                return Ok(userLoginViewModel);
            }
            if (result.IsLockedOut)
            {
                return NotFound(new { message = "User account locked out" });
            }
            else
            {
                return NotFound(new { message = "User or password is invalid" });
            }
        }
    }
}